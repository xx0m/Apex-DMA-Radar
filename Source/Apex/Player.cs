using System.Numerics;

namespace apex_dma_radar
{
    public class Player
    {
        #region PlayerProperties
        private Vector3 _pos = new Vector3(0, 0, 0);
        public static Vector3 DEFAULT_POS = new Vector3(0, 0, 0);
        private readonly object _posLock = new();
        public ulong Base { get; set; }

        public Vector2 ZoomedPosition { get; set; } = new();
        public Vector2 Rotation { get; private set; } = new Vector2(0, 0);
        public float Yaw { get; private set; } = 0;
        public Vector3 Position
        {
            get
            {
                lock (_posLock)
                    return _pos;
            }
            private set
            {
                lock (_posLock)
                    _pos = value;
            }
        }

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public bool IsDead { get; set; }
        public int TeamID { get; set; }
        public int SquadID { get; set; }
        public bool IsLocalPlayer { get; }
        public string Name { get; set; }
        public string Class { get; set; }
        public bool IsKnocked { get; set; }
        public int Level { get; set; }
        public int DataTable { get; set; }
        public bool IsActive { get; set; }
        public ulong SpectatorBase { get; set; }
        public string Legend { get; set; }
        public PlayerType Type { get; set; }
        public float LastTimeAimedAtPrevious { get; set; }
        public int Index { get; set; }
        public bool IsSkyDiving { get; set; }
        public bool IsVisible { get; set; }
        public bool HoldingGrenade { get; set; }
        public string ActiveWeapon { get; set; }

        public int GlowEnabled { get; set; }
        public int GlowThroughWall { get; set; }
        public int HighlightID { get; set; }

        public ulong WeaponEntity { get; set; }
        #endregion

        #region Constructor
        public Player(ulong playerBase, int index, bool isLocalPlayer = false)
        {
            this.Base = playerBase;
            this.Index = index;
            this.IsLocalPlayer = isLocalPlayer;
        }
        #endregion

        #region Getters/Setters
        public bool IsPlayer => this.Type == PlayerType.Player || this.Type == PlayerType.LocalPlayer || this.Type == PlayerType.Teammate;
        public bool IsDummy => this.Type == PlayerType.Dummy;
        public bool IsTeammate => (Memory.Level.IsInMixtape && Memory.LocalPlayer.SquadID == -1) ? (this.TeamID & 1) == (Memory.LocalPlayer.TeamID & 1) : (this.TeamID == Memory.LocalPlayer.TeamID);
        public bool IsHostile => !this.IsTeammate;
        public bool IsFriendlyActive => this.IsTeammate && this.IsActive;
        public bool IsHostileActive => !this.IsTeammate && this.IsActive;
        public bool IsSpectatingLocalPlayer => this.SpectatorBase == Memory.LocalPlayer.Base;
        public bool IsSpectatedByLocalPlayer => this.Base == Memory.LocalPlayer.SpectatorBase;
        public bool IsLastAliveInSquad => TeamManager.IsLastAlive(this);
        public bool IsRespawning => !this.IsDead && this.Position.Z >= 11000;
        public int ShieldLevel => (this.MaxShield / 25) - (this.MaxShield > 0 ? 1 : 0);

        public void SetYaw(float yaw)
        {
            this.Yaw = (-yaw) % 360;
        }

        public void SetRotation(Vector2 rotation)
        {
            if (float.IsNaN(rotation.X) || float.IsNaN(rotation.Y))
                return;

            var x = (-rotation.Y + 360) % 360;
            var y = (rotation.X) % 360;

            rotation.X = x;
            rotation.Y = y;

            this.Rotation = rotation;
        }

        public void SetPosition(Vector3 position)
        {
            this.Position = position;
        }

        public void SetActiveWeapon(ulong weaponEntity, int weaponIndex)
        {
            if (Game.WeaponMap.TryGetValue((WeaponID)weaponIndex, out var weapon))
                this.ActiveWeapon = weapon;
            else
                this.ActiveWeapon = Game.WeaponMap[WeaponID.Melee]; // melee

            this.WeaponEntity = weaponEntity;
        }
        #endregion

        #region Methods
        public void Setup()
        {
            var scatterReadMap = new ScatterReadMap(1);
            var round1 = scatterReadMap.AddRound();

            var isDeadPtr = round1.AddEntry<bool>(0, 0, this.Base + Offsets.Player.LifeState);
            var healthPtr = round1.AddEntry<int>(0, 1, this.Base + Offsets.Player.Health);
            var dataTablePtr = round1.AddEntry<int>(0, 2, this.Base + Offsets.NameList.Index);
            var modelPtr = round1.AddEntry<ulong>(0, 3, this.Base + Offsets.Player.Model);

            if (this.IsPlayer)
            {
                var xpPtr = round1.AddEntry<int>(0, 4, this.Base + Offsets.Player.XP);
            }

            if (Memory.Level.IsInMixtape)
            {
                var squadIDPtr = round1.AddEntry<int>(0, 5, this.Base + Offsets.BaseEntity.SquadID);
            }

            scatterReadMap.Execute();

            if (!scatterReadMap.Results[0][0].TryGetResult<bool>(out var isDead))
                return;
            if (!scatterReadMap.Results[0][1].TryGetResult<int>(out var health))
                return;
            if (!scatterReadMap.Results[0][2].TryGetResult<int>(out var dataTable))
                return;
            if (!scatterReadMap.Results[0][3].TryGetResult<ulong>(out var model))
                return;

            this.IsDead = isDead;
            this.Health = health;
            this.DataTable = dataTable;
            this.Legend = Player.GetLegend(model);

            if (!string.IsNullOrEmpty(this.Legend))
                this.IsActive = true;
            else
                return;

            if (this.IsPlayer)
            {
                if (!scatterReadMap.Results[0][4].TryGetResult<int>(out var xp))
                    return;

                this.Level = LevelCalculator.GetLevel(xp);
            }

            if (Memory.Level.IsInMixtape)
            {
                if (!scatterReadMap.Results[0][5].TryGetResult<int>(out var squadID))
                    return;

                this.SquadID = squadID;
            }

            this.Type = this.GetPlayerType();
            this.Name = this.GetName();

            TeamManager.AddTeamMember(this);
        }

        private string GetName()
        {
            if (this.IsDummy)
                return $"dummy #{this.Index}";
            else
            {
                try
                {
                    var namePtr = Memory.ReadPtr(Memory.ApexBase + Offsets.Miscellaneous.NameList + (((uint)this.DataTable - 1) * 24));
                    return Memory.ReadString(namePtr);
                }
                catch { }
            }

            this.IsActive = false;

            return "n/a";
        }

        private PlayerType GetPlayerType()
        {
            if (this.IsLocalPlayer)
                return PlayerType.LocalPlayer;
            else if (this.IsTeammate)
                return PlayerType.Teammate;
            else if (this.Class == "player")
                return PlayerType.Player;
            else
                return PlayerType.Dummy;
        }

        public static string GetLegend(ulong model)
        {
            var modelName = Memory.ReadString(model);

            foreach (var kvp in Game.LegendMap)
            {
                if (modelName.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                    return kvp.Value;
            }

            return null;
        }

        public static bool IsSpectatingPlayer(Player player, out Player foundPlayer)
        {
            if (player.SpectatorBase != 0 && Memory.Game.Players.TryGetValue(player.SpectatorBase.ToString(), out foundPlayer))
                return true;

            foundPlayer = null;
            return false;
        }

        public bool ActiveCheck()
        {
            return !this.IsDead && (this.Health >= 0 && this.Health <= 100) && (this.MaxHealth >= 0 && this.MaxHealth <= 100) &&
                    (this.Shield >= 0 && this.Shield <= 200) && (this.MaxShield >= 0 && this.MaxShield <= 200) &&
                    (this.ShieldLevel >= 2 && this.ShieldLevel <= 5);
        }
        #endregion
    }
}
