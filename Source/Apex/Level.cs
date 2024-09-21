using System.Diagnostics;

namespace apex_dma_radar
{
    public class Level
    {
        private ulong _address { get; }
        private ulong _gamemodeAddress { get; }
        private readonly Stopwatch _swLevelRefresh = new();

        private static List<string> MixTapeModes = ["freedm", "control", "arenas"];

        public string Name { get; set; }
        public string GameMode { get; set; }

        public bool IsPlayable => !string.IsNullOrEmpty(this.Name) && this.Name != "mp_lobby" && this.Name != "Unknown";
        public bool IsFiringRange => this.Name == "mp_rr_canyonlands_staging_mu1";
        public bool IsInMixtape => Level.MixTapeModes.Contains(this.GameMode);
        public bool IsSquadBased => this.IsInMixtape && Memory.LocalPlayer.SquadID == -1;

        public Level(ulong levelName, ulong gamemode)
        {
            this._address = levelName;
            this._gamemodeAddress = Memory.ReadPtr(gamemode);
            this.UpdateLevel();
            this.UpdateGamemode();

            this._swLevelRefresh.Start();
        }

        public void UpdateLevel()
        {
            this.Name = Memory.ReadString(this._address);
        }

        public void UpdateGamemode()
        {
            this.GameMode = Memory.ReadString(this._gamemodeAddress);
        }

        public bool CheckLevel()
        {
            if (_swLevelRefresh.ElapsedMilliseconds > 125)
            {
                this.UpdateLevel();
                this.UpdateGamemode();
                this._swLevelRefresh.Restart();
            }

            return this.IsPlayable;
        }
    }
}
