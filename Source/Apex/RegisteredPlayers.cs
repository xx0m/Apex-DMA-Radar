using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;

namespace apex_dma_radar
{
    public class RegisteredPlayers
    {
        private readonly Stopwatch _checkPlayersSw = new();
        private readonly Stopwatch _healthSw = new();
        private readonly Stopwatch _spectatorSw = new();
        private readonly Stopwatch _posSw = new();
        private readonly Stopwatch _firingRangeSw = new();
        private readonly Stopwatch _weaponsSw = new();

        private const int MAX_PLAYERS = 70;
        private const int MAX_PLAYERS_TRAINING = 10000;

        private readonly ConcurrentDictionary<string, Player> _players = new(StringComparer.OrdinalIgnoreCase);

        #region Getters
        public ReadOnlyDictionary<string, Player> Players { get; }
        private int MaxPlayers => Memory.Level.IsFiringRange ? MAX_PLAYERS_TRAINING : MAX_PLAYERS;
        private ulong SpectatorList => Memory.Game.Spectators;
        #endregion

        /// <summary>
        /// RegisteredPlayers List Constructor.
        /// </summary>
        public RegisteredPlayers()
        {
            this.Players = new(this._players);
            this._checkPlayersSw.Start();
            this._healthSw.Start();
            this._spectatorSw.Start();
            this._posSw.Start();
            this._weaponsSw.Start();

            if (Memory.Game.Level.IsFiringRange)
                this._firingRangeSw.Start();

            this.SetupPlayers();
        }

        #region Update List/Player Functions
        private void SetupPlayers()
        {
            var maxPlayers = this.MaxPlayers;
            var tmpList = new List<Player>();

            var scatterMap = new ScatterReadMap(maxPlayers);
            var round1 = scatterMap.AddRound();

            for (int i = 0; i < maxPlayers; i++)
            {
                var baseAddress = round1.AddEntry<ulong>(i, 0, Memory.ApexBase + Offsets.Miscellaneous.EntityList + (((uint)i + 1) << 5));
            }

            scatterMap.Execute();

            for (int i = 0; i < maxPlayers; i++)
            {
                if (!scatterMap.Results[i][0].TryGetResult<ulong>(out var playerBase) || !Memory.IsValidPtr(playerBase) || this._players.ContainsKey(playerBase.ToString()))
                    continue;

                tmpList.Add(new Player(playerBase, i));
            }

            this.ValidatePlayers(tmpList);
        }

        private void ValidatePlayers(List<Player> players)
        {
            var scatterMap = new ScatterReadMap(players.Count);
            var round1 = scatterMap.AddRound();

            for (int i = 0; i < players.Count; i++)
            {
                var playerBase = players[i].Base;
                var teamIDPtr = round1.AddEntry<int>(i, 0, playerBase + Offsets.BaseEntity.TeamID);
            }

            scatterMap.Execute();

            for (int i = 0; i < players.Count; i++)
            {
                var playerBase = players[i].Base;

                if (!scatterMap.Results[i][0].TryGetResult<int>(out var teamID))
                    continue;

                var className = Memory.ReadString(playerBase + Offsets.BaseEntity.Name);

                if (teamID == 97 || className == "player")
                    if (!this._players.TryGetValue(playerBase.ToString(), out var player))
                    {
                        Player newPlayer;

                        if (playerBase == Memory.LocalPlayer.Base)
                        {
                            newPlayer = Memory.LocalPlayer;
                            newPlayer.Index = players[i].Index;
                        }
                        else
                        {
                            newPlayer = new Player(playerBase, players[i].Index);
                            newPlayer.TeamID = teamID;
                            newPlayer.Class = (teamID == 97 ? "dynamic_dummie" : className);
                        }

                        this._players.TryAdd(playerBase.ToString(), newPlayer);
                    }
            }

            this.InitializePlayers();
        }

        private void InitializePlayers()
        {
            var players = this._players
                .Select(x => x.Value)
                .Where(x => string.IsNullOrEmpty(x.Legend))
                .OrderBy(x => x.TeamID)
                .ToArray();

            foreach(var player in players)
            {
                player.Setup();
            }
        }

        /// <summary>
        /// Updates the ConcurrentDictionary of 'Players'
        /// </summary>
        public void UpdateList()
        {
            if (this._checkPlayersSw.ElapsedMilliseconds < 5000)
                return;

            try
            {
                this.SetupPlayers();
            }
            catch (DMAShutdown)
            {
                throw;
            }
            catch (MatchEnded)
            {
                throw;
            }
            catch (Exception ex)
            {
                Program.Log($"CRITICAL ERROR - RegisteredPlayers Loop FAILED: {ex}");
            }
            finally
            {
                this._checkPlayersSw.Restart();
            }
        }

        /// <summary>
        /// Updates all 'Player' values (Position,health,direction,etc.)
        /// </summary>
        public void UpdateAllPlayers()
        {
            try
            {
                var players = this._players
                    .Select(x => x.Value)
                    .Where(x => x.IsActive)
                    .ToArray();

                if (players.Length == 0)
                    return;

                var checkPos = this._posSw.ElapsedMilliseconds > 10;
                var checkHealth = this._healthSw.ElapsedMilliseconds > 400;
                var checkSpectator = this._spectatorSw.ElapsedMilliseconds > 500;
                var checkWeapons = this._weaponsSw.ElapsedMilliseconds > 2000;
                var checkFiringRange = this._firingRangeSw.ElapsedMilliseconds > 5000;

                var scatterMap = new ScatterReadMap(players.Length);
                var round1 = scatterMap.AddRound();

                for (int i = 0; i < players.Length; i++)
                {
                    var player = players[i];

                    if (checkPos && !player.IsLocalPlayer)
                    {
                        var basePointer = round1.AddEntry<ulong>(i, 0, Memory.ApexBase + Offsets.Miscellaneous.EntityList + (((uint)player.Index + 1) << 5));
                    }

                    if (checkHealth)
                    {
                        var isDead = round1.AddEntry<bool>(i, 1, player.Base + Offsets.Player.LifeState);
                        var health = round1.AddEntry<int>(i, 2, player.Base + Offsets.Player.Health);
                        var maxHealth = round1.AddEntry<int>(i, 3, player.Base + Offsets.Player.MaxHealth);
                        var shields = round1.AddEntry<int>(i, 4, player.Base + Offsets.Player.Shield);
                        var maxShields = round1.AddEntry<int>(i, 5, player.Base + Offsets.Player.MaxShield);
                        var isKnocked = round1.AddEntry<byte>(i, 6, player.Base + Offsets.Player.BleedoutState);
                    }

                    if (checkPos)
                    {
                        var position = round1.AddEntry<Vector3>(i, 7, player.Base + Offsets.BaseEntity.Position);

                        if (player.IsPlayer || player.IsDummy)
                        {
                            if (player.IsLocalPlayer)
                                round1.AddEntry<Vector2>(i, 8, player.Base + Offsets.Player.ViewAngles);
                            else
                                round1.AddEntry<float>(i, 8, player.Base + Offsets.Player.Yaw);

                            var skyDiveStatus = round1.AddEntry<int>(i, 9, player.Base + Offsets.Player.SkyDiveStatus);
                        }
                    }

                    if (checkWeapons)
                    {
                        if (player.IsPlayer && !player.IsSkyDiving && !player.IsDead && !player.IsKnocked && player.Health > 0)
                        {
                            var weaponHandle = round1.AddEntry<ulong>(i, 10, player.Base + Offsets.Player.WeaponHandle);
                            var offWeaponHandle = round1.AddEntry<int>(i, 11, player.Base + Offsets.Player.OffWeaponHandle);
                        }
                    }

                    if (checkFiringRange && player.IsPlayer)
                    {
                        var legendModel = round1.AddEntry<ulong>(i, 12, player.Base + Offsets.Player.Model);
                    }

                    if (checkSpectator && player.IsPlayer)
                    {
                        var spectatorIndex = round1.AddEntry<int>(i, 13, this.SpectatorList + (uint)player.DataTable * 8 + Offsets.Spectator.Aux);
                    }
                }

                scatterMap.Execute();

                for (int i = 0; i < players.Length; i++)
                {
                    var player = players[i];

                    try
                    {
                        if (checkPos && !player.IsLocalPlayer)
                        {
                            if (!scatterMap.Results[i][0].TryGetResult<ulong>(out var pointerBase) || pointerBase == 0)
                            {
                                player.IsDead = true;
                                player.IsActive = false;

                                Program.Log($"{player.Name} disconnected");
                                continue;
                            }
                        }

                        if (checkHealth)
                        {
                            if (!scatterMap.Results[i][1].TryGetResult<bool>(out var isDead))
                                continue;

                            player.IsDead = isDead;
                        }

                        if (checkHealth)
                        {
                            if (!scatterMap.Results[i][2].TryGetResult<int>(out var health))
                                continue;
                            if (!scatterMap.Results[i][3].TryGetResult<int>(out var maxHealth))
                                continue;
                            if (!scatterMap.Results[i][4].TryGetResult<int>(out var shield))
                                continue;
                            if (!scatterMap.Results[i][5].TryGetResult<int>(out var maxShield))
                                continue;
                            if (!scatterMap.Results[i][6].TryGetResult<byte>(out var isKnocked))
                                continue;

                            player.Health = health;
                            player.MaxHealth = maxHealth;
                            player.Shield = shield;
                            player.MaxShield = maxShield;
                            player.IsKnocked = isKnocked > 0;
                        }

                        if (checkPos)
                        {
                               if (!scatterMap.Results[i][7].TryGetResult<Vector3>(out var position))
                                continue;

                            player.SetPosition(position);

                            if (player.IsPlayer || player.IsDummy)
                            {
                                if (player.IsLocalPlayer)
                                {
                                    if (!scatterMap.Results[i][8].TryGetResult<Vector2>(out var viewAngles))
                                        continue;

                                    player.SetRotation(viewAngles);
                                }
                                else
                                {
                                    if (!scatterMap.Results[i][8].TryGetResult<float>(out var yaw))
                                        continue;

                                    player.SetYaw(yaw);
                                }

                                if (!scatterMap.Results[i][9].TryGetResult<int>(out var skyDiveStatus))
                                    continue;

                                player.IsSkyDiving = skyDiveStatus > 0;
                            }
                        }

                        if (checkWeapons)
                        {
                            if (player.IsPlayer && !player.IsDead && !player.IsSkyDiving && !player.IsKnocked && player.Health > 0)
                            {
                                if (!scatterMap.Results[i][10].TryGetResult<ulong>(out var weaponHandle))
                                    continue;
                                if (!scatterMap.Results[i][11].TryGetResult<int>(out var offWeaponID))
                                    continue;
                                
                                var weaponEntityOffset = (weaponHandle & 0xFFFF);

                                try
                                {
                                    if (weaponEntityOffset < Memory.ApexBase)
                                    {
                                        var weaponEntity = Memory.ReadPtr(Memory.ApexBase + Offsets.Miscellaneous.EntityList + (weaponEntityOffset << 5));
                                        var weaponIndex = Memory.ReadValue<int>(weaponEntity + Offsets.Weapon.Index);

                                        player.HoldingGrenade = (offWeaponID == -251);
                                        player.SetActiveWeapon(weaponEntity, weaponIndex);
                                    }
                                }
                                catch
                                {
                                    player.HoldingGrenade = false;
                                    player.SetActiveWeapon(0, -999);
                                }
                            }
                        }

                        if (checkFiringRange && player.IsPlayer)
                        {
                            if (!scatterMap.Results[i][12].TryGetResult<ulong>(out var legendModelPtr))
                                continue;

                            player.Legend = Player.GetLegend(legendModelPtr);
                        }

                        if (checkSpectator && player.IsPlayer)
                        {
                            if (!scatterMap.Results[i][13].TryGetResult<int>(out var spectatorIndex))
                                continue;

                            if (spectatorIndex != -1 && player.IsDead)
                            {
                                try
                                {
                                    player.SpectatorBase = Memory.ReadPtr(Memory.ApexBase + Offsets.Miscellaneous.EntityList + (((uint)spectatorIndex & 0xFFFF) << 5));
                                }
                                catch { }
                            }   
                            else if (spectatorIndex == -1 && player.SpectatorBase != 0)
                                player.SpectatorBase = 0;
                        }
                    }
                    catch (MatchEnded ex)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                if (checkHealth)
                    this._healthSw.Restart();

                if (checkSpectator)
                    this._spectatorSw.Restart();

                if (checkPos)
                    this._posSw.Restart();

                if (checkFiringRange)
                    this._firingRangeSw.Restart();

                if (checkWeapons)
                    this._weaponsSw.Restart();
            }
            catch (MatchEnded ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                Program.Log($"CRITICAL ERROR - UpdateAllPlayers Loop FAILED: {ex}");
            }
        }
        #endregion
    }
}