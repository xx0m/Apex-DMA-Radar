using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using MaterialSkin;
using MaterialSkin.Controls;
using apex_dma_radar.Properties;
using System;

namespace apex_dma_radar
{
    public partial class frmMain : MaterialForm
    {
        private readonly Config _config;
        private readonly SKGLControl _mapCanvas;
        private readonly Stopwatch _fpsWatch = new();
        private readonly object _renderLock = new();
        private readonly object _loadMapBitmapsLock = new();
        private readonly System.Timers.Timer _mapChangeTimer = new(900);
        private readonly List<Map> _maps = new(); // Contains all maps from \\Maps folder
        private readonly List<string> FONTS_TO_USE = new List<string>()
        {
            "Arial",
            "Calibri",
            "Candara",
            "Consolas",
            "Constantia",
            "Corbel",
            "Helvetica",
            "Lato",
            "Roboto",
            "Segoe UI",
            "Tahoma",
            "Trebuchet MS",
            "Verdana",
        };

        private Player LocalPlayer => Memory.LocalPlayer;

        private bool _isFreeMapToggled = false;
        private float _uiScale = 1.0f;
        private Player _closestPlayerToMouse = null;
        private bool _isDragging = false;
        private Point _lastMousePosition = Point.Empty;
        private int? _mouseOverGroup = null;
        private int _fps = 0;
        private int _mapSelectionIndex = 0;
        private Map _selectedMap;
        private SKBitmap[] _loadedBitmaps;
        private MapPosition _mapPanPosition = new();

        private const int ZOOM_INTERVAL = 10;
        private int targetZoomValue = 0;
        private System.Windows.Forms.Timer zoomTimer;

        private const float DRAG_SENSITIVITY = 3.5f;

        private const double PAN_SMOOTHNESS = 0.1;
        private const int PAN_INTERVAL = 10;
        private SKPoint targetPanPosition;
        private System.Windows.Forms.Timer panTimer;
        private int MAX_AIMLINE_LENGTH;

        private Vector3 _lastValidPosition = Vector3.Zero;
        private bool _hasValidPosition = false;
        private const float MAX_POSITION_CHANGE = 8000f;
        private const float EPSILON = 0.001f;

        #region Getters
        /// <summary>
        /// Radar has found Escape From Tarkov process and is ready.
        /// </summary>
        private bool Ready
        {
            get => Memory.Ready;
        }

        /// <summary>
        /// Radar has found Local Game World.
        /// </summary>
        private bool InGame
        {
            get => Memory.InGame;
        }

        private string MapName
        {
            get => Memory.Level.Name;
        }

        private bool MapReady
        {
            get => Memory.Level?.IsPlayable ?? false;
        }

        /// <summary>
        /// All Players in Local Game World (including dead/exfil'd) 'Player' collection.
        /// </summary>
        private ReadOnlyDictionary<string, Player> AllPlayers
        {
            get => Memory.Players;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// GUI Constructor.
        /// </summary>
        public frmMain()
        {
            _config = Program.Config;

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey800, Primary.Indigo100, Accent.Orange400, TextShade.WHITE);

            LoadConfig();
            LoadMaps();

            _mapCanvas = skMapCanvas;
            _mapCanvas.VSync = _config.VSync;

            _mapChangeTimer.AutoReset = false;
            _mapChangeTimer.Elapsed += MapChangeTimer_Elapsed;

            this.DoubleBuffered = true;

            _fpsWatch.Start();

            zoomTimer = new System.Windows.Forms.Timer();
            zoomTimer.Interval = ZOOM_INTERVAL;
            zoomTimer.Tick += ZoomTimer_Tick;

            panTimer = new System.Windows.Forms.Timer();
            panTimer.Interval = PAN_INTERVAL;
            panTimer.Tick += PanTimer_Tick;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Form closing event.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true; // Cancel shutdown
            this.Enabled = false; // Lock window

            Config.SaveConfig(_config); // Save Config to Config.json
            Memory.Shutdown(); // Wait for Memory Thread to gracefully exit
            e.Cancel = false; // Ready to close
            base.OnFormClosing(e); // Proceed with closing
        }

        /// <summary>
        /// Process hotkey presses.sc
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) => keyData switch
        {
            Keys.F1 => ZoomIn(5),
            Keys.F2 => ZoomOut(5),
            _ => base.ProcessCmdKey(ref msg, keyData),
        };

        /// <summary>
        /// Process mousewheel events.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0) // Main Radar Tab should be open
            {
                var zoomSens = (double)_config.ZoomSensitivity / 100;
                int zoomDelta = -(int)(e.Delta * zoomSens);

                if (zoomDelta < 0)
                    ZoomIn(-zoomDelta);
                else if (zoomDelta > 0)
                    ZoomOut(zoomDelta);

                if (this._isFreeMapToggled && zoomDelta < 0) // Only move the zoom position when scrolling in
                {
                    var mousePos = this._mapCanvas.PointToClient(Cursor.Position);
                    var mapParams = GetMapLocation();
                    var mapMousePos = new SKPoint(
                        mapParams.Bounds.Left + mousePos.X / mapParams.XScale,
                        mapParams.Bounds.Top + mousePos.Y / mapParams.YScale
                    );

                    this.targetPanPosition = mapMousePos;

                    if (!this.panTimer.Enabled)
                        this.panTimer.Start();
                }

                return;
            }

            base.OnMouseWheel(e);
        }
        #endregion

        #region GUI Events / Functions
        #region General Helper Functions
        private void InitiateColors()
        {
            UpdatePaintColorControls();
            UpdateThemeColors();
        }

        private void InitiateUIScaling()
        {
            _uiScale = (.01f * _config.UIScale);

            #region Update Paints/Text
            SKPaints.TextBaseOutline.StrokeWidth = 2 * _uiScale;
            SKPaints.TextRadarStatus.TextSize = 48 * _uiScale;
            SKPaints.PaintBase.StrokeWidth = 3 * _uiScale;
            SKPaints.PaintMouseoverGroup.StrokeWidth = 3 * _uiScale;
            #endregion

            InitiateFontSizes();
        }

        private void InitiateFonts()
        {
            var fontToUse = SKTypeface.FromFamilyName(cboGlobalFont.Text);
            SKPaints.TextMouseoverGroup.Typeface = fontToUse;
            SKPaints.TextBase.Typeface = fontToUse;
            SKPaints.TextBaseOutline.Typeface = fontToUse;
            SKPaints.TextRadarStatus.Typeface = fontToUse;
        }

        private void InitiateSKColors()
        {
            foreach (var paintColor in _config.PaintColors)
            {
                var value = paintColor.Value;
                var color = new SKColor(value.R, value.G, value.B, value.A);

                Extensions.SKColors.Add(paintColor.Key, color);
            }
        }

        private void InitiateFontSizes()
        {
            SKPaints.TextMouseoverGroup.TextSize = _config.GlobalFontSize * _uiScale;
            SKPaints.TextBase.TextSize = _config.GlobalFontSize * _uiScale;
            SKPaints.TextBaseOutline.TextSize = _config.GlobalFontSize * _uiScale;

            foreach (var setting in _config.PlayerInformationSettings)
            {
                var key = setting.Key;
                var value = setting.Value;

                Extensions.PlayerTypeTextPaints[key].TextSize = value.FontSize * _uiScale;
                Extensions.PlayerTypeFlagTextPaints[key].TextSize = value.FlagsFontSize * _uiScale;
            }
        }

        private DialogResult ShowErrorDialog(string message)
        {
            return new MaterialDialog(this, "Error", message, "OK", false, "", true).ShowDialog(this);
        }

        private DialogResult ShowConfirmationDialog(string message, string title)
        {
            return new MaterialDialog(this, title, message, "Yes", true, "No", true).ShowDialog(this);
        }

        private void LoadMaps()
        {
            var dir = new DirectoryInfo($"{Environment.CurrentDirectory}\\Maps");
            if (!dir.Exists)
                dir.Create();

            var configs = dir.GetFiles("*.json");
            //Debug.WriteLine($"Found {configs.Length} .json map configs.");
            if (configs.Length == 0)
                throw new IOException("No .json map configs found!");

            foreach (var config in configs)
            {
                var name = Path.GetFileNameWithoutExtension(config.Name);
                //Debug.WriteLine($"Loading Map: {name}");
                var mapConfig = MapConfig.LoadFromFile(config.FullName); // Assuming LoadFromFile is updated to handle new JSON format
                //Add map ID to map config
                var mapID = mapConfig.MapID[0];
                var map = new Map(name.ToUpper(), mapConfig, config.FullName, mapID);
                // Assuming map.ConfigFile now has a 'mapLayers' property that is a List of a new type matching the JSON structure
                map.ConfigFile.MapLayers = map.ConfigFile
                    .MapLayers
                    .OrderBy(x => x.MinHeight)
                    .ToList();

                _maps.Add(map);
            }
        }

        private void CheckConfigDictionaries()
        {
            UpdateDictionary(_config.PaintColors, _config.DefaultPaintColors);
            UpdateDictionary(_config.PlayerInformationSettings, _config.DefaultPlayerInformationSettings);
        }

        private void UpdateDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> defaultDictionary)
        {
            if (dictionary.Count != defaultDictionary.Count)
            {
                foreach (var setting in defaultDictionary)
                {
                    if (!dictionary.ContainsKey(setting.Key))
                        dictionary.TryAdd(setting.Key, setting.Value);
                }
            }
        }

        private void LoadConfig()
        {
            this.CheckConfigDictionaries();
            this.InitiateSKColors();
            this.SetupFonts();

            #region Settings
            #region General
            // Radar
            swRadarVsync.Checked = _config.VSync;
            swRadarStats.Checked = _config.RadarStats;
            mcRadarStats.Visible = _config.RadarStats;
            swSpectators.Checked = _config.Spectators;

            MAX_AIMLINE_LENGTH = (int)(_config.MaxDistance + 100);

            // User Interface
            sldrZoomSensitivity.Value = _config.ZoomSensitivity;
            sldrUIScale.Value = _config.UIScale;
            cboGlobalFont.SelectedIndex = _config.GlobalFont;
            sldrGlobalFontSize.Value = _config.GlobalFontSize;
            swHighlightLastAlive.Checked = _config.HighlightLastAlive;
            #endregion

            #region Memory Writing
            swMasterSwitch.Checked = _config.MasterSwitch;

            // Player Glow
            var playerGlowSettings = _config.PlayerGlowSettings;
            mcSettingsMemoryWritingPlayerGlow.Enabled = _config.MasterSwitch;
            swPlayerGlow.Checked = playerGlowSettings.Enabled;
            swPlayerGlowShieldBased.Checked = playerGlowSettings.ShieldBased;
            sldrPlayerGlowInsideFunction.Value = playerGlowSettings.InsideFunction;
            txtPlayerGlowInsideFunction.Text = playerGlowSettings.InsideFunction.ToString();
            sldrPlayerGlowOutlineFunction.Value = playerGlowSettings.OutlineFunction;
            txtPlayerGlowOutlineFunction.Text = playerGlowSettings.OutlineFunction.ToString();
            sldrPlayerGlowOutlineRadius.Value = playerGlowSettings.OutlineRadius;
            txtPlayerGlowOutlineRadius.Text = playerGlowSettings.OutlineRadius.ToString();
            sldrPlayerGlowBrightness.Value = playerGlowSettings.Brightness;
            txtPlayerGlowBrightness.Text = playerGlowSettings.Brightness.ToString();

            // Item Glow
            var itemGlowSettings = _config.ItemGlowSettings;
            mcSettingsMemoryWritingItemGlow.Enabled = _config.MasterSwitch;

            // View Model Glow
            var viewmodelGlowSettings = _config.ViewModelGlowSettings;
            mcSettingsMemoryWritingViewModelGlow.Enabled = _config.MasterSwitch;
            swViewModelGlow.Checked = viewmodelGlowSettings.Enabled;
            sldrViewModelEffect.Value = viewmodelGlowSettings.Effect;
            txtViewModelEffect.Text = viewmodelGlowSettings.Effect.ToString();

            #endregion
            #endregion

            this.UpdatePlayerGlowSettings();
            this.UpdateItemGlowSettings();
            this.UpdateViewModelGlowSettings();
            this.UpdatePlayerInformationSettings();
            this.UpdateViewModelGlowSettings();
            this.InitiateColors();
            this.InitiateFonts();
            this.InitiateUIScaling();
        }
        #endregion

        #region General Event Handlers
        private async void frmMain_Shown(object sender, EventArgs e)
        {
            while (_mapCanvas.GRContext is null)
                await Task.Delay(1);

            _mapCanvas.GRContext.SetResourceCacheLimit(503316480); // Fixes low FPS on big maps

            while (true)
            {
                await Task.Run(() => Thread.SpinWait(50000)); // High performance async delay
                _mapCanvas.Refresh(); // draw next frame
            }
        }

        private void MapChangeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_renderLock)
            {
                try
                {
                    _selectedMap = _maps[_mapSelectionIndex]; // Swap map

                    if (_loadedBitmaps is not null)
                    {
                        foreach (var bitmap in _loadedBitmaps)
                            bitmap?.Dispose(); // Cleanup resources
                    }

                    _loadedBitmaps = new SKBitmap[_selectedMap.ConfigFile.MapLayers.Count];

                    for (int i = 0; i < _loadedBitmaps.Length; i++)
                    {
                        using (
                            var stream = File.Open(
                                _selectedMap.ConfigFile.MapLayers[i].Filename,
                                FileMode.Open,
                                FileAccess.Read))
                        {
                            _loadedBitmaps[i] = SKBitmap.Decode(stream); // Load new bitmap(s)
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        $"ERROR loading {_selectedMap.ConfigFile.MapLayers[0].Filename}: {ex}"
                    );
                }
            }
        }
        #endregion

        #region Radar Tab
        #region Helper Functions
        private void ResetVariables()
        {
            this._selectedMap = null;

            lblRadarFPSValue.Text = "0";
            lblRadarMemSValue.Text = "0";

            lblRadarPlayersValue.Text = "0";
            lblRadarPlayersValue.UseAccent = false;
            lblRadarPlayersValue.HighEmphasis = false;

            lblRadarPlayersAliveValue.Text = "0";
            lblRadarPlayersAliveValue.UseAccent = false;
            lblRadarPlayersAliveValue.HighEmphasis = false;

            _lastValidPosition = Vector3.Zero;
            _hasValidPosition = false;
        }

        private void UpdateWindowTitle()
        {
            bool inGame = this.InGame;
            var localPlayer = this.LocalPlayer;

            if (inGame && localPlayer is not null)
            {
                UpdateSelectedMap();

                if (_fpsWatch.ElapsedMilliseconds >= 1000)
                {
                    // RE-ENABLE & EXPLORE WHAT THIS DOES
                    //_mapCanvas.GRContext.PurgeResources(); // Seems to fix mem leak issue on increasing resource cache

                    var fps = _fps;
                    var ticks = (Memory.Ticks / 1000D).ToString("0.##k");
                    var playersActive = this.AllPlayers
                        .Where(x => x.Value.IsActive)
                        .Count();

                    var playersAlive = this.AllPlayers
                        .Where(x => x.Value.IsActive && !x.Value.IsDead)
                        .Count();

                    if (lblRadarFPSValue.Text != fps.ToString())
                        lblRadarFPSValue.Text = $"{fps}";

                    if (lblRadarMemSValue.Text != ticks)
                        lblRadarMemSValue.Text = ticks;

                    if (lblRadarPlayersValue.Text != playersActive.ToString())
                    {
                        lblRadarPlayersValue.Text = playersActive.ToString();
                        lblRadarPlayersValue.UseAccent = playersActive > 0;
                        lblRadarPlayersValue.HighEmphasis = playersActive > 0;
                    }

                    if (lblRadarPlayersAliveValue.Text != playersAlive.ToString())
                    {
                        lblRadarPlayersAliveValue.Text = playersAlive.ToString();
                        lblRadarPlayersAliveValue.UseAccent = playersAlive > 0;
                        lblRadarPlayersAliveValue.HighEmphasis = playersAlive > 0;
                    }

                    _fpsWatch.Restart();
                    _fps = 0;
                }
                else
                {
                    _fps++;
                }
            }
        }

        private void UpdateSelectedMap()
        {
            string currentMap = this.MapName;

            if (_selectedMap is null || _selectedMap.MapID.ToLower() != currentMap.ToLower())
            {
                var selectedMapName = _maps.FirstOrDefault(x => x.MapID.ToLower() == currentMap.ToLower());

                if (selectedMapName is not null)
                {
                    _selectedMap = selectedMapName;

                    // Init map
                    CleanupLoadedBitmaps();
                    LoadMapBitmaps();
                }
            }
        }

        private void CleanupLoadedBitmaps()
        {
            if (_loadedBitmaps is not null)
            {
                Parallel.ForEach(_loadedBitmaps, bitmap =>
                {
                    bitmap?.Dispose();
                });

                _loadedBitmaps = null;
            }
        }

        private void LoadMapBitmaps()
        {
            var mapLayers = _selectedMap.ConfigFile.MapLayers;
            _loadedBitmaps = new SKBitmap[mapLayers.Count];

            Parallel.ForEach(mapLayers, (mapLayer, _, _) =>
            {
                lock (_loadMapBitmapsLock)
                {
                    using (var stream = File.Open(mapLayer.Filename, FileMode.Open, FileAccess.Read))
                    {
                        _loadedBitmaps[mapLayers.IndexOf(mapLayer)] = SKBitmap.Decode(stream);
                        _loadedBitmaps[mapLayers.IndexOf(mapLayer)].SetImmutable();
                    }
                }
            });
        }

        private bool IsReadyToRender()
        {
            bool isReady = this.Ready;
            bool inGame = this.InGame;
            bool localPlayerExists = this.LocalPlayer is not null;
            bool selectedMapLoaded = this._selectedMap is not null;

            if (!isReady)
                return false; // Game process not running

            if (!selectedMapLoaded)
                return false; // Map not loaded

            if (!localPlayerExists)
                return false; // Cannot find local player

            if (!inGame)
                return false; // Waiting for raid start

            return true; // Ready to render
        }

        private int GetMapLayerIndex(float playerHeight)
        {
            for (int i = _loadedBitmaps.Length - 1; i >= 0; i--)
            {
                if (playerHeight > _selectedMap.ConfigFile.MapLayers[i].MinHeight)
                {
                    return i;
                }
            }

            return 0; // Default to the first layer if no match is found
        }

        private MapParameters GetMapParameters(MapPosition localPlayerPos)
        {
            int mapLayerIndex = GetMapLayerIndex(localPlayerPos.Height);

            var bitmap = _loadedBitmaps[mapLayerIndex];
            float zoomFactor = 0.01f * _config.DefaultZoom;
            float zoomWidth = bitmap.Width * zoomFactor;
            float zoomHeight = bitmap.Height * zoomFactor;

            var bounds = new SKRect(
                localPlayerPos.X - zoomWidth / 2,
                localPlayerPos.Y - zoomHeight / 2,
                localPlayerPos.X + zoomWidth / 2,
                localPlayerPos.Y + zoomHeight / 2
            ).AspectFill(_mapCanvas.CanvasSize);

            return new MapParameters
            {
                UIScale = _uiScale,
                MapLayerIndex = mapLayerIndex,
                Bounds = bounds,
                XScale = (float)_mapCanvas.Width / bounds.Width, // Set scale for this frame
                YScale = (float)_mapCanvas.Height / bounds.Height // Set scale for this frame
            };
        }

        private bool IsValidPosition(Vector3 position)
        {
            return Math.Abs(position.X) > EPSILON || Math.Abs(position.Y) > EPSILON || Math.Abs(position.Z) > EPSILON;
        }

        private MapParameters GetMapLocation()
        {
            Player focusPlayer = null;

            if (!this.LocalPlayer.IsDead)
                focusPlayer = this.LocalPlayer;
            else if (Memory.Game.SpectatedPlayer is not null)
                focusPlayer = Memory.Game.SpectatedPlayer;
            else if (TeamManager.GetTeamMembers(this.LocalPlayer.TeamID).Count > 1)
                focusPlayer = TeamManager.GetTeamMembers(this.LocalPlayer.TeamID)
                    .FirstOrDefault(p => p != this.LocalPlayer && !p.IsDead && p.Health > 0);

            if (focusPlayer is not null)
            {
                var focusPlayerPos = focusPlayer.Position;

                if (focusPlayer == this.LocalPlayer && IsValidPosition(focusPlayerPos))
                {
                    if (_hasValidPosition)
                    {
                        var distance = Vector3.Distance(_lastValidPosition, focusPlayerPos).ToMeters();

                        if (distance > MAX_POSITION_CHANGE)
                            focusPlayerPos = _lastValidPosition;
                        else
                            _lastValidPosition = focusPlayerPos;

                        focusPlayerPos = _lastValidPosition;
                    }
                    else
                    {
                        _lastValidPosition = focusPlayerPos;
                        _hasValidPosition = true;
                    }
                }

                var focusPlayerMapPos = focusPlayerPos.ToMapPos(_selectedMap);

                if (_isFreeMapToggled)
                {
                    _mapPanPosition.Height = focusPlayerMapPos.Height;
                    return GetMapParameters(_mapPanPosition);
                }
                else
                {
                    _lastMousePosition = Point.Empty;
                    _mapPanPosition = focusPlayerMapPos;
                    targetPanPosition = focusPlayerMapPos.GetPoint();

                    return GetMapParameters(focusPlayerMapPos);
                }
            }
            else
            {
                return GetMapParameters(_mapPanPosition);
            }
        }

        private static bool IsAggressorFacingTarget(SKPoint aggressor, double aggressorDegrees, SKPoint target, float distance)
        {
            double maxDiff = 31.3573 - 3.51726 * Math.Log(Math.Abs(0.626957 - 15.6948 * distance)); // Max degrees variance based on distance variable
            if (maxDiff < 1f)
                maxDiff = 1f; // Non linear equation, handle low/negative results

            var radians = Math.Atan2(target.Y - aggressor.Y, target.X - aggressor.X); // radians
            var degs = radians.ToDegrees();

            if (degs < 0)
                degs += 360f; // handle if negative

            var diff = Math.Abs(degs - aggressorDegrees); // Get angular difference (in degrees)

            return diff <= maxDiff; // See if calculated degrees is within max difference
        }

        private PlayerInformationSettings GetPlayerInfoSettings(Player player)
        {
            string playerType = player.Type.ToString();

            if (_config.PlayerInformationSettings.TryGetValue(playerType, out var settings))
                return settings;

            return _config.PlayerInformationSettings["Dummy"];
        }

        private void DrawMap(SKCanvas canvas)
        {
            var localPlayer = this.LocalPlayer;
            var localPlayerPos = localPlayer.Position;

            if (mcRadarMapSetup.Visible) // Print coordinates (to make it easy to setup JSON configs)
                lblRadarMapSetup.Text = $"Map Setup - X,Y,Z: {localPlayerPos.X}, {localPlayerPos.Y}, {localPlayerPos.Z}";
            else if (lblRadarMapSetup.Text != "Map Setup" && !mcRadarMapSetup.Visible)
                lblRadarMapSetup.Text = "Map Setup";

            // Prepare to draw Game Map
            var mapParams = GetMapLocation();

            var mapCanvasBounds = new SKRect() // Drawing Destination
            {
                Left = _mapCanvas.Left,
                Right = _mapCanvas.Right,
                Top = _mapCanvas.Top,
                Bottom = _mapCanvas.Bottom
            };

            // Draw Game Map
            canvas.DrawBitmap(
                _loadedBitmaps[mapParams.MapLayerIndex],
                mapParams.Bounds,
                mapCanvasBounds,
                SKPaints.PaintBitmap
            );
        }

        private void DrawSpectatorList(SKCanvas canvas)
        {
            if (!_config.Spectators || !this.InGame)
                return;

            var spectators = new List<string>();

            if (!Memory.LocalPlayer.IsDead)
            {
                spectators = this.AllPlayers
                    .Where(x => x.Value.IsActive && x.Value.IsSpectatingLocalPlayer)
                    .Select(x => x.Value.Name)
                    .ToList();
            }
            else
            {
                if (Memory.LocalPlayer.SpectatorBase == 0)
                    return;

                foreach (var player in this.AllPlayers.Where(x => x.Value.IsActive))
                {
                    if (player.Value.SpectatorBase == Memory.LocalPlayer.SpectatorBase)
                        spectators.Add(player.Value.Name);
                }
            }

            if (spectators.Any())
            {
                var sidePadding = 5 * _uiScale;
                var topPadding = 2 * _uiScale;
                var lineHeight = 16 * _uiScale;

                var textPaint = SKPaints.TextBase;

                var displayedSpectators = spectators.Take(5).ToList();

                if (spectators.Count > 5)
                    displayedSpectators.Add($"+{spectators.Count - 5} more...");

                var maxWidth = displayedSpectators.Max(s => textPaint.MeasureText(s));
                var boxWidth = maxWidth + (sidePadding * 2);
                var boxHeight = (displayedSpectators.Count * lineHeight) + (topPadding * 2);

                var rect = new SKRect(
                    sidePadding,
                    sidePadding,
                    boxWidth + sidePadding,
                    boxHeight + sidePadding
                );

                var y = rect.Top + topPadding + textPaint.TextSize;

                canvas.DrawRoundRect(rect, 5, 5, new SKPaint
                {
                    Color = SKColors.Black.WithAlpha(200),
                    Style = SKPaintStyle.Fill
                });

                foreach (var spectator in displayedSpectators)
                {
                    canvas.DrawText(spectator, rect.Left + sidePadding, y, textPaint);
                    y += lineHeight;
                }
            }
        }

        private void DrawPlayers(SKCanvas canvas)
        {
            Player localPlayer = this.LocalPlayer;

            if (localPlayer.IsDead)
            {
                if (Memory.Game.SpectatedPlayer is not null)
                    localPlayer = Memory.Game.SpectatedPlayer;
                else if (TeamManager.GetTeamMembers(localPlayer.TeamID).Count > 1)
                    localPlayer = TeamManager.GetTeamMembers(localPlayer.TeamID)
                        .FirstOrDefault(p => p != localPlayer && !p.IsDead && p.Health > 0);
            }

            if (this.InGame && localPlayer is not null)
            {
                var allPlayers = this.AllPlayers
                    .Select(x => x.Value)
                    .Where(x => x.IsActive && !x.IsDead); // Skip people not in match & not alive

                if (allPlayers is null || allPlayers.Count() < 1)
                    return;

                var friendlies = allPlayers?.Where(x => x.IsFriendlyActive);
                var localPlayerPos = localPlayer.Position;
                var localPlayerMapPos = localPlayerPos.ToMapPos(_selectedMap);
                var mouseOverGroup = _mouseOverGroup;
                var mapParams = GetMapLocation();

                foreach (var player in allPlayers) // Draw players
                {
                    int aimlineLength = 15;
                    var playerPos = player.Position;
                    var playerMapPos = playerPos.ToMapPos(_selectedMap);
                    var playerZoomedPos = playerMapPos.ToZoomedPos(mapParams);

                    player.ZoomedPosition = new Vector2() // Cache Position as Vec2 for MouseMove event
                    {
                        X = playerZoomedPos.X,
                        Y = playerZoomedPos.Y
                    };                    

                    if (!player.IsSkyDiving && !player.IsRespawning && !player.IsKnocked && player.Type is not PlayerType.Teammate && !player.IsLocalPlayer)
                    {
                        if (friendlies is not null)
                            foreach (var friendly in friendlies)
                            {
                                var friendlyPos = friendly.Position;
                                var friendlyDist = Vector3.Distance(playerPos, friendlyPos).ToMeters();

                                if (friendlyDist > _config.MaxDistance)
                                    continue; // max range, no lines across entire map

                                var friendlyMapPos = friendlyPos.ToMapPos(_selectedMap);
                                var degrees = player.IsLocalPlayer ? player.Rotation.X : player.Yaw;

                                if (IsAggressorFacingTarget(playerMapPos.GetPoint(), player.Rotation.X, friendlyMapPos.GetPoint(), friendlyDist))
                                {
                                    aimlineLength = MAX_AIMLINE_LENGTH; // Lengthen aimline
                                    break;
                                }
                            }
                    }

                    // Draw Player
                    DrawPlayer(canvas, player, localPlayer, playerZoomedPos, aimlineLength, mouseOverGroup, localPlayerMapPos);
                }

            }
        }

        private void DrawPlayer(SKCanvas canvas, Player player, Player anchor, MapPosition playerZoomedPos, int aimlineLength, int? mouseOverGrp, MapPosition localPlayerMapPos)
        {
            if (this.InGame && anchor is not null)
            {
                var playerSettings = this.GetPlayerInfoSettings(player);
                var height = playerZoomedPos.Height - localPlayerMapPos.Height;
                var dist = Vector3.Distance(anchor.Position, player.Position).ToMeters();
                var aimlineSettings = new AimlineSettings
                {
                    Enabled = playerSettings.Aimline,
                    Length = aimlineLength,
                    Opacity = playerSettings.AimlineOpacity
                };

                List<string> aboveLines = new List<string>();
                List<string> belowLines = new List<string>();
                List<string> rightLines = new List<string>();
                List<string> leftLines = new List<string>();

                if (playerSettings.Name)
                    aboveLines.Add(player.Name);

                if (playerSettings.Height)
                    leftLines.Add($"{Math.Round(height)}");

                if (playerSettings.Distance && dist > 0)
                    belowLines.Add($"{Math.Round(dist)}m");

                if (playerSettings.Flags)
                {
                    if (playerSettings.ActiveWeapon)
                    {
                        if (!player.IsKnocked)
                        {
                            var name = player.ActiveWeapon;

                            if (player.HoldingGrenade)
                                name = "Grenade";

                            if (!string.IsNullOrEmpty(name))
                                rightLines.Add(name ?? "N/A");
                        }
                    }

                    if (playerSettings.Health || playerSettings.Shield)
                    {
                        var line = string.Empty;

                        if (playerSettings.Shield)
                            line += $"{player.Shield}";

                        if (playerSettings.Health && playerSettings.Shield)
                            line += "/";

                        if (playerSettings.Health)
                            line += $"{player.Health}";

                        rightLines.Add(line);
                    }

                    if (playerSettings.XPLevel)
                        rightLines.Add($"LVL: {player.Level}");

                    if (playerSettings.ShieldLevel)
                        rightLines.Add($"{player.ShieldLevel}");

                    if (playerSettings.Legend)
                        rightLines.Add(player.Legend);

                    if (playerSettings.Knocked)
                        if (player.IsKnocked)
                            rightLines.Add("KNOCKED");

                    if (playerSettings.LastAlive)
                        if (player.IsLastAliveInSquad)
                            rightLines.Add("LAST");
                }

                if (aimlineSettings.Length == 15)
                    aimlineSettings.Length = playerSettings.AimlineLength;

                playerZoomedPos.DrawPlayerText(
                    canvas,
                    player,
                    aboveLines.ToArray(),
                    belowLines.ToArray(),
                    rightLines.ToArray(),
                    leftLines.ToArray(),
                    mouseOverGrp
                );

                playerZoomedPos.DrawPlayerMarker(
                    canvas,
                    player,
                    aimlineSettings,
                    mouseOverGrp
                );
            }
        }

        private void ClearPlayerRefs()
        {
            _closestPlayerToMouse = null;
            _mouseOverGroup = null;
        }

        private T FindClosestObject<T>(IEnumerable<T> objects, Vector2 position, Func<T, Vector2> positionSelector, float threshold)
            where T : class
        {
            if (objects is null || !objects.Any())
                return null;

            var closestObject = objects.Aggregate(
                (x1, x2) =>
                    x2 == null || Vector2.Distance(positionSelector(x1), position)
                    < Vector2.Distance(positionSelector(x2), position)
                        ? x1
                        : x2
            );

            if (closestObject is not null && Vector2.Distance(positionSelector(closestObject), position) < threshold)
                return closestObject;

            return null;
        }

        private void PanTimer_Tick(object sender, EventArgs e)
        {
            var panDifference = new SKPoint(
                this.targetPanPosition.X - this._mapPanPosition.X,
                this.targetPanPosition.Y - this._mapPanPosition.Y
            );

            if (panDifference.Length > 0.1)
            {
                this._mapPanPosition.X += (float)(panDifference.X * PAN_SMOOTHNESS);
                this._mapPanPosition.Y += (float)(panDifference.Y * PAN_SMOOTHNESS);
            }
            else
            {
                this.panTimer.Stop();
            }
        }

        private void ZoomTimer_Tick(object sender, EventArgs e)
        {
            int zoomDifference = this.targetZoomValue - _config.DefaultZoom;

            if (zoomDifference != 0)
            {
                int zoomStep = Math.Sign(zoomDifference);
                _config.DefaultZoom += zoomStep;
            }
            else
                if (this.zoomTimer.Enabled)
                this.zoomTimer.Stop();
        }

        private bool ZoomIn(int amt)
        {
            this.targetZoomValue = Math.Max(10, _config.DefaultZoom - amt);

            if (!this.zoomTimer.Enabled)
                this.zoomTimer.Start();

            return true;
        }

        private bool ZoomOut(int amt)
        {
            this.targetZoomValue = Math.Min(500, _config.DefaultZoom + amt);

            if (!this.zoomTimer.Enabled)
                this.zoomTimer.Start();

            return false;
        }

        private void DrawToolTips(SKCanvas canvas)
        {
            var localPlayer = this.LocalPlayer;
            var mapParams = GetMapLocation();

            if (localPlayer is not null)
            {
                if (_closestPlayerToMouse is not null)
                {
                    var playerZoomedPos = _closestPlayerToMouse
                        .Position
                        .ToMapPos(_selectedMap)
                        .ToZoomedPos(mapParams);
                    playerZoomedPos.DrawToolTip(canvas, _closestPlayerToMouse);
                }
            }
        }

        private void DrawStatusText(SKCanvas canvas)
        {
            var isReady = this.Ready;
            var inGame = this.InGame;
            var isMapReady = this.MapReady;
            var localPlayer = this.LocalPlayer;
            var selectedMap = this._selectedMap;

            string statusText;
            if (!isReady)
                statusText = "Game Process Not Running";
            else if (!isMapReady)
            {
                statusText = "In Lobby";

                if (selectedMap is not null)
                    ResetVariables();
            }
            else if (localPlayer is null)
                statusText = "In Legend Select";
            else if (selectedMap is null)
                statusText = "Loading Map";
            else if (!inGame)
                statusText = "Waiting for Match Start";
            else
                return;

            var centerX = _mapCanvas.Width / 2;
            var centerY = _mapCanvas.Height / 2;

            canvas.DrawText(statusText, centerX, centerY, SKPaints.TextRadarStatus);
        }
        #endregion

        #region Event Handlers
        private void btnToggleMapFree_Click(object sender, EventArgs e)
        {
            if (_isFreeMapToggled)
            {
                btnToggleMapFree.Icon = Resources.tick;
                _isFreeMapToggled = false;

                lock (_renderLock)
                {
                    var localPlayer = this.LocalPlayer;
                    if (localPlayer is not null)
                    {
                        var localPlayerMapPos = localPlayer.Position.ToMapPos(_selectedMap);
                        _mapPanPosition = new MapPosition()
                        {
                            X = localPlayerMapPos.X,
                            Y = localPlayerMapPos.Y,
                            Height = localPlayerMapPos.Height
                        };
                    }
                }
            }
            else
            {
                btnToggleMapFree.Icon = Resources.cross;
                _isFreeMapToggled = true;
            }
        }

        private void btnMapSetupApply_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtMapSetupX.Text, out float x)
                && float.TryParse(txtMapSetupY.Text, out float y)
                && float.TryParse(txtMapSetupScale.Text, out float scale))
            {
                lock (_renderLock)
                {
                    if (_selectedMap is not null)
                    {
                        _selectedMap.ConfigFile.X = x;
                        _selectedMap.ConfigFile.Y = y;
                        _selectedMap.ConfigFile.Scale = scale;
                        _selectedMap.ConfigFile.Save(_selectedMap);
                    }
                }
            }
            else
                ShowErrorDialog("Invalid value(s) provided in the map setup textboxes.");
        }

        private void skMapCanvas_MouseMovePlayer(object sender, MouseEventArgs e)
        {
            if (this.InGame && this.LocalPlayer is not null) // Must be in-game
            {
                var mouse = new Vector2(e.X, e.Y);

                var players = this.AllPlayers
                    ?.Select(x => x.Value)
                    .Where(x => x.Type is not PlayerType.LocalPlayer && x.IsActive && !x.IsDead); // Get all players except LocalPlayer & inactive Players


                _closestPlayerToMouse = FindClosestObject(players, mouse, x => x.ZoomedPosition, 12 * _uiScale);

                if (_closestPlayerToMouse is not null)
                {
                    if (_closestPlayerToMouse.IsHostile && _closestPlayerToMouse.TeamID != -1)
                        _mouseOverGroup = _closestPlayerToMouse.TeamID;
                    else
                        _mouseOverGroup = null;
                }
                else
                    ClearPlayerRefs();


                if (this._isDragging && this._isFreeMapToggled)
                {
                    if (!this._lastMousePosition.IsEmpty)
                    {
                        int dx = e.X - this._lastMousePosition.X;
                        int dy = e.Y - this._lastMousePosition.Y;

                        dx = (int)(dx * DRAG_SENSITIVITY);
                        dy = (int)(dy * DRAG_SENSITIVITY);

                        this.targetPanPosition.X -= dx;
                        this.targetPanPosition.Y -= dy;

                        if (!this.panTimer.Enabled)
                            this.panTimer.Start();
                    }

                    this._lastMousePosition = e.Location;
                }
            }
            else if (this.InGame && Memory.LocalPlayer is null)
            {
                ClearPlayerRefs();
            }
        }

        private void skMapCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this._isFreeMapToggled)
            {
                this._isDragging = true;
                this._lastMousePosition = e.Location;
            }
        }

        private void skMapCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this._isDragging)
            {
                this._isDragging = false;
                this._lastMousePosition = e.Location;
            }
        }

        private void skMapCanvas_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            try
            {
                SKCanvas canvas = e.Surface.Canvas;
                canvas.Clear();

                UpdateWindowTitle();

                if (IsReadyToRender())
                {
                    lock (_renderLock)
                    {
                        DrawMap(canvas);
                        DrawPlayers(canvas);
                        DrawToolTips(canvas);
                        DrawSpectatorList(canvas);
                    }
                }
                else
                    DrawStatusText(canvas);

                canvas.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            }
        }
        #endregion
        #endregion

        #region Settings
        #region General
        #region Helper Functions
        private string GetActivePlayerType()
        {
            return cboPlayerInfoType.SelectedItem?.ToString()?.Replace(" ", "");
        }

        private void UpdatePlayerTextFont(PlayerInformationSettings playerInfoSettings)
        {
            var playerType = this.GetActivePlayerType();
            var playerText = Extensions.PlayerTypeTextPaints[playerType];
            playerText.Typeface = SKTypeface.FromFamilyName(FONTS_TO_USE[playerInfoSettings.Font]);

            Extensions.PlayerTypeTextPaints[playerType] = playerText;
        }

        private void UpdatePlayerTextSize(PlayerInformationSettings playerInfoSettings)
        {
            var playerType = this.GetActivePlayerType();
            var playerText = Extensions.PlayerTypeTextPaints[playerType];
            playerText.TextSize = playerInfoSettings.FontSize * _uiScale;

            Extensions.PlayerTypeTextPaints[playerType] = playerText;
        }

        private void UpdatePlayerFlagTextFont(PlayerInformationSettings playerInfoSettings)
        {
            var playerType = this.GetActivePlayerType();
            var playerText = Extensions.PlayerTypeFlagTextPaints[playerType];
            playerText.Typeface = SKTypeface.FromFamilyName(FONTS_TO_USE[playerInfoSettings.FlagsFont]);

            Extensions.PlayerTypeFlagTextPaints[playerType] = playerText;
        }

        private void UpdatePlayerFlagTextSize(PlayerInformationSettings playerInfoSettings)
        {
            var playerType = this.GetActivePlayerType();
            var playerText = Extensions.PlayerTypeFlagTextPaints[playerType];
            playerText.TextSize = playerInfoSettings.FlagsFontSize * _uiScale;

            Extensions.PlayerTypeFlagTextPaints[playerType] = playerText;
        }

        private void SetupFonts()
        {
            cboGlobalFont.Items.Clear();
            cboPlayerInfoFont.Items.Clear();
            cboPlayerInfoFlagsFont.Items.Clear();

            foreach (string font in FONTS_TO_USE)
            {
                cboGlobalFont.Items.Add(font);
                cboPlayerInfoFont.Items.Add(font);
                cboPlayerInfoFlagsFont.Items.Add(font);
            }

            foreach (var playerSetting in _config.PlayerInformationSettings)
            {
                var settings = playerSetting.Value;
                var textPaint = SKPaints.TextBase.Clone();
                textPaint.Typeface = SKTypeface.FromFamilyName(FONTS_TO_USE[settings.Font]);
                textPaint.TextSize = settings.FontSize * _uiScale;

                var flagsTextPaint = SKPaints.TextBase.Clone();
                flagsTextPaint.Typeface = SKTypeface.FromFamilyName(FONTS_TO_USE[settings.FlagsFont]);
                flagsTextPaint.TextSize = settings.FlagsFontSize * _uiScale;

                Extensions.PlayerTypeTextPaints.Add(playerSetting.Key, textPaint);
                Extensions.PlayerTypeFlagTextPaints.Add(playerSetting.Key, flagsTextPaint);
            }
        }

        private PlayerInformationSettings GetPlayerInfoSettings()
        {
            var playerType = this.GetActivePlayerType();
            return !string.IsNullOrEmpty(playerType) && _config.PlayerInformationSettings.TryGetValue(playerType, out var settings) ? settings : null;
        }

        private bool TryGetPlayerInfoSettings(out PlayerInformationSettings settings)
        {
            settings = this.GetPlayerInfoSettings();
            return settings != null;
        }

        private void UpdatePlayerInformationSettings()
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            var selectedType = cboPlayerInfoType.Text;

            if (selectedType.Equals("LocalPlayer", StringComparison.OrdinalIgnoreCase) ||
                selectedType.Equals("Teammate", StringComparison.OrdinalIgnoreCase))
            {
                sldrPlayerInfoAimlineLength.RangeMax = 500;
                sldrPlayerInfoAimlineLength.ValueMax = 500;
            }
            else if (sldrPlayerInfoAimlineLength.RangeMax == 500)
            {
                sldrPlayerInfoAimlineLength.RangeMax = 60;
                sldrPlayerInfoAimlineLength.ValueMax = 60;
            }

            swPlayerInfoName.Checked = playerInfoSettings.Name;
            swPlayerInfoHeight.Checked = playerInfoSettings.Height;
            swPlayerInfoDistance.Checked = playerInfoSettings.Distance;

            swPlayerInfoAimline.Checked = playerInfoSettings.Aimline;
            sldrPlayerInfoAimlineLength.Value = playerInfoSettings.AimlineLength;
            sldrPlayerInfoAimlineOpacity.Value = playerInfoSettings.AimlineOpacity;
            sldrPlayerInfoAimlineLength.Visible = playerInfoSettings.Aimline;
            sldrPlayerInfoAimlineOpacity.Visible = playerInfoSettings.Aimline;

            cboPlayerInfoFont.SelectedIndex = playerInfoSettings.Font;
            sldrPlayerInfoFontSize.Value = playerInfoSettings.FontSize;

            var flagsChecked = playerInfoSettings.Flags;
            swPlayerInfoFlags.Checked = flagsChecked;
            swPlayerInfoActiveWeapon.Checked = playerInfoSettings.ActiveWeapon;
            swPlayerInfoHealth.Checked = playerInfoSettings.Health;
            swPlayerInfoShield.Checked = playerInfoSettings.Shield;
            swPlayerInfoShieldLevel.Checked = playerInfoSettings.ShieldLevel;
            swPlayerInfoXPLevel.Checked = playerInfoSettings.XPLevel;
            swPlayerInfoLegend.Checked = playerInfoSettings.Legend;
            swPlayerInfoLastAlive.Checked = playerInfoSettings.LastAlive;
            swPlayerInfoKnocked.Checked = playerInfoSettings.Knocked;

            swPlayerInfoActiveWeapon.Visible = flagsChecked;
            swPlayerInfoHealth.Visible = flagsChecked;
            swPlayerInfoShield.Visible = flagsChecked;
            swPlayerInfoShieldLevel.Visible = flagsChecked;
            swPlayerInfoXPLevel.Visible = flagsChecked;
            swPlayerInfoLegend.Visible = flagsChecked;
            swPlayerInfoLastAlive.Visible = flagsChecked;
            swPlayerInfoKnocked.Visible = flagsChecked;

            cboPlayerInfoFlagsFont.SelectedIndex = playerInfoSettings.FlagsFont;
            sldrPlayerInfoFlagsFontSize.Value = playerInfoSettings.FlagsFontSize;

            cboPlayerInfoFlagsFont.Visible = flagsChecked;
            sldrPlayerInfoFlagsFontSize.Visible = flagsChecked;
        }
        #endregion
        #region Event Handlers
        private void swMapHelper_CheckedChanged(object sender, EventArgs e)
        {
            if (swMapHelper.Checked)
            {
                mcRadarMapSetup.Visible = true;
                txtMapSetupX.Text = _selectedMap?.ConfigFile.X.ToString() ?? "0";
                txtMapSetupY.Text = _selectedMap?.ConfigFile.Y.ToString() ?? "0";
                txtMapSetupScale.Text = _selectedMap?.ConfigFile.Scale.ToString() ?? "0";
            }
            else
                mcRadarMapSetup.Visible = false;
        }

        private void sldrUIScale_onValueChanged(object sender, int newValue)
        {
            _config.UIScale = newValue;
            _uiScale = (.01f * newValue);

            InitiateUIScaling();
        }

        private void btnRestartRadar_Click(object sender, EventArgs e)
        {
            Memory.Restart();
        }

        private void swRadarVsync_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = swRadarVsync.Checked;
            _config.VSync = enabled;

            if (_mapCanvas is not null)
                _mapCanvas.VSync = enabled;
        }

        private void swRadarStats_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = swRadarStats.Checked;
            _config.RadarStats = enabled;
            mcRadarStats.Visible = enabled;
        }

        private void swSpectators_CheckedChanged(object sender, EventArgs e)
        {
            _config.Spectators = swSpectators.Checked;
        }

        private void cboGlobalFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.GlobalFont = cboGlobalFont.SelectedIndex;

            InitiateFonts();
        }

        private void sldrGlobalFontSize_onValueChanged(object sender, int newValue)
        {
            _config.GlobalFontSize = newValue;

            InitiateFontSizes();
        }

        private void sldrZoomSensitivity_onValueChanged(object sender, int newValue)
        {
            _config.ZoomSensitivity = newValue;
        }

        private void swHighlightLastAlive_CheckedChanged(object sender, EventArgs e)
        {
            _config.HighlightLastAlive = swHighlightLastAlive.Checked;
        }

        private void cboPlayerInfoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            this.UpdatePlayerInformationSettings();
        }

        private void swPlayerInfoName_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Name = swPlayerInfoName.Checked;
        }

        private void swPlayerInfoHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Height = swPlayerInfoHeight.Checked;
        }

        private void swPlayerInfoDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Distance = swPlayerInfoDistance.Checked;
        }

        private void swPlayerInfoAimline_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            var aimlineChecked = swPlayerInfoAimline.Checked;

            playerInfoSettings.Aimline = aimlineChecked;

            sldrPlayerInfoAimlineLength.Visible = aimlineChecked;
            sldrPlayerInfoAimlineOpacity.Visible = aimlineChecked;
        }

        private void sldrPlayerInfoAimlineLength_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            if (newValue < sldrPlayerInfoAimlineLength.RangeMin)
                newValue = sldrPlayerInfoAimlineLength.RangeMin;

            playerInfoSettings.AimlineLength = newValue;
        }

        private void sldrPlayerInfoAimlineOpacity_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            if (newValue < sldrPlayerInfoAimlineOpacity.RangeMin)
                newValue = sldrPlayerInfoAimlineOpacity.RangeMin;

            playerInfoSettings.AimlineOpacity = newValue;
        }

        private void cboPlayerInfoFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Font = cboPlayerInfoFont.SelectedIndex;

            this.UpdatePlayerTextFont(playerInfoSettings);
        }

        private void sldrPlayerInfoFontSize_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.FontSize = newValue;

            this.UpdatePlayerTextSize(playerInfoSettings);
        }

        private void swPlayerInfoFlags_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            var flagsChecked = swPlayerInfoFlags.Checked;

            playerInfoSettings.Flags = flagsChecked;
            swPlayerInfoActiveWeapon.Visible = flagsChecked;
            swPlayerInfoHealth.Visible = flagsChecked;
            swPlayerInfoShield.Visible = flagsChecked;
            swPlayerInfoShieldLevel.Visible = flagsChecked;
            swPlayerInfoXPLevel.Visible = flagsChecked;
            swPlayerInfoLegend.Visible = flagsChecked;
            swPlayerInfoLastAlive.Visible = flagsChecked;
            swPlayerInfoKnocked.Visible = flagsChecked;

            cboPlayerInfoFlagsFont.Visible = flagsChecked;
            sldrPlayerInfoFlagsFontSize.Visible = flagsChecked;
        }

        private void swPlayerInfoActiveWeapon_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.ActiveWeapon = swPlayerInfoActiveWeapon.Checked;
        }

        private void swPlayerInfoHealth_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Health = swPlayerInfoHealth.Checked;
        }

        private void swPlayerInfoShield_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Shield = swPlayerInfoShield.Checked;
        }

        private void swPlayerInfoShieldLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.ShieldLevel = swPlayerInfoShieldLevel.Checked;
        }

        private void swPlayerInfoXPLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.XPLevel = swPlayerInfoXPLevel.Checked;
        }

        private void swPlayerInfoLegend_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Legend = swPlayerInfoLegend.Checked;
        }

        private void swPlayerInfoLastAlive_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.LastAlive = swPlayerInfoLastAlive.Checked;
        }

        private void swPlayerInfoKnocked_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.Knocked = swPlayerInfoKnocked.Checked;
        }

        private void cboPlayerInfoFlagsFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.FlagsFont = cboPlayerInfoFlagsFont.SelectedIndex;

            this.UpdatePlayerFlagTextFont(playerInfoSettings);
        }

        private void sldrPlayerInfoFlagsFontSize_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetPlayerInfoSettings(out var playerInfoSettings))
                return;

            playerInfoSettings.FlagsFontSize = newValue;

            this.UpdatePlayerFlagTextSize(playerInfoSettings);
        }
        #endregion
        #endregion

        #region Memory Writing
        #region Helper Functions
        private void UpdatePlayerGlowSettings()
        {
            var enabled = swPlayerGlow.Checked;

            swPlayerGlowShieldBased.Enabled = enabled;

            sldrPlayerGlowInsideFunction.Enabled = enabled;
            sldrPlayerGlowOutlineFunction.Enabled = enabled;
            sldrPlayerGlowOutlineRadius.Enabled = enabled;
            sldrPlayerGlowBrightness.Enabled = enabled;

            txtPlayerGlowInsideFunction.Enabled = enabled;
            txtPlayerGlowOutlineFunction.Enabled = enabled;
            txtPlayerGlowOutlineRadius.Enabled = enabled;
            txtPlayerGlowBrightness.Enabled = enabled;
        }

        private void UpdateViewModelGlowSettings()
        {
            var enabled = swViewModelGlow.Checked;

            sldrViewModelEffect.Enabled = enabled;
            txtViewModelEffect.Enabled = enabled;
        }

        private ItemGlowSettings GetItemGlowSettings()
        {
            ItemID item;

            var selectedType = cboItemGlowType.Text;

            switch (selectedType)
            {
                case "Red Tier":
                    item = ItemID.Red;
                    break;
                case "Gold Tier":
                    item = ItemID.Gold;
                    break;
                case "Purple Tier":
                    item = ItemID.Purple;
                    break;
                case "Blue Tier":
                    item = ItemID.Blue;
                    break;
                case "Grey Tier":
                    item = ItemID.Grey;
                    break;
                case "Weapons":
                    item = ItemID.Weapons;
                    break;
                default:
                    item = ItemID.Ammo;
                    break;
            }

            return _config.ItemGlowSettings.TryGetValue(item, out var settings) ? settings : null;
        }

        private bool TryGetItemGlowSettings(out ItemGlowSettings settings)
        {
            settings = this.GetItemGlowSettings();
            return settings != null;
        }

        private void UpdateItemGlowSettings()
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            this.UpdateItemGlowControls();

            swItemGlowColor.Checked = itemGlowSettings.CustomColor;

            sldrItemGlowInsideFunction.Value = itemGlowSettings.InsideFunction;
            sldrItemGlowOutlineFunction.Value = itemGlowSettings.OutlineFunction;
            sldrItemGlowOutlineRadius.Value = itemGlowSettings.OutlineRadius;
            sldrItemGlowBrightness.Value = itemGlowSettings.Brightness;

            txtItemGlowInsideFunction.Text = itemGlowSettings.InsideFunction.ToString();
            txtItemGlowOutlineFunction.Text = itemGlowSettings.OutlineFunction.ToString();
            txtItemGlowOutlineRadius.Text = itemGlowSettings.OutlineRadius.ToString();
            txtItemGlowBrightness.Text = itemGlowSettings.Brightness.ToString();
        }

        private void UpdateItemGlowControls()
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            var enabled = itemGlowSettings.Enabled;

            swItemGlow.Checked = enabled;
            swItemGlowColor.Enabled = enabled;

            sldrItemGlowInsideFunction.Enabled = enabled;
            sldrItemGlowOutlineFunction.Enabled = enabled;
            sldrItemGlowOutlineRadius.Enabled = enabled;
            sldrItemGlowBrightness.Enabled = enabled;

            txtItemGlowInsideFunction.Enabled = enabled;
            txtItemGlowOutlineFunction.Enabled = enabled;
            txtItemGlowOutlineRadius.Enabled = enabled;
            txtItemGlowBrightness.Enabled = enabled;
        }
        #endregion
        #region Event Handlers
        private void swMasterSwitch_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = swMasterSwitch.Checked;
            _config.MasterSwitch = isChecked;

            mcSettingsMemoryWritingPlayerGlow.Enabled = isChecked;
            mcSettingsMemoryWritingItemGlow.Enabled = isChecked;
            mcSettingsMemoryWritingViewModelGlow.Enabled = isChecked;
        }

        // Player Glow
        private void swPlayerGlow_CheckedChanged(object sender, EventArgs e)
        {
            _config.PlayerGlowSettings.Enabled = swPlayerGlow.Checked;

            this.UpdatePlayerGlowSettings();
        }

        private void swPlayerGlowShieldBased_CheckedChanged(object sender, EventArgs e)
        {
            _config.PlayerGlowSettings.ShieldBased = swPlayerGlowShieldBased.Checked;
        }

        private void sldrPlayerGlowInsideFunction_onValueChanged(object sender, int newValue)
        {
            _config.PlayerGlowSettings.InsideFunction = (byte)newValue;

            if (txtPlayerGlowInsideFunction.Text != newValue.ToString())
                txtPlayerGlowInsideFunction.Text = newValue.ToString();
        }

        private void sldrPlayerGlowOutlineFunction_onValueChanged(object sender, int newValue)
        {
            _config.PlayerGlowSettings.OutlineFunction = (byte)newValue;

            if (txtPlayerGlowOutlineFunction.Text != newValue.ToString())
                txtPlayerGlowOutlineFunction.Text = newValue.ToString();
        }

        private void sldrPlayerGlowOutsideRadius_onValueChanged(object sender, int newValue)
        {
            _config.PlayerGlowSettings.OutlineRadius = (byte)newValue;

            if (txtPlayerGlowOutlineRadius.Text != newValue.ToString())
                txtPlayerGlowOutlineRadius.Text = newValue.ToString();
        }

        private void sldrPlayerGlowBrightness_onValueChanged(object sender, int newValue)
        {
            _config.PlayerGlowSettings.Brightness = (byte)newValue;

            if (txtPlayerGlowBrightness.Text != newValue.ToString())
                txtPlayerGlowBrightness.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void txtPlayerGlowInsideFunction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPlayerGlowInsideFunction.Text, out var newValue))
                {
                    if (_config.PlayerGlowSettings.InsideFunction != newValue)
                        _config.PlayerGlowSettings.InsideFunction = (byte)newValue;

                    if (sldrPlayerGlowInsideFunction.Value != newValue)
                        sldrPlayerGlowInsideFunction.Value = newValue;
                }
            }
        }

        private void txtPlayerGlowOutlineFunction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPlayerGlowOutlineFunction.Text, out var newValue))
                {
                    if (_config.PlayerGlowSettings.OutlineFunction != newValue)
                        _config.PlayerGlowSettings.OutlineFunction = (byte)newValue;

                    if (sldrPlayerGlowOutlineFunction.Value != newValue)
                        sldrPlayerGlowOutlineFunction.Value = newValue;
                }
            }
        }

        private void txtPlayerGlowOutlineRadius_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPlayerGlowOutlineRadius.Text, out var newValue))
                {
                    if (_config.PlayerGlowSettings.OutlineRadius != newValue)
                        _config.PlayerGlowSettings.OutlineRadius = (byte)newValue;

                    if (sldrPlayerGlowOutlineRadius.Value != newValue)
                        sldrPlayerGlowOutlineRadius.Value = newValue;
                }
            }
        }

        private void txtPlayerGlowBrightness_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPlayerGlowBrightness.Text, out var newValue))
                {
                    if (_config.PlayerGlowSettings.Brightness != newValue)
                        _config.PlayerGlowSettings.Brightness = (byte)newValue;

                    if (sldrPlayerGlowBrightness.Value != newValue)
                        sldrPlayerGlowBrightness.Value = newValue;
                }
            }
        }

        // Item Glow
        private void cboItemGlowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            this.UpdateItemGlowSettings();
        }

        private void swItemGlow_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.Enabled = swItemGlow.Checked;

            this.UpdateItemGlowControls();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void sldrItemGlowInsideFunction_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.Enabled = swItemGlow.Checked;
            itemGlowSettings.InsideFunction = (byte)newValue;

            if (txtItemGlowInsideFunction.Text != newValue.ToString())
                txtItemGlowInsideFunction.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void sldrItemGlowOutlineFunction_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.OutlineFunction = (byte)newValue;

            if (txtItemGlowOutlineFunction.Text != newValue.ToString())
                txtItemGlowOutlineFunction.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void sldrItemGlowOutlineRadius_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.OutlineRadius = (byte)newValue;

            if (txtItemGlowOutlineRadius.Text != newValue.ToString())
                txtItemGlowOutlineRadius.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void sldrItemGlowBrightness_onValueChanged(object sender, int newValue)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.Brightness = (byte)newValue;

            if (txtItemGlowBrightness.Text != newValue.ToString())
                txtItemGlowBrightness.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void txtItemGlowInsideFunction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtItemGlowInsideFunction.Text, out var newValue))
                {
                    if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                        return;

                    if (itemGlowSettings.InsideFunction != newValue)
                        itemGlowSettings.InsideFunction = (byte)newValue;

                    if (sldrItemGlowInsideFunction.Value != newValue)
                        sldrItemGlowInsideFunction.Value = newValue;

                    if (this.InGame)
                        Memory.Game.GlowManager.RefreshItems = true;
                }
            }
        }

        private void txtItemGlowOutlineFunction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtItemGlowOutlineFunction.Text, out var newValue))
                {
                    if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                        return;

                    if (itemGlowSettings.OutlineFunction != newValue)
                        itemGlowSettings.OutlineFunction = (byte)newValue;

                    if (sldrItemGlowOutlineFunction.Value != newValue)
                        sldrItemGlowOutlineFunction.Value = newValue;

                    if (this.InGame)
                        Memory.Game.GlowManager.RefreshItems = true;
                }
            }
        }

        private void txtItemGlowOutlineRadius_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtItemGlowOutlineRadius.Text, out var newValue))
                {
                    if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                        return;

                    if (itemGlowSettings.OutlineRadius != newValue)
                        itemGlowSettings.OutlineRadius = (byte)newValue;

                    if (sldrItemGlowOutlineRadius.Value != newValue)
                        sldrItemGlowOutlineRadius.Value = newValue;

                    if (this.InGame)
                        Memory.Game.GlowManager.RefreshItems = true;
                }
            }
        }

        private void txtItemGlowBrightness_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtItemGlowBrightness.Text, out var newValue))
                {
                    if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                        return;

                    if (itemGlowSettings.Brightness != newValue)
                        itemGlowSettings.Brightness = (byte)newValue;

                    if (sldrItemGlowBrightness.Value != newValue)
                        sldrItemGlowBrightness.Value = newValue;

                    if (this.InGame)
                        Memory.Game.GlowManager.RefreshItems = true;
                }
            }
        }

        private void swItemGlowColor_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.TryGetItemGlowSettings(out var itemGlowSettings))
                return;

            itemGlowSettings.CustomColor = swItemGlowColor.Checked;

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        // Viewmodel Effect
        private void swViewModelGlow_CheckedChanged(object sender, EventArgs e)
        {
            _config.ViewModelGlowSettings.Enabled = swViewModelGlow.Checked;

            this.UpdateViewModelGlowSettings();
        }

        private void sldrViewModelEffect_onValueChanged(object sender, int newValue)
        {
            _config.ViewModelGlowSettings.Effect = (byte)newValue;

            if (txtViewModelEffect.Text != newValue.ToString())
                txtViewModelEffect.Text = newValue.ToString();

            if (this.InGame)
                Memory.Game.GlowManager.RefreshViewModel = true;
        }

        private void txtViewModelEffect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtViewModelEffect.Text, out var newValue))
                {
                    if (_config.ViewModelGlowSettings.Effect != newValue)
                        _config.ViewModelGlowSettings.Effect = (byte)newValue;

                    if (sldrViewModelEffect.Value != newValue)
                        sldrViewModelEffect.Value = newValue;

                    if (this.InGame)
                        Memory.Game.GlowManager.RefreshViewModel = true;
                }
            }
        }
        #endregion
        #endregion

        #region Colors
        #region Helper Functions
        private void UpdateThemeColors()
        {
            Color primary = picOtherPrimary.BackColor;
            Color darkPrimary = picOtherPrimaryDark.BackColor;
            Color lightPrimary = picOtherPrimaryLight.BackColor;
            Color accent = picOtherAccent.BackColor;

            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(primary, darkPrimary, lightPrimary, accent, TextShade.WHITE);

            this.UpdatePaintColorControls();

            this.Invalidate();
            this.Refresh();
        }

        private Color PaintColorToColor(string name)
        {
            PaintColor.Colors color = _config.PaintColors[name];
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private Color DefaultPaintColorToColor(string name)
        {
            PaintColor.Colors color = _config.DefaultPaintColors[name];
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void UpdatePaintColorControls()
        {
            var colors = _config.PaintColors;

            Action<PictureBox, string> setColor = (pictureBox, name) =>
            {
                if (colors.ContainsKey(name))
                {
                    pictureBox.BackColor = PaintColorToColor(name);
                }
                else
                {
                    colors.Add(name, _config.DefaultPaintColors[name]);
                    pictureBox.BackColor = DefaultPaintColorToColor(name);
                }
            };

            // Players
            setColor(picPlayersLocalPlayer, "LocalPlayer");
            setColor(picPlayersTeammate, "Teammate");
            setColor(picPlayersTeamHover, "TeamHover");
            setColor(picPlayersMixtapeEnemy, "MixtapeEnemy");

            // Player Glow
            setColor(picPlayerGlowColor, "PlayerColorGlow");
            setColor(picPlayerGlowKnocked, "PlayerKnockedGlow");
            setColor(picPlayerGlowCrackedShield, "PlayerCrackedShieldGlow");
            setColor(picPlayerGlowGreyShield, "PlayerGreyShieldGlow");
            setColor(picPlayerGlowBlueShield, "PlayerBlueShieldGlow");
            setColor(picPlayerGlowPurpleShield, "PlayerPurpleShieldGlow");
            setColor(picPlayerGlowRedShield, "PlayerRedShieldGlow");

            // Item Glow
            setColor(picItemGlowRed, "ItemRedTierGlow");
            setColor(picItemGlowGold, "ItemGoldTierGlow");
            setColor(picItemGlowPurple, "ItemPurpleTierGlow");
            setColor(picItemGlowBlue, "ItemBlueTierGlow");
            setColor(picItemGlowGrey, "ItemGreyTierGlow");
            setColor(picItemGlowWeapons, "ItemWeaponGlow");
            setColor(picItemGlowAmmoBoxes, "ItemAmmoBoxGlow");

            // Other
            setColor(picOtherTextOutline, "TextOutline");
            setColor(picPlayersLastAlive, "LastAlive");
            setColor(picOtherPrimary, "Primary");
            setColor(picOtherPrimaryDark, "PrimaryDark");
            setColor(picOtherPrimaryLight, "PrimaryLight");
            setColor(picOtherAccent, "Accent");
        }

        private void UpdatePaintColorByName(string name, PictureBox pictureBox)
        {
            if (colDialog.ShowDialog() == DialogResult.OK)
            {
                Color col = colDialog.Color;
                pictureBox.BackColor = col;

                var paintColorToUse = new PaintColor.Colors
                {
                    A = col.A,
                    R = col.R,
                    G = col.G,
                    B = col.B
                };

                if (_config.PaintColors.ContainsKey(name))
                {
                    _config.PaintColors[name] = paintColorToUse;

                    if (Extensions.SKColors.ContainsKey(name))
                        Extensions.SKColors[name] = new SKColor(col.R, col.G, col.B, col.A);
                }
                else
                {
                    _config.PaintColors.Add(name, paintColorToUse);
                }
            }
        }
        #endregion

        #region Event Handlers
        // Players
        private void picPlayersLocalPlayer_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("LocalPlayer", picPlayersLocalPlayer);
        }

        private void picPlayersTeammate_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("Teammate", picPlayersTeammate);
        }

        private void picPlayersTeamHover_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("TeamHover", picPlayersTeamHover);
        }

        private void picPlayersMixtapeEnemy_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("MixtapeEnemy", picPlayersMixtapeEnemy);
        }

        private void picPlayersLastAlive_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("LastAlive", picPlayersLastAlive);
        }

        // Player Glow
        private void picPlayerGlowVisible_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerColorGlow", picPlayerGlowColor);
        }

        private void picPlayerGlowKnocked_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerKnockedGlow", picPlayerGlowKnocked);
        }

        private void picPlayerGlowCrackedShield_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerCrackedShieldGlow", picPlayerGlowCrackedShield);
        }

        private void picPlayerGlowGreyShield_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerGreyShieldGlow", picPlayerGlowGreyShield);
        }

        private void picPlayerGlowBlueShield_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerBlueShieldGlow", picPlayerGlowBlueShield);
        }

        private void picPlayerGlowPurpleShield_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerPurpleShieldGlow", picPlayerGlowPurpleShield);
        }

        private void picPlayerGlowRedShield_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PlayerRedShieldGlow", picPlayerGlowRedShield);
        }

        // Item Glow
        private void picItemGlowRed_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemRedTierGlow", picItemGlowRed);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowGold_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemGoldTierGlow", picItemGlowGold);
            
            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowPurple_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemPurpleTierGlow", picItemGlowPurple);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowBlue_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemBlueTierGlow", picItemGlowBlue);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowGrey_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemGreyTierGlow", picItemGlowGrey);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowWeapons_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemWeaponGlow", picItemGlowWeapons);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        private void picItemGlowAmmoBoxes_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("ItemAmmoBoGlow", picItemGlowAmmoBoxes);

            if (this.InGame)
                Memory.Game.GlowManager.RefreshItems = true;
        }

        // Other
        private void picOtherTextOutline_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("TextOutline", picOtherTextOutline);
        }

        private void picOtherPrimary_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("Primary", picOtherPrimary);
            UpdateThemeColors();
        }

        private void picOtherPrimaryDark_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PrimaryDark", picOtherPrimaryDark);
            UpdateThemeColors();
        }

        private void picOtherPrimaryLight_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("PrimaryLight", picOtherPrimaryLight);
            UpdateThemeColors();
        }

        private void picOtherAccent_Click(object sender, EventArgs e)
        {
            UpdatePaintColorByName("Accent", picOtherAccent);
            UpdateThemeColors();
        }

        private void btnResetTheme_Click(object sender, EventArgs e)
        {
            _config.PaintColors["Primary"] = _config.DefaultPaintColors["Primary"];
            _config.PaintColors["PrimaryDark"] = _config.DefaultPaintColors["PrimaryDark"];
            _config.PaintColors["PrimaryLight"] = _config.DefaultPaintColors["PrimaryLight"];
            _config.PaintColors["Accent"] = _config.DefaultPaintColors["Accent"];

            picOtherPrimary.BackColor = DefaultPaintColorToColor("Primary");
            picOtherPrimaryDark.BackColor = DefaultPaintColorToColor("PrimaryDark");
            picOtherPrimaryLight.BackColor = DefaultPaintColorToColor("PrimaryLight");
            picOtherAccent.BackColor = DefaultPaintColorToColor("Accent");

            UpdateThemeColors();
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}