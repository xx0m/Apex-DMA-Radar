using System.Collections.ObjectModel;

namespace apex_dma_radar
{
    /// <summary>
    /// Class containing Game (Raid) instance.
    /// </summary>
    public class Game
    {
        private RegisteredPlayers _rgtPlayers;
        private readonly ulong _apexBase;
        private ulong _spectators;
        private volatile bool _inGame = false;
        private Level _level;
        private Player _localPlayer;
        private GlowManager _glowManager;

        public enum GameStatus
        {
            NotFound,
            Found,
            Menu,
            LoadingLoot,
            Matching,
            InGame,
            Error
        }

        #region Getters
        public bool InGame => _inGame;
        public ReadOnlyDictionary<string, Player> Players => _rgtPlayers?.Players;
        public Level Level => _level;
        public GlowManager GlowManager => _glowManager;
        public Player LocalPlayer => _localPlayer;
        public ulong Spectators => _spectators;
        public Player SpectatedPlayer => this.Players.FirstOrDefault(x => x.Value.IsSpectatedByLocalPlayer).Value;
        private Config Config => Program.Config;
        #endregion

        #region Apex Maps
        public static readonly Dictionary<string, string> LegendMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"dummie", "DUMMIE"},
            {"alter", "ALTER"},
            {"ash", "ASH"},
            {"ballistic", "BALLISTIC"},
            {"bangalore", "BANGALORE"},
            {"bloodhound", "BLOODHOUND"},
            {"catalyst", "CATALYST"},
            {"caustic", "CAUSTIC"},
            {"conduit", "CONDUIT"},
            {"crypto", "CRYPTO"},
            {"fuse", "FUSE"},
            {"gibraltar", "GIBRALTAR"},
            {"horizon", "HORIZON"},
            {"nova", "HORIZON"},
            {"holo", "MIRAGE"},
            {"mirage", "MIRAGE"},
            {"lifeline", "LIFELINE"},
            {"loba", "LOBA"},
            {"madmaggie", "MADMAGGIE"},
            {"newcastle", "NEWCASTLE"},
            {"octane", "OCTANE"},
            {"pathfinder", "PATHFINDER"},
            {"rampart", "RAMPART"},
            {"revenant", "REVENANT"},
            {"seer", "SEER"},
            {"stim", "OCTANE"},
            {"valkyrie", "VALKYRIE"},
            {"vantage", "VANTAGE"},
            {"wattson", "WATTSON"},
            {"wraith", "WRAITH"}
        };

        public static readonly Dictionary<WeaponID, string> WeaponMap = new Dictionary<WeaponID, string>()
        {
            [WeaponID.R301] = "R-301",
            [WeaponID.Sentinel] = "Sentinel",
            [WeaponID.Bocek] = "Bocek",
            [WeaponID.Rampage] = "Rampage",
            [WeaponID.Sheila] = "Sheila",
            [WeaponID.Alternator] = "Alternator",
            [WeaponID.RE45] = "RE-45",
            [WeaponID.ChargeRifle] = "Charge Rifle",
            [WeaponID.Devotion] = "Devotion",
            [WeaponID.Longbow] = "Longbow",
            [WeaponID.Havoc] = "Havoc",
            [WeaponID.EVA8] = "EVA-8",
            [WeaponID.Flatline] = "Flatline",
            [WeaponID.G7] = "G7",
            [WeaponID.Hemlock] = "Hemlock",
            [WeaponID.Kraber] = "Kraber",
            [WeaponID.LStar] = "L-STAR",
            [WeaponID.Mastiff] = "Mastiff",
            [WeaponID.Mozamique] = "Mozamique",
            [WeaponID.Prowler] = "Prowler",
            [WeaponID.Peacekeeper] = "Peacekeeper",
            [WeaponID.R99] = "R-99",
            [WeaponID.P2020] = "P2020",
            [WeaponID.Spitfire] = "Spitfire",
            [WeaponID.TripleTake] = "Triple Take",
            [WeaponID.Wingman] = "Wingman",
            [WeaponID.Volt] = "Volt",
            [WeaponID.Repeater3030] = "30-30",
            [WeaponID.CAR] = "C.A.R",
            [WeaponID.Nemesis] = "Nemesis",
            [WeaponID.Melee] = "Melee",
            [WeaponID.ThrowingKnife] = "Throwing Knife"
        };
        #endregion

        /// <summary>
        /// Game Constructor.
        /// </summary>
        private static readonly object logLock = new();
        private readonly StreamWriter debuglog;
        public Game(ulong apexBase)
        {
            this._apexBase = apexBase;
        }

        #region GameLoop
        /// <summary>
        /// Main Game Loop executed by Memory Worker Thread.
        /// It manages the updating of player list and game environment elements like loot, grenades, and exfils.
        /// </summary>
        public void GameLoop()
        {
            try
            {
                if (!this.InGame)
                    throw new MatchEnded();

                this._rgtPlayers.UpdateList();
                this._rgtPlayers.UpdateAllPlayers();
                this.UpdateMisc();
            }
            catch (DMAShutdown)
            {
                HandleDMAShutdown();
            }
            catch (MatchEnded e)
            {
                HandleMatchEnded(e);
            }
            catch (Exception ex)
            {
                HandleUnexpectedException(ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handles the scenario when DMA shutdown occurs.
        /// </summary>
        private void HandleDMAShutdown()
        {
            Memory.Restart();
        }

        /// <summary>
        /// Handles the scenario when the raid ends.
        /// </summary>
        /// <param name="e">The RaidEnded exception instance containing details about the raid end.</param>
        private void HandleMatchEnded(MatchEnded e)
        {
            Program.Log("Match has ended!");
            Memory.Restart();
        }

        /// <summary>
        /// Handles unexpected exceptions that occur during the game loop.
        /// </summary>
        /// <param name="ex">The exception instance that was thrown.</param>
        private void HandleUnexpectedException(Exception ex)
        {
            Program.Log($"CRITICAL ERROR - Raid ended due to unhandled exception: {ex}");
            Memory.Restart();
        }

        /// <summary>
        /// Waits until game has started before returning to caller.
        /// </summary>
        public void WaitForGame()
        {
            while (!this.GetGameLevel() || !this.GetGlowHighlight() || !this.GetSpectators() || !this.GetLocalPlayer() || !this.SetupRegisteredplayers())
            {
                Thread.Sleep(2000);
            }

            Thread.Sleep(1500);
            Program.Log("Match has started!!");
            this._inGame = true;
            Thread.Sleep(1500);

            Memory.GameStatus = Game.GameStatus.InGame;
        }

        private bool GetGameLevel()
        {
            try
            {
                if (this._level is not null)
                {
                    return this._level.CheckLevel();
                }
                else
                {
                    this._level = new Level(this._apexBase + Offsets.Miscellaneous.LevelName, this._apexBase + Offsets.Miscellaneous.Gamemode + 0x50);
                    return this.Level.IsPlayable;
                }
            }
            catch (DMAShutdown) { throw; }
            catch (Exception ex)
            {
                if (!Memory.IsGameRunning)
                    throw new GameNotRunningException($"ERROR getting GameLevel, game may not be running: {ex}");

                return false;
            }
        }

        private bool GetLocalPlayer()
        {
            try
            {
                if (this._localPlayer is not null && !this.InGame)
                    return true;

                var baseAddress = Memory.ReadPtr(this._apexBase + Offsets.Miscellaneous.LocalPlayer);

                var localPlayer = new Player(baseAddress, 0, true);
                localPlayer.TeamID = Memory.ReadValue<int>(baseAddress + Offsets.BaseEntity.TeamID);
                localPlayer.Class = Memory.ReadString(baseAddress + Offsets.BaseEntity.Name);
                localPlayer.IsDead = Memory.ReadValue<bool>(baseAddress + Offsets.Player.LifeState);
                localPlayer.IsActive = true;
                localPlayer.Setup();

                var name = localPlayer.Name;

                if (!localPlayer.IsDead && (string.IsNullOrEmpty(name) || name.Contains('\u0002')))
                    return false;
                else if (localPlayer.IsDead && (string.IsNullOrEmpty(name) || name.Contains('\u0002')))
                    localPlayer.Name = "LocalPlayer";

                this._localPlayer = localPlayer;

                return true;
            }
            catch (DMAShutdown) { throw; }
            catch (Exception ex)
            {
                if (!Memory.Level.IsPlayable)
                    if (!Memory.IsGameRunning)
                        throw new GameNotRunningException($"ERROR getting LocalPlayer, game may not be running: {ex}");

                return false;
            }
        }

        private bool SetupRegisteredplayers()
        {
            var registeredPlayers = new RegisteredPlayers();

            if (registeredPlayers.Players.Count > 0)
            {
                this._rgtPlayers = registeredPlayers;
                Memory.GameStatus = Game.GameStatus.InGame;

                return true;
            }

            return false;
        }

        public bool GetSpectators()
        {
            try
            {
                if (this._spectators != 0)
                    return true;

                this._spectators = Memory.ReadPtr(this._apexBase + Offsets.Spectator.List);

                return this._spectators != 0;
            }
            catch (DMAShutdown) { throw; }
            catch (Exception ex)
            {
                if (!Memory.IsGameRunning)
                    throw new GameNotRunningException($"ERROR getting SpectatorList, game may not be running: {ex}");

                return false;
            }
        }

        public bool GetGlowHighlight()
        {
            try
            {
                if (this._glowManager is not null)
                    return true;

                this._glowManager = new GlowManager(this._apexBase + Offsets.Glow.Highlights);

                return true;
            }
            catch (DMAShutdown) { throw; }
            catch (Exception ex)
            {
                if (!Memory.IsGameRunning)
                    throw new GameNotRunningException($"ERROR getting GlowHighlight, game may not be running: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Loot, grenades, exfils,etc.
        /// </summary>
        private void UpdateMisc()
        {
            if (this.Level.IsPlayable && this.InGame && this._rgtPlayers.Players.Count > 1)
            {
                if (!this.Level.CheckLevel())
                    throw new MatchEnded();

                if (this.Config.MasterSwitch)
                {
                    if (!this.GlowManager.IsRunning)
                        this.GlowManager.Start();
                    else
                        this.GlowManager.Refresh();
                }
            }
        }
        #endregion
    }

    #region Exceptions
    public class GameNotRunningException : Exception
    {
        public GameNotRunningException()
        {
        }

        public GameNotRunningException(string message)
            : base(message)
        {
        }

        public GameNotRunningException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class MatchEnded : Exception
    {
        public MatchEnded()
        {
        }

        public MatchEnded(string message)
            : base(message)
        {
        }

        public MatchEnded(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    #endregion
}
