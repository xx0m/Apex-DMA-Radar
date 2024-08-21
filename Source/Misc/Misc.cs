using System.Diagnostics;

namespace apex_dma_radar
{
    #region Program Classes
    /// <summary>
    /// Custom Debug Stopwatch class to measure performance.
    /// </summary>
    public class DebugStopwatch
    {
        private readonly Stopwatch _sw;
        private readonly string _name;

        /// <summary>
        /// Constructor. Starts stopwatch.
        /// </summary>
        /// <param name="name">(Optional) Name of stopwatch.</param>
        public DebugStopwatch(string name = null)
        {
            _name = name;
            _sw = new Stopwatch();
            _sw.Start();
        }

        /// <summary>
        /// End stopwatch and display result to Debug Output.
        /// </summary>
        public void Stop()
        {
            _sw.Stop();
            TimeSpan ts = _sw.Elapsed;
            Debug.WriteLine($"{_name} Stopwatch Runtime: {ts.Ticks} ticks");
        }
    }

    public static class LevelCalculator
    {
        private const int MIN_XP = 0;
        private const int XP_FOR_LEVEL_2 = 100;
        private const int MAX_DEFINED_LEVEL = 56;
        private const int XP_PER_LEVEL_AFTER_MAX = 18000;

        private static readonly int[] LevelThresholds = new int[]
        {
            2750, 6650, 11400, 17000, 23350, 30450, 38300, 46450, 55050,
            64100, 73600, 83550, 93950, 104800, 116100, 127850, 140050, 152400, 164900,
            177550, 190350, 203300, 216400, 229650, 243050, 256600, 270300, 284150, 298150,
            312300, 326600, 341050, 355650, 370400, 385300, 400350, 415550, 430900, 446400,
            462050, 477850, 493800, 509900, 526150, 542550, 559100, 575800, 592650, 609650,
            626800, 644100, 661550, 679150, 696900, 714800
        };

        public static int GetLevel(int xp)
        {
            if (xp < MIN_XP)
                return 0;

            if (xp < XP_FOR_LEVEL_2)
                return 1;

            var level = LevelThresholds.TakeWhile(threshold => xp >= threshold).Count() + 2;

            if (level <= MAX_DEFINED_LEVEL)
                return level;

            var xpAboveMaxDefined = xp - LevelThresholds[LevelThresholds.Length - 1];
            return MAX_DEFINED_LEVEL + (xpAboveMaxDefined / XP_PER_LEVEL_AFTER_MAX) + 1;
        }
    }

    public class PlayerInformationSettings
    {
        public bool Name { get; set; }
        public bool Height { get; set; }
        public bool Distance { get; set; }
        public bool Aimline { get; set; }
        public int AimlineLength { get; set; }
        public int AimlineOpacity { get; set; }
        public int Font { get; set; }
        public int FontSize { get; set; }
        public bool Flags { get; set; }
        public bool ActiveWeapon { get; set; }
        public bool XPLevel { get; set; }
        public bool ShieldLevel { get; set; }
        public bool Health { get; set; }
        public bool Shield { get; set; }
        public bool Legend { get; set; }
        public bool LastAlive { get; set; }
        public bool Knocked { get; set; }
        public int FlagsFont { get; set; }
        public int FlagsFontSize { get; set; }

        public PlayerInformationSettings(
            bool name, bool height, bool distance, bool aimline,
            int aimlineLength, int aimlineOpacity, int font, int fontSize,
            bool flags, bool activeWeapon, bool xpLevel, bool shieldLevel, bool health, bool shield,
            bool legend, bool lastAlive, bool knocked, int flagsFont, int flagsFontSize)
        {
            this.Name = name;
            this.Height = height;
            this.Distance = distance;
            this.Aimline = aimline;
            this.AimlineLength = aimlineLength;
            this.AimlineOpacity = aimlineOpacity;
            this.Font = font;
            this.FontSize = fontSize;
            this.Flags = flags;
            this.ActiveWeapon = activeWeapon;
            this.XPLevel = xpLevel;
            this.ShieldLevel = shieldLevel;
            this.Health = health;
            this.Shield = shield;
            this.Legend = legend;
            this.LastAlive = lastAlive;
            this.Knocked = knocked;
            this.FlagsFont = flagsFont;
            this.FlagsFontSize = flagsFontSize;
        }
    }

    public struct AimlineSettings
    {
        public bool Enabled;
        public int Length;
        public int Opacity;
    }
    #endregion

    #region Apex Enums
    public enum PlayerType
    {
        LocalPlayer,
        Teammate,
        Player,
        Dummy
    }

    public enum ItemID
    {
        Red = 42,
        Gold = 15,
        Purple = 47,
        Blue = 54,
        Grey = 65,
        Weapons = 9,
        Ammo = 58
    }

    public enum WeaponID
    {
        R301 = 0,
        Sentinel = 1,
        Bocek = 2,
        Rampage = 6,
        Sheila = 14,
        Alternator = 84,
        RE45 = 85,
        ChargeRifle = 87,
        Devotion = 89,
        Longbow = 90,
        Havoc = 91,
        EVA8 = 92,
        Flatline = 94,
        G7 = 95,
        Hemlock = 96,
        Kraber = 98,
        LStar = 99,
        Mastiff = 101,
        Mozamique = 102,
        Prowler = 107,
        Peacekeeper = 109,
        R99 = 111,
        P2020 = 112,
        Spitfire = 113,
        TripleTake = 114,
        Wingman = 115,
        Volt = 117,
        Repeater3030 = 118,
        CAR = 119,
        Nemesis = 120,
        Melee = 121,
        ThrowingKnife = 176
    }
    #endregion
}
