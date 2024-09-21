using System.Buffers;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace apex_dma_radar
{
    public struct GlowMode
    {
        public byte InsideFunction { get; set; }
        public byte OutlineFunction { get; set;}
        public byte OutlineRadius { get; set; }
        public byte Brightness { get; set; }
    }

    public struct GlowColor
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
    }

    public class PlayerGlowSettings
    {
        public bool Enabled { get; set; }
        public bool ShieldBased { get; set; }
        public byte InsideFunction { get; set; }
        public byte OutlineFunction { get; set; }
        public byte OutlineRadius { get; set; }
        public byte Brightness { get; set; }

        [JsonConstructor]
        public PlayerGlowSettings() { }
    }

    public class ItemGlowSettings
    {
        public bool Enabled { get; set; }
        public bool CustomColor { get; set; }
        public byte InsideFunction { get; set; }
        public byte OutlineFunction { get; set; }
        public byte OutlineRadius { get; set; }
        public byte Brightness { get; set; }

        [JsonConstructor]
        public ItemGlowSettings(bool enabled, bool customColor, byte insideFunction, byte outlineFunction, byte outlineRadius, byte brightness)
        {
            this.Enabled = enabled;
            this.CustomColor = customColor;
            this.InsideFunction = insideFunction;
            this.OutlineFunction = outlineFunction;
            this.OutlineRadius = outlineRadius;
            this.Brightness = brightness;
        }
    }

    public class ViewModelGlowSettings
    {
        public bool Enabled { get; set; }
        public byte Effect { get; set; }

        [JsonConstructor]
        public ViewModelGlowSettings() { }
    }

    public class GlowManager
    {
        private bool _playerGlowApplied = false;
        private bool _viewModelGlowApplied = false;
        private bool _itemGlowApplied = false;
        private ulong _highlightSettings;
        private readonly Stopwatch _sw = new();
        private readonly Config _config = Program.Config;
        private PlayerGlowSettings _playerGlowSettings => this._config.PlayerGlowSettings;
        private Dictionary<ItemID, ItemGlowSettings> _itemGlowSettings => this._config.ItemGlowSettings;
        private ViewModelGlowSettings _viewModelGlowSettings => this._config.ViewModelGlowSettings;
        private Dictionary<string, PaintColor.Colors> _colors => this._config.PaintColors;
        private List<Player> _players => Memory.Players.Select(x => x.Value).Where(x => x.IsActive && !x.IsDead && !x.IsLocalPlayer && !x.IsTeammate).ToList();

        private static Dictionary<ItemID, GlowMode> DEFAULT_ITEM_GLOW_MODES = new Dictionary<ItemID, GlowMode>()
        {
            [ItemID.Red] = new GlowMode { InsideFunction = 135, OutlineFunction = 135, OutlineRadius = 32, Brightness = 64 },
            [ItemID.Gold] = new GlowMode { InsideFunction = 135, OutlineFunction = 135, OutlineRadius = 32, Brightness = 64 },
            [ItemID.Purple] = new GlowMode { InsideFunction = 135, OutlineFunction = 135, OutlineRadius = 32, Brightness = 64 },
            [ItemID.Blue] = new GlowMode { InsideFunction = 135, OutlineFunction = 135, OutlineRadius = 32, Brightness = 64 },
            [ItemID.Grey] = new GlowMode { InsideFunction = 135, OutlineFunction = 135, OutlineRadius = 32, Brightness = 64 },
            [ItemID.Weapons] = new GlowMode { InsideFunction = 0, OutlineFunction = 110, OutlineRadius = 255, Brightness = 64 },
            [ItemID.Ammo] = new GlowMode { InsideFunction = 0, OutlineFunction = 129, OutlineRadius = 32, Brightness = 64 }
        };

        private static Dictionary<ItemID, GlowColor> DEFAULT_ITEM_GLOW_COLORS = new Dictionary<ItemID, GlowColor>()
        {
            [ItemID.Red] = new GlowColor { R = 1, G = 0.305882365f, B = 0.1137255f },
            [ItemID.Gold] = new GlowColor { R = 1, G = 0.80392164f, B = 0.235294133f },
            [ItemID.Purple] = new GlowColor { R = 0.4901961f, G = 0, B = 1 },
            [ItemID.Blue] = new GlowColor { R = 0.117647067f, G = 0.5647059f, B = 1 },
            [ItemID.Grey] = new GlowColor { R = 0.752941251f, G = 0.752941251f, B = 0.752941251f },
            [ItemID.Weapons] = new GlowColor { R = 0.55f, G = 0.55f, B = 0.55f },
            [ItemID.Ammo] = new GlowColor { R = 0.1f, G = 0.1f, B = 0.1f }
        };

        private const int GLOW_THROUGH_WALL = 1;
        private const int GLOW_ENABLED = 1;

        public bool RefreshViewModel { get; set; }
        public bool RefreshItems { get; set; }

        public bool IsRunning => this._sw.IsRunning;
        public ulong HighlightSettings => _highlightSettings;

        public GlowManager(ulong highlightSettings)
        {
            this._highlightSettings = Memory.ReadPtr(highlightSettings);
        }

        public void Start()
        {
            this._sw.Start();
        }

        public void Refresh()
        {
            if (this._sw.ElapsedMilliseconds < 400)
                return;

            this._sw.Restart();

            if (!Memory.InGame || !this._config.MasterSwitch)
                return;

            var playerGlowSettings = this._playerGlowSettings;
            var itemGlowSettings = this._itemGlowSettings;
            var viewModelSettings = this._viewModelGlowSettings;

            var enabledItemsCount = itemGlowSettings.
                                            Where(x => x.Value.Enabled).
                                            Count();

            var entries = new List<IScatterWriteEntry>();

            if (playerGlowSettings.Enabled)
            {
                var scatterMap = new ScatterReadMap(this._players.Count);
                var round1 = scatterMap.AddRound();

                for (int i = 0; i < this._players.Count; i++)
                {
                    var player = this._players[i];
                    var pBase = player.Base;

                    if (!player.IsActive)
                        continue;

                    round1.AddEntry<int>(i, 0, pBase + Offsets.Glow.ThroughWall);
                    round1.AddEntry<int>(i, 1, pBase + Offsets.Glow.Enable);
                }

                scatterMap.Execute();

                for (int i = 0; i < this._players.Count; i++)
                {
                    var player = this._players[i];
                    var pBase = player.Base;

                    if (!player.IsActive)
                        continue;

                    if (scatterMap.Results[i][0].TryGetResult<int>(out var glowThroughWall))
                    {
                        player.GlowThroughWall = glowThroughWall;

                        if (player.GlowThroughWall != GLOW_THROUGH_WALL)
                            entries.Add(new ScatterWriteDataEntry<int>(pBase + Offsets.Glow.ThroughWall, GLOW_THROUGH_WALL));
                    }

                    if (scatterMap.Results[i][1].TryGetResult<int>(out var glowEnabled))
                    {
                        player.GlowEnabled = glowEnabled;

                        if (player.GlowEnabled != GLOW_ENABLED)
                            entries.Add(new ScatterWriteDataEntry<int>(pBase + Offsets.Glow.Enable, GLOW_ENABLED));
                    }

                    if (player.GlowEnabled == GLOW_ENABLED && player.GlowThroughWall == GLOW_THROUGH_WALL)
                        this.SetPlayerGlow(player, ref entries);
                }

                this._playerGlowApplied = true;
            }
            else if (this._playerGlowApplied && !playerGlowSettings.Enabled)
            {
                foreach(var player in this._players)
                {
                    this.SetPlayerGlow(player, ref entries, true);
                }

                this._playerGlowApplied = false;
            }

            if ((!this._itemGlowApplied && enabledItemsCount > 0) || this.RefreshItems)
            {
                foreach (var item in itemGlowSettings)
                {
                    this.SetItemGlow(item.Key, ref entries, !item.Value.Enabled);
                }

                this._itemGlowApplied = true;
                this.RefreshItems = false;
            }
            else if (this._itemGlowApplied && enabledItemsCount == 0)
            {
                foreach (var item in itemGlowSettings)
                {
                    this.SetItemGlow(item.Key, ref entries, true);
                }

                this._itemGlowApplied = false;
            }

            if ((!this._viewModelGlowApplied && viewModelSettings.Enabled && !Memory.LocalPlayer.IsDead) || this.RefreshViewModel)
            {
                var activeWeapon = this.GetLocalPlayerWeaponEntity();

                if (activeWeapon != 0)
                {
                    entries.Add(new ScatterWriteDataEntry<int>(activeWeapon + Offsets.Glow.Highlight_ID, viewModelSettings.Effect));
                    this._viewModelGlowApplied = true;
                    this.RefreshViewModel = false;
                }
            }
            else if (this._viewModelGlowApplied && !viewModelSettings.Enabled && !Memory.LocalPlayer.IsDead)
            {
                var activeWeapon = this.GetLocalPlayerWeaponEntity();

                if (activeWeapon != 0)
                {
                    entries.Add(new ScatterWriteDataEntry<int>(activeWeapon + Offsets.Glow.Highlight_ID, 7));
                    this._viewModelGlowApplied = false;
                    this.RefreshViewModel = false;
                }
            }

            if (entries.Any() && Memory.Level.IsPlayable)
                Memory.WriteScatter(entries);
        }

        private ulong GetLocalPlayerWeaponEntity()
        {
            var weaponID = (Memory.ReadPtr(Memory.LocalPlayer.Base + Offsets.Player.ViewModel) & 0xFFFF);
            return Memory.ReadPtr(Memory.ApexBase + Offsets.Miscellaneous.EntityList + (weaponID << 5));
        }

        private GlowMode GetPlayerGlowSettings(bool revert = false)
        {
            return new GlowMode
            {
                InsideFunction = (byte)(revert ? 0 : this._playerGlowSettings.InsideFunction),
                OutlineFunction = (byte)(revert ? 0 : this._playerGlowSettings.OutlineFunction),
                OutlineRadius = (byte)(revert ? 0 : this._playerGlowSettings.OutlineRadius),
                Brightness = 64
            };
        }

        private GlowMode GetItemGlowSettings(ItemID item, bool revert = false)
        {
            return new GlowMode
            {
                InsideFunction = (byte)(revert ? DEFAULT_ITEM_GLOW_MODES[item].InsideFunction : this._itemGlowSettings[item].InsideFunction),
                OutlineFunction = (byte)(revert ? DEFAULT_ITEM_GLOW_MODES[item].OutlineFunction : this._itemGlowSettings[item].OutlineFunction),
                OutlineRadius = (byte)(revert ? DEFAULT_ITEM_GLOW_MODES[item].OutlineRadius : this._itemGlowSettings[item].OutlineRadius),
                Brightness = (byte)(revert ? DEFAULT_ITEM_GLOW_MODES[item].Brightness : 64)
            };
        }

        private bool IsSameGlowMode(GlowMode oldGlow, GlowMode newGlow)
        {
            return (oldGlow.InsideFunction == newGlow.InsideFunction &&
                    oldGlow.OutlineFunction == newGlow.OutlineFunction &&
                    oldGlow.OutlineRadius == newGlow.OutlineRadius &&
                    oldGlow.Brightness == newGlow.Brightness);
        }

        private bool IsSameGlowColor(GlowColor oldColor, GlowColor newColor)
        {
            return (oldColor.R == newColor.R &&
                    oldColor.G == newColor.G &&
                    oldColor.B == newColor.B);
        }

        private (GlowColor, uint settingIndex) GetPlayerGlowColor(Player player)
        {
            PaintColor.Colors color;
            var settingIndex = 64;
            var brightness = this._playerGlowSettings.Brightness;

            if (player.IsKnocked)
            {
                settingIndex = 63;
                color = _colors["PlayerKnockedGlow"];
            }
            else if (this._playerGlowSettings.ShieldBased)
            {
                var totalHealth = player.Health + player.Shield;

                if (totalHealth <= 100)
                {
                    settingIndex = 70;
                    color = _colors["PlayerCrackedShieldGlow"];
                }
                else if (totalHealth <= 150)
                {
                    settingIndex = 69;
                    color = _colors["PlayerGreyShieldGlow"];
                }
                else if (totalHealth <= 175)
                {
                    settingIndex = 68;
                    color = _colors["PlayerBlueShieldGlow"];
                }
                else if (totalHealth <= 200)
                {
                    settingIndex = 67;
                    color = _colors["PlayerPurpleShieldGlow"];
                }
                else
                {
                    settingIndex = 66;
                    color = _colors["PlayerRedShieldGlow"];
                }
            }
            else
            {
                settingIndex = 64;
                color = _colors["PlayerColorGlow"];
            }

            var rgb = new GlowColor
            {
                R = ((float)color.R / 255.0f * brightness),
                G = ((float)color.G / 255.0f * brightness),
                B = ((float)color.B / 255.0f * brightness)
            };

            return (rgb, (uint)settingIndex);
        }

        private GlowColor GetItemGlowColor(ItemID item, bool revert = false)
        {
            GlowColor color;
            var brightness = this._itemGlowSettings[item].Brightness;

            if (!this._itemGlowSettings[item].CustomColor || revert)
            {
                color = DEFAULT_ITEM_GLOW_COLORS[item];
            }
            else
            {
                PaintColor.Colors col;

                switch (item)
                {
                    case ItemID.Red:
                        col = this._colors["ItemRedTierGlow"];
                        break;
                    case ItemID.Gold:
                        col = this._colors["ItemGoldTierGlow"];
                        break;
                    case ItemID.Purple:
                        col = this._colors["ItemPurpleTierGlow"];
                        break;
                    case ItemID.Blue:
                        col = this._colors["ItemBlueTierGlow"];
                        break;
                    case ItemID.Grey:
                        col = this._colors["ItemGreyTierGlow"];
                        break;
                    case ItemID.Weapons:
                        col = this._colors["ItemWeaponGlow"];
                        break;
                    default:
                        col = this._colors["ItemAmmoBoxGlow"];
                        break;
                }
                
                color = new GlowColor
                {
                    R = ((float)col.R / 255.0f),
                    G = ((float)col.G / 255.0f),
                    B = ((float)col.B / 255.0f)
                };
            }

            if (!revert)
            {
                color.R = ((float)color.R * brightness);
                color.G = ((float)color.G * brightness);
                color.B = ((float)color.B * brightness);
            }

            return color;
        }

        public void SetItemGlow(ItemID item, ref List<IScatterWriteEntry> entries, bool revert = false)
        {
            var glowModePtr = this.HighlightSettings + (Offsets.Glow.HighlightTypeSize * (uint)item) + 0x0;
            var glowColorPtr = this.HighlightSettings + (Offsets.Glow.HighlightTypeSize * (uint)item) + 0x4;

            var newGlowMode = this.GetItemGlowSettings(item, revert);
            var newGlowColor = this.GetItemGlowColor(item, revert);

            var oldGlowMode = Memory.ReadValue<GlowMode>(glowModePtr);
            var oldGlowColor = Memory.ReadValue<GlowColor>(glowColorPtr);

            if (!this.IsSameGlowMode(oldGlowMode, newGlowMode))
                entries.Add(new ScatterWriteDataEntry<GlowMode>(glowModePtr, newGlowMode));

            if (!this.IsSameGlowColor(oldGlowColor, newGlowColor))
                entries.Add(new ScatterWriteDataEntry<GlowColor>(glowColorPtr, newGlowColor));
        }

        public void SetPlayerGlow(Player player, ref List<IScatterWriteEntry> entries, bool revert = false)
        {
            var newGlowMode = this.GetPlayerGlowSettings(revert);
            var (newGlowColor, setting) = this.GetPlayerGlowColor(player);

            if (!player.IsActive || !Memory.LocalPlayer.IsActive)
                return;

            entries.Add(new ScatterWriteDataEntry<byte>(player.Base + Offsets.Glow.Highlight_ID + 0, (byte)setting));
            entries.Add(new ScatterWriteDataEntry<GlowMode>(this.HighlightSettings + Offsets.Glow.HighlightTypeSize * setting + 0x0, newGlowMode));
            entries.Add(new ScatterWriteDataEntry<GlowColor>(this.HighlightSettings + Offsets.Glow.HighlightTypeSize * setting + 0x4, newGlowColor));
            entries.Add(new ScatterWriteDataEntry<byte>(player.Base + Offsets.Glow.Fix, (byte)(revert ? 1 : 0)));
        }
    }
}
