using System.Text.Json.Serialization;
using System.Text.Json;

namespace apex_dma_radar
{
    public class Config
    {
        #region Json Properties
        [JsonPropertyName("defaultZoom")]
        public int DefaultZoom { get; set; }

        [JsonPropertyName("globalFont")]
        public int GlobalFont { get; set; }

        [JsonPropertyName("globalFontSize")]
        public int GlobalFontSize { get; set; }

        [JsonPropertyName("highlightLastAlive")]
        public bool HighlightLastAlive { get; set; }

        [JsonPropertyName("itemGlowSettings")]
        public Dictionary<ItemID, ItemGlowSettings> ItemGlowSettings { get; set; }

        [JsonPropertyName("loggingEnabled")]
        public bool LoggingEnabled { get; set; }

        [JsonPropertyName("masterSwitch")]
        public bool MasterSwitch { get; set; }

        [JsonPropertyName("maxDistance")]
        public float MaxDistance { get; set; }

        [JsonPropertyName("paintColors")]
        public Dictionary<string, PaintColor.Colors> PaintColors { get; set; }

        [JsonPropertyName("playerGlowSettings")]
        public PlayerGlowSettings PlayerGlowSettings { get; set; }

        [JsonPropertyName("playerInformationSettings")]
        public Dictionary<string, PlayerInformationSettings> PlayerInformationSettings { get; set; }

        [JsonPropertyName("radarStats")]
        public bool RadarStats { get; set; }

        [JsonPropertyName("spectators")]
        public bool Spectators { get; set; }

        [JsonPropertyName("uiScale")]
        public int UIScale { get; set; }

        [JsonPropertyName("zoomSensitivity")]
        public int ZoomSensitivity { get; set; }

        [JsonPropertyName("viewModelGlowSettings")]
        public ViewModelGlowSettings ViewModelGlowSettings { get; set; }

        [JsonPropertyName("vsync")]
        public bool VSync { get; set; }
        #endregion

        #region Json Ignore
        [JsonIgnore]
        public Dictionary<string, PaintColor.Colors> DefaultPaintColors = new Dictionary<string, PaintColor.Colors>()
        {
            // Players
            ["LocalPlayer"] = new PaintColor.Colors { A = 255, R = 255, G = 255, B = 255 },
            ["Teammate"] = new PaintColor.Colors { A = 255, R = 50, G = 205, B = 50 },
            ["TeamHover"] = new PaintColor.Colors { A = 255, R = 125, G = 252, B = 50 },
            ["MixtapeEnemy"] = new PaintColor.Colors { A = 255, R = 255, G = 50, B = 50 },
            ["LastAlive"] = new PaintColor.Colors { A = 255, R = 255, G = 50, B = 50 },

            // Player Glow
            ["PlayerColorGlow"] = new PaintColor.Colors { A = 255, R = 0, G = 255, B = 0 },
            ["PlayerKnockedGlow"] = new PaintColor.Colors { A = 255, R = 0, G = 64, B = 0 },
            ["PlayerCrackedShieldGlow"] = new PaintColor.Colors { A = 255, R = 160, G = 80, B = 0 },
            ["PlayerGreyShieldGlow"] = new PaintColor.Colors { A = 255, R = 247, G = 247, B = 247 },
            ["PlayerBlueShieldGlow"] = new PaintColor.Colors { A = 255, R = 39, G = 178, B = 255 },
            ["PlayerPurpleShieldGlow"] = new PaintColor.Colors { A = 255, R = 206, G = 59, B = 255 },
            ["PlayerRedShieldGlow"] = new PaintColor.Colors { A = 255, R = 219, G = 0, B = 0 },

            // Item Glow
            ["ItemRedTierGlow"] = new PaintColor.Colors { A = 255, R = 255, G = 78, B = 29 },
            ["ItemGoldTierGlow"] = new PaintColor.Colors { A = 255, R = 255, G = 205, B = 60 },
            ["ItemPurpleTierGlow"] = new PaintColor.Colors { A = 255, R = 125, G = 0, B = 255 },
            ["ItemBlueTierGlow"] = new PaintColor.Colors { A = 255, R = 30, G = 144, B = 255 },
            ["ItemGreyTierGlow"] = new PaintColor.Colors { A = 255, R = 192, G = 192, B = 192 },
            ["ItemWeaponGlow"] = new PaintColor.Colors { A = 255, R = 140, G = 140, B = 140 },
            ["ItemAmmoBoxGlow"] = new PaintColor.Colors { A = 255, R = 25, G = 25, B = 25 },

            // Other
            ["TextOutline"] = new PaintColor.Colors { A = 255, R = 0, G = 0, B = 0 },
            ["Primary"] = new PaintColor.Colors { A = 255, R = 80, G = 80, B = 80 },
            ["PrimaryDark"] = new PaintColor.Colors { A = 255, R = 50, G = 50, B = 50 },
            ["PrimaryLight"] = new PaintColor.Colors { A = 255, R = 130, G = 130, B = 130 },
            ["Accent"] = new PaintColor.Colors { A = 255, R = 255, G = 128, B = 0 }
        };

        [JsonIgnore]
        public Dictionary<string, PlayerInformationSettings> DefaultPlayerInformationSettings = new Dictionary<string, PlayerInformationSettings>()
        {
            ["Dummy"] = new PlayerInformationSettings(true, true,true, true, 15, 255, 0, 13, false, false, false, false, false, false, false, false, false, 0, 13),
            ["Player"] = new PlayerInformationSettings(true, true,true, true, 15, 255, 0, 13, false, false, false, false, false, false, false, false, false, 0, 13),
            ["Teammate"] = new PlayerInformationSettings(true, true, true, true, 500, 255, 0, 13, false, false, false, false, false, false, false, false, false, 0, 13),
            ["LocalPlayer"] = new PlayerInformationSettings(true, true, true, true, 500, 255, 0, 13, false, false, false, false, false, false, false, false, false, 0, 13)
        };

        [JsonIgnore]
        public PlayerGlowSettings DefaultPlayerGlowSettings = new PlayerGlowSettings
        {
            Enabled = false,
            ShieldBased = false,
            InsideFunction = 2,
            OutlineFunction = 125,
            OutlineRadius = 32,
            Brightness = 1
        };

        public Dictionary<ItemID, ItemGlowSettings> DefaultItemGlowSettings = new Dictionary<ItemID, ItemGlowSettings>()
        {
            [ItemID.Red] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Gold] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Purple] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Blue] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Grey] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Weapons] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
            [ItemID.Ammo] = new ItemGlowSettings(false, false, 2, 125, 32, 1),
        };

        public ViewModelGlowSettings DefaultViewModelGlowSettings = new ViewModelGlowSettings
        {
            Enabled = false,
            Effect = 1
        };

        [JsonIgnore]
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        [JsonIgnore]
        private static readonly object _lock = new();

        [JsonIgnore]
        public ParallelOptions ParallelOptions
        {
            get; set;
        }

        [JsonIgnore]
        private const string SettingsDirectory = "Configuration\\";
        #endregion

        public Config()
        {
            DefaultZoom = 100;
            GlobalFont = 0;
            GlobalFontSize = 13;
            HighlightLastAlive = false;
            ItemGlowSettings = DefaultItemGlowSettings;
            LoggingEnabled = false;
            MasterSwitch = false;
            MaxDistance = 1000;
            PaintColors = DefaultPaintColors;
            ParallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            PlayerGlowSettings = DefaultPlayerGlowSettings;
            PlayerInformationSettings = DefaultPlayerInformationSettings;
            RadarStats = false;
            Spectators = false;
            UIScale = 100;
            ZoomSensitivity = 25;
            ViewModelGlowSettings = DefaultViewModelGlowSettings;
            VSync = true;
        }

        /// <summary>
        /// Attempt to load Config.json
        /// </summary>
        /// <param name="config">'Config' instance to populate.</param>
        /// <returns></returns>
        public static bool TryLoadConfig(out Config config)
        {
            lock (_lock)
            {
                if (!Directory.Exists(SettingsDirectory))
                    Directory.CreateDirectory(SettingsDirectory);

                try
                {
                    if (!File.Exists($"{SettingsDirectory}Settings.json"))
                        throw new FileNotFoundException("Settings.json does not exist!");

                    var json = File.ReadAllText($"{SettingsDirectory}Settings.json");

                    config = JsonSerializer.Deserialize<Config>(json);
                    return true;
                }
                catch (Exception ex)
                {
                    Program.Log($"TryLoadConfig - {ex.Message}\n{ex.StackTrace}");
                    config = null;
                    return false;
                }
            }
        }
        /// <summary>
        /// Save to Config.json
        /// </summary>
        /// <param name="config">'Config' instance</param>
        public static void SaveConfig(Config config)
        {
            lock (_lock)
            {
                if (!Directory.Exists(SettingsDirectory))
                    Directory.CreateDirectory(SettingsDirectory);

                var json = JsonSerializer.Serialize<Config>(config, _jsonOptions);
                File.WriteAllText($"{SettingsDirectory}Settings.json", json);
            }
        }
    }
}
