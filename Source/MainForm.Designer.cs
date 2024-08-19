namespace apex_dma_radar
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components is not null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            colDialog = new ColorDialog();
            toolTip = new ToolTip(components);
            btnRestartRadar = new MaterialSkin.Controls.MaterialButton();
            swMapHelper = new MaterialSkin.Controls.MaterialSwitch();
            btnMapSetupApply = new MaterialSkin.Controls.MaterialButton();
            txtMapSetupScale = new MaterialSkin.Controls.MaterialTextBox2();
            txtMapSetupY = new MaterialSkin.Controls.MaterialTextBox2();
            txtMapSetupX = new MaterialSkin.Controls.MaterialTextBox2();
            btnToggleMapFree = new MaterialSkin.Controls.MaterialButton();
            swRadarStats = new MaterialSkin.Controls.MaterialSwitch();
            swRadarVsync = new MaterialSkin.Controls.MaterialSwitch();
            swMasterSwitch = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerGlow = new MaterialSkin.Controls.MaterialSwitch();
            sldrPlayerInfoFontSize = new MaterialSkin.Controls.MaterialSlider();
            cboPlayerInfoFont = new MaterialSkin.Controls.MaterialComboBox();
            sldrPlayerInfoFlagsFontSize = new MaterialSkin.Controls.MaterialSlider();
            cboPlayerInfoFlagsFont = new MaterialSkin.Controls.MaterialComboBox();
            sldrPlayerInfoAimlineOpacity = new MaterialSkin.Controls.MaterialSlider();
            swPlayerInfoAimline = new MaterialSkin.Controls.MaterialSwitch();
            sldrPlayerInfoAimlineLength = new MaterialSkin.Controls.MaterialSlider();
            swPlayerInfoHealth = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoDistance = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoHeight = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoFlags = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoActiveWeapon = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoName = new MaterialSkin.Controls.MaterialSwitch();
            cboPlayerInfoType = new MaterialSkin.Controls.MaterialComboBox();
            cboGlobalFont = new MaterialSkin.Controls.MaterialComboBox();
            sldrGlobalFontSize = new MaterialSkin.Controls.MaterialSlider();
            sldrUIScale = new MaterialSkin.Controls.MaterialSlider();
            btnResetTheme = new MaterialSkin.Controls.MaterialButton();
            swSpectators = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoLegend = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoShield = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoXPLevel = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoLastAlive = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoKnocked = new MaterialSkin.Controls.MaterialSwitch();
            swHighlightLastAlive = new MaterialSkin.Controls.MaterialSwitch();
            swPlayerInfoShieldLevel = new MaterialSkin.Controls.MaterialSwitch();
            sldrPlayerGlowInsideFunction = new MaterialSkin.Controls.MaterialSlider();
            sldrPlayerGlowOutlineFunction = new MaterialSkin.Controls.MaterialSlider();
            sldrPlayerGlowOutlineRadius = new MaterialSkin.Controls.MaterialSlider();
            sldrPlayerGlowBrightness = new MaterialSkin.Controls.MaterialSlider();
            swPlayerGlowShieldBased = new MaterialSkin.Controls.MaterialSwitch();
            sldrViewModelEffect = new MaterialSkin.Controls.MaterialSlider();
            swViewModelGlow = new MaterialSkin.Controls.MaterialSwitch();
            sldrItemGlowOutlineRadius = new MaterialSkin.Controls.MaterialSlider();
            sldrItemGlowOutlineFunction = new MaterialSkin.Controls.MaterialSlider();
            sldrItemGlowInsideFunction = new MaterialSkin.Controls.MaterialSlider();
            swItemGlow = new MaterialSkin.Controls.MaterialSwitch();
            sldrItemGlowBrightness = new MaterialSkin.Controls.MaterialSlider();
            swItemGlowColor = new MaterialSkin.Controls.MaterialSwitch();
            cboItemGlowType = new MaterialSkin.Controls.MaterialComboBox();
            tabControlMain = new MaterialSkin.Controls.MaterialTabControl();
            tabRadar = new TabPage();
            mcRadarStats = new MaterialSkin.Controls.MaterialCard();
            lblRadarPlayersAliveValue = new MaterialSkin.Controls.MaterialLabel();
            lblRadarPlayersAlive = new MaterialSkin.Controls.MaterialLabel();
            lblRadarMemSValue = new MaterialSkin.Controls.MaterialLabel();
            lblRadarFPSValue = new MaterialSkin.Controls.MaterialLabel();
            lblRadarPlayersValue = new MaterialSkin.Controls.MaterialLabel();
            lblRadarMemS = new MaterialSkin.Controls.MaterialLabel();
            lblRadarFPS = new MaterialSkin.Controls.MaterialLabel();
            lblRadarPlayers = new MaterialSkin.Controls.MaterialLabel();
            mcRadarSettings = new MaterialSkin.Controls.MaterialCard();
            mcRadarMapSetup = new MaterialSkin.Controls.MaterialCard();
            lblRadarMapSetup = new MaterialSkin.Controls.MaterialLabel();
            skMapCanvas = new SkiaSharp.Views.Desktop.SKGLControl();
            tabSettings = new TabPage();
            tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            tabControlSettings = new MaterialSkin.Controls.MaterialTabControl();
            tabSettingsGeneral = new TabPage();
            mcSettingsGeneralUI = new MaterialSkin.Controls.MaterialCard();
            sldrZoomSensitivity = new MaterialSkin.Controls.MaterialSlider();
            lblSettingsGeneralUI = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsGeneralPlayerInformation = new MaterialSkin.Controls.MaterialCard();
            lblSettingsGeneralPlayerInformation = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsGeneralRadar = new MaterialSkin.Controls.MaterialCard();
            lblSettingsGeneralRadar = new MaterialSkin.Controls.MaterialLabel();
            tabSettingsMemoryWriting = new TabPage();
            mcSettingsMemoryWritingItemGlow = new MaterialSkin.Controls.MaterialCard();
            txtItemGlowBrightness = new MaterialSkin.Controls.MaterialTextBox2();
            txtItemGlowOutlineRadius = new MaterialSkin.Controls.MaterialTextBox2();
            txtItemGlowOutlineFunction = new MaterialSkin.Controls.MaterialTextBox2();
            txtItemGlowInsideFunction = new MaterialSkin.Controls.MaterialTextBox2();
            lblSettingsMemoryWritingItemGlow = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsMemoryWritingViewModelGlow = new MaterialSkin.Controls.MaterialCard();
            txtViewModelEffect = new MaterialSkin.Controls.MaterialTextBox2();
            lblSettingsMemoryWritingViewModelGlow = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsMemoryWritingPlayerGlow = new MaterialSkin.Controls.MaterialCard();
            txtPlayerGlowBrightness = new MaterialSkin.Controls.MaterialTextBox2();
            txtPlayerGlowOutlineRadius = new MaterialSkin.Controls.MaterialTextBox2();
            txtPlayerGlowOutlineFunction = new MaterialSkin.Controls.MaterialTextBox2();
            txtPlayerGlowInsideFunction = new MaterialSkin.Controls.MaterialTextBox2();
            lblSettingsMemoryWritingPlayerGlow = new MaterialSkin.Controls.MaterialLabel();
            tabSettingsColors = new TabPage();
            mcSettingsColorsItemGlow = new MaterialSkin.Controls.MaterialCard();
            picItemGlowPurple = new PictureBox();
            lblSettingsColorsItemGlowPurpleTier = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowGold = new PictureBox();
            lblSettingsColorsItemGlowGoldTier = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowAmmoBoxes = new PictureBox();
            lblSettingsColorsItemGlowAmmoBoxes = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowWeapons = new PictureBox();
            lblSettingsColorsItemGlowWeapons = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowGrey = new PictureBox();
            lblSettingsColorsItemGlowGreyTier = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowBlue = new PictureBox();
            lblSettingsColorsItemGlowBlueTier = new MaterialSkin.Controls.MaterialLabel();
            picItemGlowRed = new PictureBox();
            lblSettingsColorsItemGlowRedTier = new MaterialSkin.Controls.MaterialLabel();
            lblSettingsColorsItemGlow = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsColorsPlayerGlow = new MaterialSkin.Controls.MaterialCard();
            picPlayerGlowCrackedShield = new PictureBox();
            lblSettingsColorsPlayerGlowCrackedShield = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowKnocked = new PictureBox();
            lblSettingsColorsPlayerGlowKnocked = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowRedShield = new PictureBox();
            lblSettingsColorsPlayerGlowRedShield = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowPurpleShield = new PictureBox();
            lblSettingsColorsPlayerGlowPurpleShield = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowBlueShield = new PictureBox();
            lblSettingsColorsPlayerGlowBlueShield = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowGreyShield = new PictureBox();
            lblSettingsColorsPlayerGlowGreyShield = new MaterialSkin.Controls.MaterialLabel();
            picPlayerGlowColor = new PictureBox();
            lblSettingsColorsPlayerGlowColor = new MaterialSkin.Controls.MaterialLabel();
            lblSettingsColorsPlayerGlow = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsColorsOther = new MaterialSkin.Controls.MaterialCard();
            picOtherAccent = new PictureBox();
            lblSettingsColorOtherAccent = new MaterialSkin.Controls.MaterialLabel();
            picOtherPrimaryLight = new PictureBox();
            lblSettingsColorOtherPrimaryLight = new MaterialSkin.Controls.MaterialLabel();
            picOtherPrimaryDark = new PictureBox();
            lblSettingsColorOtherPrimaryDark = new MaterialSkin.Controls.MaterialLabel();
            picOtherPrimary = new PictureBox();
            lblSettingsColorOtherPrimary = new MaterialSkin.Controls.MaterialLabel();
            picOtherTextOutline = new PictureBox();
            lblSettingsColorOtherTextOutline = new MaterialSkin.Controls.MaterialLabel();
            lblSettingsColorsOther = new MaterialSkin.Controls.MaterialLabel();
            mcSettingsColorsPlayers = new MaterialSkin.Controls.MaterialCard();
            picPlayersLastAlive = new PictureBox();
            lblSettingsColorPlayersLastAlive = new MaterialSkin.Controls.MaterialLabel();
            picPlayersMixtapeEnemy = new PictureBox();
            lblSettingsColorsPlayersMixtapeEnemy = new MaterialSkin.Controls.MaterialLabel();
            picPlayersTeamHover = new PictureBox();
            lblSettingsColorsPlayersTeamHover = new MaterialSkin.Controls.MaterialLabel();
            picPlayersTeammate = new PictureBox();
            lblSettingsColorsPlayersTeammate = new MaterialSkin.Controls.MaterialLabel();
            picPlayersLocalPlayer = new PictureBox();
            lblSettingsColorsPlayersLocalPlayer = new MaterialSkin.Controls.MaterialLabel();
            lblSettingsColorsPlayers = new MaterialSkin.Controls.MaterialLabel();
            iconList = new ImageList(components);
            tabControlMain.SuspendLayout();
            tabRadar.SuspendLayout();
            mcRadarStats.SuspendLayout();
            mcRadarSettings.SuspendLayout();
            mcRadarMapSetup.SuspendLayout();
            tabSettings.SuspendLayout();
            tabControlSettings.SuspendLayout();
            tabSettingsGeneral.SuspendLayout();
            mcSettingsGeneralUI.SuspendLayout();
            mcSettingsGeneralPlayerInformation.SuspendLayout();
            mcSettingsGeneralRadar.SuspendLayout();
            tabSettingsMemoryWriting.SuspendLayout();
            mcSettingsMemoryWritingItemGlow.SuspendLayout();
            mcSettingsMemoryWritingViewModelGlow.SuspendLayout();
            mcSettingsMemoryWritingPlayerGlow.SuspendLayout();
            tabSettingsColors.SuspendLayout();
            mcSettingsColorsItemGlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItemGlowPurple).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowGold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowAmmoBoxes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowWeapons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowGrey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowBlue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowRed).BeginInit();
            mcSettingsColorsPlayerGlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowCrackedShield).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowKnocked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowRedShield).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowPurpleShield).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowBlueShield).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowGreyShield).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowColor).BeginInit();
            mcSettingsColorsOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOtherAccent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimaryLight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimaryDark).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOtherTextOutline).BeginInit();
            mcSettingsColorsPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPlayersLastAlive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersMixtapeEnemy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersTeamHover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersTeammate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersLocalPlayer).BeginInit();
            SuspendLayout();
            // 
            // colDialog
            // 
            colDialog.FullOpen = true;
            // 
            // btnRestartRadar
            // 
            btnRestartRadar.AutoSize = false;
            btnRestartRadar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRestartRadar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRestartRadar.Depth = 0;
            btnRestartRadar.Font = new Font("Segoe UI", 8F);
            btnRestartRadar.HighEmphasis = true;
            btnRestartRadar.Icon = null;
            btnRestartRadar.Location = new Point(18, 291);
            btnRestartRadar.Margin = new Padding(4, 6, 4, 6);
            btnRestartRadar.MouseState = MaterialSkin.MouseState.HOVER;
            btnRestartRadar.Name = "btnRestartRadar";
            btnRestartRadar.NoAccentTextColor = Color.Empty;
            btnRestartRadar.Size = new Size(143, 36);
            btnRestartRadar.TabIndex = 2;
            btnRestartRadar.Text = "Restart Radar";
            toolTip.SetToolTip(btnRestartRadar, "Manually triggers radar restart");
            btnRestartRadar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRestartRadar.UseAccentColor = true;
            btnRestartRadar.UseVisualStyleBackColor = true;
            btnRestartRadar.Click += btnRestartRadar_Click;
            // 
            // swMapHelper
            // 
            swMapHelper.Depth = 0;
            swMapHelper.Font = new Font("Segoe UI", 9F);
            swMapHelper.Location = new Point(17, 105);
            swMapHelper.Margin = new Padding(0);
            swMapHelper.MouseLocation = new Point(-1, -1);
            swMapHelper.MouseState = MaterialSkin.MouseState.HOVER;
            swMapHelper.Name = "swMapHelper";
            swMapHelper.Ripple = true;
            swMapHelper.Size = new Size(146, 28);
            swMapHelper.TabIndex = 0;
            swMapHelper.Text = "Map Helper";
            toolTip.SetToolTip(swMapHelper, "Shows the 'Map Setup' panel");
            swMapHelper.UseVisualStyleBackColor = true;
            swMapHelper.CheckedChanged += swMapHelper_CheckedChanged;
            // 
            // btnMapSetupApply
            // 
            btnMapSetupApply.AutoSize = false;
            btnMapSetupApply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMapSetupApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMapSetupApply.Depth = 0;
            btnMapSetupApply.Font = new Font("Segoe UI", 8F);
            btnMapSetupApply.HighEmphasis = true;
            btnMapSetupApply.Icon = null;
            btnMapSetupApply.Location = new Point(369, 45);
            btnMapSetupApply.Margin = new Padding(4, 6, 4, 6);
            btnMapSetupApply.MouseState = MaterialSkin.MouseState.HOVER;
            btnMapSetupApply.Name = "btnMapSetupApply";
            btnMapSetupApply.NoAccentTextColor = Color.Empty;
            btnMapSetupApply.Size = new Size(57, 36);
            btnMapSetupApply.TabIndex = 35;
            btnMapSetupApply.Text = "Apply";
            toolTip.SetToolTip(btnMapSetupApply, "Manually triggers radar restart");
            btnMapSetupApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMapSetupApply.UseAccentColor = true;
            btnMapSetupApply.UseVisualStyleBackColor = true;
            btnMapSetupApply.Click += btnMapSetupApply_Click;
            // 
            // txtMapSetupScale
            // 
            txtMapSetupScale.AnimateReadOnly = false;
            txtMapSetupScale.BackgroundImageLayout = ImageLayout.None;
            txtMapSetupScale.CharacterCasing = CharacterCasing.Normal;
            txtMapSetupScale.Depth = 0;
            txtMapSetupScale.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMapSetupScale.HelperText = "Scale";
            txtMapSetupScale.HideSelection = true;
            txtMapSetupScale.Hint = "Scale";
            txtMapSetupScale.LeadingIcon = null;
            txtMapSetupScale.Location = new Point(185, 45);
            txtMapSetupScale.MaxLength = 32767;
            txtMapSetupScale.MouseState = MaterialSkin.MouseState.OUT;
            txtMapSetupScale.Name = "txtMapSetupScale";
            txtMapSetupScale.PasswordChar = '\0';
            txtMapSetupScale.PrefixSuffixText = null;
            txtMapSetupScale.ReadOnly = false;
            txtMapSetupScale.RightToLeft = RightToLeft.No;
            txtMapSetupScale.SelectedText = "";
            txtMapSetupScale.SelectionLength = 0;
            txtMapSetupScale.SelectionStart = 0;
            txtMapSetupScale.ShortcutsEnabled = true;
            txtMapSetupScale.Size = new Size(78, 36);
            txtMapSetupScale.TabIndex = 34;
            txtMapSetupScale.TabStop = false;
            txtMapSetupScale.TextAlign = HorizontalAlignment.Left;
            toolTip.SetToolTip(txtMapSetupScale, "The scale");
            txtMapSetupScale.TrailingIcon = null;
            txtMapSetupScale.UseSystemPasswordChar = false;
            txtMapSetupScale.UseTallSize = false;
            // 
            // txtMapSetupY
            // 
            txtMapSetupY.AnimateReadOnly = false;
            txtMapSetupY.BackgroundImageLayout = ImageLayout.None;
            txtMapSetupY.CharacterCasing = CharacterCasing.Normal;
            txtMapSetupY.Depth = 0;
            txtMapSetupY.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMapSetupY.HelperText = "Y";
            txtMapSetupY.HideSelection = true;
            txtMapSetupY.Hint = "Y";
            txtMapSetupY.LeadingIcon = null;
            txtMapSetupY.Location = new Point(101, 45);
            txtMapSetupY.MaxLength = 32767;
            txtMapSetupY.MouseState = MaterialSkin.MouseState.OUT;
            txtMapSetupY.Name = "txtMapSetupY";
            txtMapSetupY.PasswordChar = '\0';
            txtMapSetupY.PrefixSuffixText = null;
            txtMapSetupY.ReadOnly = false;
            txtMapSetupY.RightToLeft = RightToLeft.No;
            txtMapSetupY.SelectedText = "";
            txtMapSetupY.SelectionLength = 0;
            txtMapSetupY.SelectionStart = 0;
            txtMapSetupY.ShortcutsEnabled = true;
            txtMapSetupY.Size = new Size(78, 36);
            txtMapSetupY.TabIndex = 33;
            txtMapSetupY.TabStop = false;
            txtMapSetupY.TextAlign = HorizontalAlignment.Left;
            toolTip.SetToolTip(txtMapSetupY, "The Y coordinate");
            txtMapSetupY.TrailingIcon = null;
            txtMapSetupY.UseSystemPasswordChar = false;
            txtMapSetupY.UseTallSize = false;
            // 
            // txtMapSetupX
            // 
            txtMapSetupX.AnimateReadOnly = false;
            txtMapSetupX.BackgroundImageLayout = ImageLayout.None;
            txtMapSetupX.CharacterCasing = CharacterCasing.Normal;
            txtMapSetupX.Depth = 0;
            txtMapSetupX.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMapSetupX.HelperText = "X";
            txtMapSetupX.HideSelection = true;
            txtMapSetupX.Hint = "X";
            txtMapSetupX.LeadingIcon = null;
            txtMapSetupX.Location = new Point(17, 45);
            txtMapSetupX.MaxLength = 32767;
            txtMapSetupX.MouseState = MaterialSkin.MouseState.OUT;
            txtMapSetupX.Name = "txtMapSetupX";
            txtMapSetupX.PasswordChar = '\0';
            txtMapSetupX.PrefixSuffixText = null;
            txtMapSetupX.ReadOnly = false;
            txtMapSetupX.RightToLeft = RightToLeft.No;
            txtMapSetupX.SelectedText = "";
            txtMapSetupX.SelectionLength = 0;
            txtMapSetupX.SelectionStart = 0;
            txtMapSetupX.ShortcutsEnabled = true;
            txtMapSetupX.Size = new Size(78, 36);
            txtMapSetupX.TabIndex = 32;
            txtMapSetupX.TabStop = false;
            txtMapSetupX.TextAlign = HorizontalAlignment.Left;
            toolTip.SetToolTip(txtMapSetupX, "The X coordinate");
            txtMapSetupX.TrailingIcon = null;
            txtMapSetupX.UseSystemPasswordChar = false;
            txtMapSetupX.UseTallSize = false;
            // 
            // btnToggleMapFree
            // 
            btnToggleMapFree.AutoSize = false;
            btnToggleMapFree.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleMapFree.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnToggleMapFree.Depth = 0;
            btnToggleMapFree.HighEmphasis = true;
            btnToggleMapFree.Icon = Properties.Resources.tick;
            btnToggleMapFree.Location = new Point(11, 4);
            btnToggleMapFree.Margin = new Padding(4, 6, 4, 6);
            btnToggleMapFree.MouseState = MaterialSkin.MouseState.HOVER;
            btnToggleMapFree.Name = "btnToggleMapFree";
            btnToggleMapFree.NoAccentTextColor = Color.Empty;
            btnToggleMapFree.Size = new Size(107, 36);
            btnToggleMapFree.TabIndex = 47;
            btnToggleMapFree.Text = "Follow";
            toolTip.SetToolTip(btnToggleMapFree, "Toggles radar following functionality");
            btnToggleMapFree.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnToggleMapFree.UseAccentColor = true;
            btnToggleMapFree.UseVisualStyleBackColor = true;
            btnToggleMapFree.Click += btnToggleMapFree_Click;
            // 
            // swRadarStats
            // 
            swRadarStats.Depth = 0;
            swRadarStats.Font = new Font("Segoe UI", 9F);
            swRadarStats.Location = new Point(17, 75);
            swRadarStats.Margin = new Padding(0);
            swRadarStats.MouseLocation = new Point(-1, -1);
            swRadarStats.MouseState = MaterialSkin.MouseState.HOVER;
            swRadarStats.Name = "swRadarStats";
            swRadarStats.Ripple = true;
            swRadarStats.Size = new Size(144, 28);
            swRadarStats.TabIndex = 31;
            swRadarStats.Text = "Radar Stats";
            toolTip.SetToolTip(swRadarStats, "Shows radar stats on radar tab");
            swRadarStats.UseVisualStyleBackColor = true;
            swRadarStats.CheckedChanged += swRadarStats_CheckedChanged;
            // 
            // swRadarVsync
            // 
            swRadarVsync.Depth = 0;
            swRadarVsync.Font = new Font("Segoe UI", 9F);
            swRadarVsync.Location = new Point(17, 45);
            swRadarVsync.Margin = new Padding(0);
            swRadarVsync.MouseLocation = new Point(-1, -1);
            swRadarVsync.MouseState = MaterialSkin.MouseState.HOVER;
            swRadarVsync.Name = "swRadarVsync";
            swRadarVsync.Ripple = true;
            swRadarVsync.Size = new Size(118, 28);
            swRadarVsync.TabIndex = 32;
            swRadarVsync.Text = "VSync";
            toolTip.SetToolTip(swRadarVsync, "Shows radar stats on radar tab");
            swRadarVsync.UseVisualStyleBackColor = true;
            swRadarVsync.CheckedChanged += swRadarVsync_CheckedChanged;
            // 
            // swMasterSwitch
            // 
            swMasterSwitch.Depth = 0;
            swMasterSwitch.Font = new Font("Segoe UI", 9F);
            swMasterSwitch.Location = new Point(15, 14);
            swMasterSwitch.Margin = new Padding(0);
            swMasterSwitch.MouseLocation = new Point(-1, -1);
            swMasterSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            swMasterSwitch.Name = "swMasterSwitch";
            swMasterSwitch.Ripple = true;
            swMasterSwitch.Size = new Size(159, 28);
            swMasterSwitch.TabIndex = 36;
            swMasterSwitch.Text = "Master Switch";
            toolTip.SetToolTip(swMasterSwitch, "Shows exfiltration point names on radar");
            swMasterSwitch.UseVisualStyleBackColor = true;
            swMasterSwitch.CheckedChanged += swMasterSwitch_CheckedChanged;
            // 
            // swPlayerGlow
            // 
            swPlayerGlow.Depth = 0;
            swPlayerGlow.Font = new Font("Segoe UI", 9F);
            swPlayerGlow.Location = new Point(19, 45);
            swPlayerGlow.Margin = new Padding(0);
            swPlayerGlow.MouseLocation = new Point(-1, -1);
            swPlayerGlow.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerGlow.Name = "swPlayerGlow";
            swPlayerGlow.Ripple = true;
            swPlayerGlow.Size = new Size(119, 28);
            swPlayerGlow.TabIndex = 38;
            swPlayerGlow.Text = "Enabled";
            toolTip.SetToolTip(swPlayerGlow, "Enables glow on players");
            swPlayerGlow.UseVisualStyleBackColor = true;
            swPlayerGlow.CheckedChanged += swPlayerGlow_CheckedChanged;
            // 
            // sldrPlayerInfoFontSize
            // 
            sldrPlayerInfoFontSize.Depth = 0;
            sldrPlayerInfoFontSize.ForeColor = Color.Black;
            sldrPlayerInfoFontSize.Location = new Point(194, 170);
            sldrPlayerInfoFontSize.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerInfoFontSize.Name = "sldrPlayerInfoFontSize";
            sldrPlayerInfoFontSize.RangeMax = 36;
            sldrPlayerInfoFontSize.RangeMin = 1;
            sldrPlayerInfoFontSize.Size = new Size(241, 40);
            sldrPlayerInfoFontSize.TabIndex = 57;
            sldrPlayerInfoFontSize.Text = "Font Size";
            toolTip.SetToolTip(sldrPlayerInfoFontSize, "The font size to use for the text on the radar for this player type");
            sldrPlayerInfoFontSize.UseAccentColor = true;
            sldrPlayerInfoFontSize.Value = 13;
            sldrPlayerInfoFontSize.ValueMax = 36;
            sldrPlayerInfoFontSize.ValueSuffix = "px";
            sldrPlayerInfoFontSize.onValueChanged += sldrPlayerInfoFontSize_onValueChanged;
            // 
            // cboPlayerInfoFont
            // 
            cboPlayerInfoFont.AutoResize = false;
            cboPlayerInfoFont.BackColor = Color.FromArgb(255, 255, 255);
            cboPlayerInfoFont.Depth = 0;
            cboPlayerInfoFont.DrawMode = DrawMode.OwnerDrawVariable;
            cboPlayerInfoFont.DropDownHeight = 292;
            cboPlayerInfoFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlayerInfoFont.DropDownWidth = 121;
            cboPlayerInfoFont.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboPlayerInfoFont.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboPlayerInfoFont.FormattingEnabled = true;
            cboPlayerInfoFont.Hint = "Font";
            cboPlayerInfoFont.IntegralHeight = false;
            cboPlayerInfoFont.ItemHeight = 29;
            cboPlayerInfoFont.Location = new Point(17, 173);
            cboPlayerInfoFont.MaxDropDownItems = 10;
            cboPlayerInfoFont.MouseState = MaterialSkin.MouseState.OUT;
            cboPlayerInfoFont.Name = "cboPlayerInfoFont";
            cboPlayerInfoFont.Size = new Size(171, 35);
            cboPlayerInfoFont.StartIndex = 0;
            cboPlayerInfoFont.TabIndex = 56;
            toolTip.SetToolTip(cboPlayerInfoFont, "The font to use for this player type on the radar");
            cboPlayerInfoFont.UseTallSize = false;
            cboPlayerInfoFont.SelectedIndexChanged += cboPlayerInfoFont_SelectedIndexChanged;
            // 
            // sldrPlayerInfoFlagsFontSize
            // 
            sldrPlayerInfoFlagsFontSize.Depth = 0;
            sldrPlayerInfoFlagsFontSize.ForeColor = Color.Black;
            sldrPlayerInfoFlagsFontSize.Location = new Point(194, 287);
            sldrPlayerInfoFlagsFontSize.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerInfoFlagsFontSize.Name = "sldrPlayerInfoFlagsFontSize";
            sldrPlayerInfoFlagsFontSize.RangeMax = 36;
            sldrPlayerInfoFlagsFontSize.RangeMin = 1;
            sldrPlayerInfoFlagsFontSize.Size = new Size(241, 40);
            sldrPlayerInfoFlagsFontSize.TabIndex = 55;
            sldrPlayerInfoFlagsFontSize.Text = "Font Size";
            toolTip.SetToolTip(sldrPlayerInfoFlagsFontSize, "The font size to use for the text on the radar");
            sldrPlayerInfoFlagsFontSize.UseAccentColor = true;
            sldrPlayerInfoFlagsFontSize.Value = 13;
            sldrPlayerInfoFlagsFontSize.ValueMax = 36;
            sldrPlayerInfoFlagsFontSize.ValueSuffix = "px";
            sldrPlayerInfoFlagsFontSize.Visible = false;
            sldrPlayerInfoFlagsFontSize.onValueChanged += sldrPlayerInfoFlagsFontSize_onValueChanged;
            // 
            // cboPlayerInfoFlagsFont
            // 
            cboPlayerInfoFlagsFont.AutoResize = false;
            cboPlayerInfoFlagsFont.BackColor = Color.FromArgb(255, 255, 255);
            cboPlayerInfoFlagsFont.Depth = 0;
            cboPlayerInfoFlagsFont.DrawMode = DrawMode.OwnerDrawVariable;
            cboPlayerInfoFlagsFont.DropDownHeight = 292;
            cboPlayerInfoFlagsFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlayerInfoFlagsFont.DropDownWidth = 121;
            cboPlayerInfoFlagsFont.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboPlayerInfoFlagsFont.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboPlayerInfoFlagsFont.FormattingEnabled = true;
            cboPlayerInfoFlagsFont.Hint = "Flags Font";
            cboPlayerInfoFlagsFont.IntegralHeight = false;
            cboPlayerInfoFlagsFont.ItemHeight = 29;
            cboPlayerInfoFlagsFont.Location = new Point(17, 291);
            cboPlayerInfoFlagsFont.MaxDropDownItems = 10;
            cboPlayerInfoFlagsFont.MouseState = MaterialSkin.MouseState.OUT;
            cboPlayerInfoFlagsFont.Name = "cboPlayerInfoFlagsFont";
            cboPlayerInfoFlagsFont.Size = new Size(171, 35);
            cboPlayerInfoFlagsFont.StartIndex = 0;
            cboPlayerInfoFlagsFont.TabIndex = 54;
            toolTip.SetToolTip(cboPlayerInfoFlagsFont, "The font to use for flags for this player type on the radar");
            cboPlayerInfoFlagsFont.UseTallSize = false;
            cboPlayerInfoFlagsFont.Visible = false;
            cboPlayerInfoFlagsFont.SelectedIndexChanged += cboPlayerInfoFlagsFont_SelectedIndexChanged;
            // 
            // sldrPlayerInfoAimlineOpacity
            // 
            sldrPlayerInfoAimlineOpacity.Depth = 0;
            sldrPlayerInfoAimlineOpacity.ForeColor = Color.Black;
            sldrPlayerInfoAimlineOpacity.Location = new Point(341, 129);
            sldrPlayerInfoAimlineOpacity.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerInfoAimlineOpacity.Name = "sldrPlayerInfoAimlineOpacity";
            sldrPlayerInfoAimlineOpacity.RangeMax = 256;
            sldrPlayerInfoAimlineOpacity.RangeMin = 10;
            sldrPlayerInfoAimlineOpacity.ShowValue = false;
            sldrPlayerInfoAimlineOpacity.Size = new Size(195, 40);
            sldrPlayerInfoAimlineOpacity.TabIndex = 51;
            sldrPlayerInfoAimlineOpacity.Text = "Opacity";
            toolTip.SetToolTip(sldrPlayerInfoAimlineOpacity, "The transparency of the aimline");
            sldrPlayerInfoAimlineOpacity.UseAccentColor = true;
            sldrPlayerInfoAimlineOpacity.Value = 255;
            sldrPlayerInfoAimlineOpacity.ValueMax = 255;
            sldrPlayerInfoAimlineOpacity.Visible = false;
            sldrPlayerInfoAimlineOpacity.onValueChanged += sldrPlayerInfoAimlineOpacity_onValueChanged;
            // 
            // swPlayerInfoAimline
            // 
            swPlayerInfoAimline.Depth = 0;
            swPlayerInfoAimline.Font = new Font("Segoe UI", 9F);
            swPlayerInfoAimline.Location = new Point(17, 135);
            swPlayerInfoAimline.Margin = new Padding(0);
            swPlayerInfoAimline.MouseLocation = new Point(-1, -1);
            swPlayerInfoAimline.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoAimline.Name = "swPlayerInfoAimline";
            swPlayerInfoAimline.Ripple = true;
            swPlayerInfoAimline.Size = new Size(120, 28);
            swPlayerInfoAimline.TabIndex = 50;
            swPlayerInfoAimline.Text = "Aimline";
            toolTip.SetToolTip(swPlayerInfoAimline, "Shows player aimline on the radar");
            swPlayerInfoAimline.UseVisualStyleBackColor = false;
            swPlayerInfoAimline.CheckedChanged += swPlayerInfoAimline_CheckedChanged;
            // 
            // sldrPlayerInfoAimlineLength
            // 
            sldrPlayerInfoAimlineLength.Depth = 0;
            sldrPlayerInfoAimlineLength.ForeColor = Color.Black;
            sldrPlayerInfoAimlineLength.Location = new Point(140, 129);
            sldrPlayerInfoAimlineLength.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerInfoAimlineLength.Name = "sldrPlayerInfoAimlineLength";
            sldrPlayerInfoAimlineLength.RangeMax = 60;
            sldrPlayerInfoAimlineLength.RangeMin = 5;
            sldrPlayerInfoAimlineLength.ShowValue = false;
            sldrPlayerInfoAimlineLength.Size = new Size(195, 40);
            sldrPlayerInfoAimlineLength.TabIndex = 49;
            sldrPlayerInfoAimlineLength.Text = "Length";
            toolTip.SetToolTip(sldrPlayerInfoAimlineLength, "Length of the 'bar' or 'aimline'");
            sldrPlayerInfoAimlineLength.UseAccentColor = true;
            sldrPlayerInfoAimlineLength.Value = 15;
            sldrPlayerInfoAimlineLength.ValueMax = 60;
            sldrPlayerInfoAimlineLength.Visible = false;
            sldrPlayerInfoAimlineLength.onValueChanged += sldrPlayerInfoAimlineLength_onValueChanged;
            // 
            // swPlayerInfoHealth
            // 
            swPlayerInfoHealth.Depth = 0;
            swPlayerInfoHealth.Font = new Font("Segoe UI", 9F);
            swPlayerInfoHealth.Location = new Point(17, 255);
            swPlayerInfoHealth.Margin = new Padding(0);
            swPlayerInfoHealth.MouseLocation = new Point(-1, -1);
            swPlayerInfoHealth.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoHealth.Name = "swPlayerInfoHealth";
            swPlayerInfoHealth.Ripple = true;
            swPlayerInfoHealth.Size = new Size(109, 28);
            swPlayerInfoHealth.TabIndex = 48;
            swPlayerInfoHealth.Text = "Health";
            toolTip.SetToolTip(swPlayerInfoHealth, "Shows the health status of the player");
            swPlayerInfoHealth.UseVisualStyleBackColor = true;
            swPlayerInfoHealth.Visible = false;
            swPlayerInfoHealth.CheckedChanged += swPlayerInfoHealth_CheckedChanged;
            // 
            // swPlayerInfoDistance
            // 
            swPlayerInfoDistance.Depth = 0;
            swPlayerInfoDistance.Font = new Font("Segoe UI", 9F);
            swPlayerInfoDistance.Location = new Point(246, 100);
            swPlayerInfoDistance.Margin = new Padding(0);
            swPlayerInfoDistance.MouseLocation = new Point(-1, -1);
            swPlayerInfoDistance.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoDistance.Name = "swPlayerInfoDistance";
            swPlayerInfoDistance.Ripple = true;
            swPlayerInfoDistance.Size = new Size(131, 28);
            swPlayerInfoDistance.TabIndex = 47;
            swPlayerInfoDistance.Text = "Distance";
            toolTip.SetToolTip(swPlayerInfoDistance, "Shows player distance on the radar");
            swPlayerInfoDistance.UseVisualStyleBackColor = true;
            swPlayerInfoDistance.CheckedChanged += swPlayerInfoDistance_CheckedChanged;
            // 
            // swPlayerInfoHeight
            // 
            swPlayerInfoHeight.Depth = 0;
            swPlayerInfoHeight.Font = new Font("Segoe UI", 9F);
            swPlayerInfoHeight.Location = new Point(127, 100);
            swPlayerInfoHeight.Margin = new Padding(0);
            swPlayerInfoHeight.MouseLocation = new Point(-1, -1);
            swPlayerInfoHeight.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoHeight.Name = "swPlayerInfoHeight";
            swPlayerInfoHeight.Ripple = true;
            swPlayerInfoHeight.Size = new Size(123, 28);
            swPlayerInfoHeight.TabIndex = 46;
            swPlayerInfoHeight.Text = "Height";
            toolTip.SetToolTip(swPlayerInfoHeight, "Shows player height on the radar");
            swPlayerInfoHeight.UseVisualStyleBackColor = true;
            swPlayerInfoHeight.CheckedChanged += swPlayerInfoHeight_CheckedChanged;
            // 
            // swPlayerInfoFlags
            // 
            swPlayerInfoFlags.Depth = 0;
            swPlayerInfoFlags.Font = new Font("Segoe UI", 9F);
            swPlayerInfoFlags.Location = new Point(17, 220);
            swPlayerInfoFlags.Margin = new Padding(0);
            swPlayerInfoFlags.MouseLocation = new Point(-1, -1);
            swPlayerInfoFlags.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoFlags.Name = "swPlayerInfoFlags";
            swPlayerInfoFlags.Ripple = true;
            swPlayerInfoFlags.Size = new Size(99, 28);
            swPlayerInfoFlags.TabIndex = 44;
            swPlayerInfoFlags.Text = "Flags";
            toolTip.SetToolTip(swPlayerInfoFlags, "Toggles displaying flags on players");
            swPlayerInfoFlags.UseVisualStyleBackColor = true;
            swPlayerInfoFlags.CheckedChanged += swPlayerInfoFlags_CheckedChanged;
            // 
            // swPlayerInfoActiveWeapon
            // 
            swPlayerInfoActiveWeapon.Depth = 0;
            swPlayerInfoActiveWeapon.Font = new Font("Segoe UI", 9F);
            swPlayerInfoActiveWeapon.Location = new Point(116, 220);
            swPlayerInfoActiveWeapon.Margin = new Padding(0);
            swPlayerInfoActiveWeapon.MouseLocation = new Point(-1, -1);
            swPlayerInfoActiveWeapon.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoActiveWeapon.Name = "swPlayerInfoActiveWeapon";
            swPlayerInfoActiveWeapon.Ripple = true;
            swPlayerInfoActiveWeapon.Size = new Size(166, 28);
            swPlayerInfoActiveWeapon.TabIndex = 42;
            swPlayerInfoActiveWeapon.Text = "Active Weapon";
            toolTip.SetToolTip(swPlayerInfoActiveWeapon, "Shows the players active weapon in their hand");
            swPlayerInfoActiveWeapon.UseVisualStyleBackColor = true;
            swPlayerInfoActiveWeapon.Visible = false;
            swPlayerInfoActiveWeapon.CheckedChanged += swPlayerInfoActiveWeapon_CheckedChanged;
            // 
            // swPlayerInfoName
            // 
            swPlayerInfoName.Depth = 0;
            swPlayerInfoName.Font = new Font("Segoe UI", 9F);
            swPlayerInfoName.Location = new Point(17, 100);
            swPlayerInfoName.Margin = new Padding(0);
            swPlayerInfoName.MouseLocation = new Point(-1, -1);
            swPlayerInfoName.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoName.Name = "swPlayerInfoName";
            swPlayerInfoName.Ripple = true;
            swPlayerInfoName.Size = new Size(110, 28);
            swPlayerInfoName.TabIndex = 40;
            swPlayerInfoName.Text = "Name";
            toolTip.SetToolTip(swPlayerInfoName, "Shows player names on the radar");
            swPlayerInfoName.UseVisualStyleBackColor = true;
            swPlayerInfoName.CheckedChanged += swPlayerInfoName_CheckedChanged;
            // 
            // cboPlayerInfoType
            // 
            cboPlayerInfoType.AutoResize = false;
            cboPlayerInfoType.BackColor = Color.FromArgb(255, 255, 255);
            cboPlayerInfoType.Depth = 0;
            cboPlayerInfoType.DrawMode = DrawMode.OwnerDrawVariable;
            cboPlayerInfoType.DropDownHeight = 292;
            cboPlayerInfoType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlayerInfoType.DropDownWidth = 121;
            cboPlayerInfoType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboPlayerInfoType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboPlayerInfoType.FormattingEnabled = true;
            cboPlayerInfoType.Hint = "Faction";
            cboPlayerInfoType.IntegralHeight = false;
            cboPlayerInfoType.ItemHeight = 29;
            cboPlayerInfoType.Items.AddRange(new object[] { "Player", "LocalPlayer", "Teammate", "Dummy" });
            cboPlayerInfoType.Location = new Point(17, 47);
            cboPlayerInfoType.MaxDropDownItems = 10;
            cboPlayerInfoType.MouseState = MaterialSkin.MouseState.OUT;
            cboPlayerInfoType.Name = "cboPlayerInfoType";
            cboPlayerInfoType.Size = new Size(171, 35);
            cboPlayerInfoType.StartIndex = 0;
            cboPlayerInfoType.TabIndex = 39;
            toolTip.SetToolTip(cboPlayerInfoType, "The faction to edit for displaying on the radar");
            cboPlayerInfoType.UseTallSize = false;
            cboPlayerInfoType.SelectedIndexChanged += cboPlayerInfoType_SelectedIndexChanged;
            // 
            // cboGlobalFont
            // 
            cboGlobalFont.AutoResize = false;
            cboGlobalFont.BackColor = Color.FromArgb(255, 255, 255);
            cboGlobalFont.Depth = 0;
            cboGlobalFont.DrawMode = DrawMode.OwnerDrawVariable;
            cboGlobalFont.DropDownHeight = 292;
            cboGlobalFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGlobalFont.DropDownWidth = 121;
            cboGlobalFont.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboGlobalFont.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboGlobalFont.FormattingEnabled = true;
            cboGlobalFont.Hint = "Global Font";
            cboGlobalFont.IntegralHeight = false;
            cboGlobalFont.ItemHeight = 29;
            cboGlobalFont.Location = new Point(16, 43);
            cboGlobalFont.MaxDropDownItems = 10;
            cboGlobalFont.MouseState = MaterialSkin.MouseState.OUT;
            cboGlobalFont.Name = "cboGlobalFont";
            cboGlobalFont.Size = new Size(171, 35);
            cboGlobalFont.StartIndex = 0;
            cboGlobalFont.TabIndex = 39;
            toolTip.SetToolTip(cboGlobalFont, "The font to use for radar text");
            cboGlobalFont.UseTallSize = false;
            cboGlobalFont.SelectedIndexChanged += cboGlobalFont_SelectedIndexChanged;
            // 
            // sldrGlobalFontSize
            // 
            sldrGlobalFontSize.Depth = 0;
            sldrGlobalFontSize.ForeColor = Color.Black;
            sldrGlobalFontSize.Location = new Point(193, 38);
            sldrGlobalFontSize.MouseState = MaterialSkin.MouseState.HOVER;
            sldrGlobalFontSize.Name = "sldrGlobalFontSize";
            sldrGlobalFontSize.RangeMax = 36;
            sldrGlobalFontSize.RangeMin = 1;
            sldrGlobalFontSize.Size = new Size(241, 40);
            sldrGlobalFontSize.TabIndex = 39;
            sldrGlobalFontSize.Text = "Font Size";
            toolTip.SetToolTip(sldrGlobalFontSize, "The font size to use for the text on the radar");
            sldrGlobalFontSize.UseAccentColor = true;
            sldrGlobalFontSize.Value = 13;
            sldrGlobalFontSize.ValueMax = 36;
            sldrGlobalFontSize.ValueSuffix = "px";
            sldrGlobalFontSize.onValueChanged += sldrGlobalFontSize_onValueChanged;
            // 
            // sldrUIScale
            // 
            sldrUIScale.Depth = 0;
            sldrUIScale.ForeColor = Color.Black;
            sldrUIScale.Location = new Point(16, 120);
            sldrUIScale.MouseState = MaterialSkin.MouseState.HOVER;
            sldrUIScale.Name = "sldrUIScale";
            sldrUIScale.RangeMax = 200;
            sldrUIScale.RangeMin = 10;
            sldrUIScale.Size = new Size(241, 40);
            sldrUIScale.TabIndex = 31;
            sldrUIScale.Text = "UI Scale";
            toolTip.SetToolTip(sldrUIScale, "Scales the UI fonts etc, useful for larger screen resolutions");
            sldrUIScale.UseAccentColor = true;
            sldrUIScale.Value = 100;
            sldrUIScale.ValueMax = 200;
            sldrUIScale.ValueSuffix = "%";
            sldrUIScale.onValueChanged += sldrUIScale_onValueChanged;
            // 
            // btnResetTheme
            // 
            btnResetTheme.AutoSize = false;
            btnResetTheme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnResetTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnResetTheme.Depth = 0;
            btnResetTheme.Font = new Font("Segoe UI", 8F);
            btnResetTheme.HighEmphasis = true;
            btnResetTheme.Icon = null;
            btnResetTheme.Location = new Point(74, 273);
            btnResetTheme.Margin = new Padding(4, 6, 4, 6);
            btnResetTheme.MouseState = MaterialSkin.MouseState.HOVER;
            btnResetTheme.Name = "btnResetTheme";
            btnResetTheme.NoAccentTextColor = Color.Empty;
            btnResetTheme.Size = new Size(105, 36);
            btnResetTheme.TabIndex = 59;
            btnResetTheme.Text = "Reset Theme";
            toolTip.SetToolTip(btnResetTheme, "Manually triggers radar restart");
            btnResetTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnResetTheme.UseAccentColor = true;
            btnResetTheme.UseVisualStyleBackColor = true;
            btnResetTheme.Click += btnResetTheme_Click;
            // 
            // swSpectators
            // 
            swSpectators.Depth = 0;
            swSpectators.Font = new Font("Segoe UI", 9F);
            swSpectators.Location = new Point(17, 135);
            swSpectators.Margin = new Padding(0);
            swSpectators.MouseLocation = new Point(-1, -1);
            swSpectators.MouseState = MaterialSkin.MouseState.HOVER;
            swSpectators.Name = "swSpectators";
            swSpectators.Ripple = true;
            swSpectators.Size = new Size(143, 28);
            swSpectators.TabIndex = 33;
            swSpectators.Text = "Spectators";
            toolTip.SetToolTip(swSpectators, "Shows a list of spectators for the localplayer or spectated player");
            swSpectators.UseVisualStyleBackColor = true;
            swSpectators.CheckedChanged += swSpectators_CheckedChanged;
            // 
            // swPlayerInfoLegend
            // 
            swPlayerInfoLegend.Depth = 0;
            swPlayerInfoLegend.Font = new Font("Segoe UI", 9F);
            swPlayerInfoLegend.Location = new Point(282, 220);
            swPlayerInfoLegend.Margin = new Padding(0);
            swPlayerInfoLegend.MouseLocation = new Point(-1, -1);
            swPlayerInfoLegend.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoLegend.Name = "swPlayerInfoLegend";
            swPlayerInfoLegend.Ripple = true;
            swPlayerInfoLegend.Size = new Size(114, 28);
            swPlayerInfoLegend.TabIndex = 58;
            swPlayerInfoLegend.Text = "Legend";
            toolTip.SetToolTip(swPlayerInfoLegend, "Shows the players legend");
            swPlayerInfoLegend.UseVisualStyleBackColor = true;
            swPlayerInfoLegend.Visible = false;
            swPlayerInfoLegend.CheckedChanged += swPlayerInfoLegend_CheckedChanged;
            // 
            // swPlayerInfoShield
            // 
            swPlayerInfoShield.Depth = 0;
            swPlayerInfoShield.Font = new Font("Segoe UI", 9F);
            swPlayerInfoShield.Location = new Point(126, 255);
            swPlayerInfoShield.Margin = new Padding(0);
            swPlayerInfoShield.MouseLocation = new Point(-1, -1);
            swPlayerInfoShield.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoShield.Name = "swPlayerInfoShield";
            swPlayerInfoShield.Ripple = true;
            swPlayerInfoShield.Size = new Size(109, 28);
            swPlayerInfoShield.TabIndex = 59;
            swPlayerInfoShield.Text = "Shield";
            toolTip.SetToolTip(swPlayerInfoShield, "Shows the shield status of the player");
            swPlayerInfoShield.UseVisualStyleBackColor = true;
            swPlayerInfoShield.Visible = false;
            swPlayerInfoShield.CheckedChanged += swPlayerInfoShield_CheckedChanged;
            // 
            // swPlayerInfoXPLevel
            // 
            swPlayerInfoXPLevel.Depth = 0;
            swPlayerInfoXPLevel.Font = new Font("Segoe UI", 9F);
            swPlayerInfoXPLevel.Location = new Point(396, 220);
            swPlayerInfoXPLevel.Margin = new Padding(0);
            swPlayerInfoXPLevel.MouseLocation = new Point(-1, -1);
            swPlayerInfoXPLevel.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoXPLevel.Name = "swPlayerInfoXPLevel";
            swPlayerInfoXPLevel.Ripple = true;
            swPlayerInfoXPLevel.Size = new Size(124, 28);
            swPlayerInfoXPLevel.TabIndex = 60;
            swPlayerInfoXPLevel.Text = "XP Level";
            toolTip.SetToolTip(swPlayerInfoXPLevel, "Shows the XP level of the player");
            swPlayerInfoXPLevel.UseVisualStyleBackColor = true;
            swPlayerInfoXPLevel.Visible = false;
            swPlayerInfoXPLevel.CheckedChanged += swPlayerInfoXPLevel_CheckedChanged;
            // 
            // swPlayerInfoLastAlive
            // 
            swPlayerInfoLastAlive.Depth = 0;
            swPlayerInfoLastAlive.Font = new Font("Segoe UI", 9F);
            swPlayerInfoLastAlive.Location = new Point(506, 255);
            swPlayerInfoLastAlive.Margin = new Padding(0);
            swPlayerInfoLastAlive.MouseLocation = new Point(-1, -1);
            swPlayerInfoLastAlive.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoLastAlive.Name = "swPlayerInfoLastAlive";
            swPlayerInfoLastAlive.Ripple = true;
            swPlayerInfoLastAlive.Size = new Size(132, 28);
            swPlayerInfoLastAlive.TabIndex = 61;
            swPlayerInfoLastAlive.Text = "Last Alive";
            toolTip.SetToolTip(swPlayerInfoLastAlive, "Shows if the player is the last alive in their squad");
            swPlayerInfoLastAlive.UseVisualStyleBackColor = true;
            swPlayerInfoLastAlive.Visible = false;
            swPlayerInfoLastAlive.CheckedChanged += swPlayerInfoLastAlive_CheckedChanged;
            // 
            // swPlayerInfoKnocked
            // 
            swPlayerInfoKnocked.Depth = 0;
            swPlayerInfoKnocked.Font = new Font("Segoe UI", 9F);
            swPlayerInfoKnocked.Location = new Point(383, 255);
            swPlayerInfoKnocked.Margin = new Padding(0);
            swPlayerInfoKnocked.MouseLocation = new Point(-1, -1);
            swPlayerInfoKnocked.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoKnocked.Name = "swPlayerInfoKnocked";
            swPlayerInfoKnocked.Ripple = true;
            swPlayerInfoKnocked.Size = new Size(123, 28);
            swPlayerInfoKnocked.TabIndex = 62;
            swPlayerInfoKnocked.Text = "Knocked";
            toolTip.SetToolTip(swPlayerInfoKnocked, "Shows the knocked status of the player");
            swPlayerInfoKnocked.UseVisualStyleBackColor = true;
            swPlayerInfoKnocked.Visible = false;
            swPlayerInfoKnocked.CheckedChanged += swPlayerInfoKnocked_CheckedChanged;
            // 
            // swHighlightLastAlive
            // 
            swHighlightLastAlive.Depth = 0;
            swHighlightLastAlive.Font = new Font("Segoe UI", 9F);
            swHighlightLastAlive.Location = new Point(16, 163);
            swHighlightLastAlive.Margin = new Padding(0);
            swHighlightLastAlive.MouseLocation = new Point(-1, -1);
            swHighlightLastAlive.MouseState = MaterialSkin.MouseState.HOVER;
            swHighlightLastAlive.Name = "swHighlightLastAlive";
            swHighlightLastAlive.Ripple = true;
            swHighlightLastAlive.Size = new Size(202, 28);
            swHighlightLastAlive.TabIndex = 64;
            swHighlightLastAlive.Text = "Highlight Last Alive";
            toolTip.SetToolTip(swHighlightLastAlive, " Highlights the last alive player in a squad");
            swHighlightLastAlive.UseVisualStyleBackColor = true;
            swHighlightLastAlive.CheckedChanged += swHighlightLastAlive_CheckedChanged;
            // 
            // swPlayerInfoShieldLevel
            // 
            swPlayerInfoShieldLevel.Depth = 0;
            swPlayerInfoShieldLevel.Font = new Font("Segoe UI", 9F);
            swPlayerInfoShieldLevel.Location = new Point(235, 255);
            swPlayerInfoShieldLevel.Margin = new Padding(0);
            swPlayerInfoShieldLevel.MouseLocation = new Point(-1, -1);
            swPlayerInfoShieldLevel.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerInfoShieldLevel.Name = "swPlayerInfoShieldLevel";
            swPlayerInfoShieldLevel.Ripple = true;
            swPlayerInfoShieldLevel.Size = new Size(148, 28);
            swPlayerInfoShieldLevel.TabIndex = 63;
            swPlayerInfoShieldLevel.Text = "Shield Level";
            toolTip.SetToolTip(swPlayerInfoShieldLevel, "Shows the shield level of the player");
            swPlayerInfoShieldLevel.UseVisualStyleBackColor = true;
            swPlayerInfoShieldLevel.Visible = false;
            swPlayerInfoShieldLevel.CheckedChanged += swPlayerInfoShieldLevel_CheckedChanged;
            // 
            // sldrPlayerGlowInsideFunction
            // 
            sldrPlayerGlowInsideFunction.Depth = 0;
            sldrPlayerGlowInsideFunction.ForeColor = Color.Black;
            sldrPlayerGlowInsideFunction.Location = new Point(19, 111);
            sldrPlayerGlowInsideFunction.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerGlowInsideFunction.Name = "sldrPlayerGlowInsideFunction";
            sldrPlayerGlowInsideFunction.RangeMax = 255;
            sldrPlayerGlowInsideFunction.ShowValue = false;
            sldrPlayerGlowInsideFunction.Size = new Size(295, 40);
            sldrPlayerGlowInsideFunction.TabIndex = 39;
            sldrPlayerGlowInsideFunction.Text = "Inside Function";
            toolTip.SetToolTip(sldrPlayerGlowInsideFunction, "Adjusts glow inside function");
            sldrPlayerGlowInsideFunction.UseAccentColor = true;
            sldrPlayerGlowInsideFunction.Value = 100;
            sldrPlayerGlowInsideFunction.ValueMax = 255;
            sldrPlayerGlowInsideFunction.onValueChanged += sldrPlayerGlowInsideFunction_onValueChanged;
            // 
            // sldrPlayerGlowOutlineFunction
            // 
            sldrPlayerGlowOutlineFunction.Depth = 0;
            sldrPlayerGlowOutlineFunction.ForeColor = Color.Black;
            sldrPlayerGlowOutlineFunction.Location = new Point(19, 157);
            sldrPlayerGlowOutlineFunction.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerGlowOutlineFunction.Name = "sldrPlayerGlowOutlineFunction";
            sldrPlayerGlowOutlineFunction.RangeMax = 255;
            sldrPlayerGlowOutlineFunction.ShowValue = false;
            sldrPlayerGlowOutlineFunction.Size = new Size(295, 40);
            sldrPlayerGlowOutlineFunction.TabIndex = 41;
            sldrPlayerGlowOutlineFunction.Text = "Outline Function";
            toolTip.SetToolTip(sldrPlayerGlowOutlineFunction, "Adjusts glow outline function");
            sldrPlayerGlowOutlineFunction.UseAccentColor = true;
            sldrPlayerGlowOutlineFunction.Value = 100;
            sldrPlayerGlowOutlineFunction.ValueMax = 255;
            sldrPlayerGlowOutlineFunction.onValueChanged += sldrPlayerGlowOutlineFunction_onValueChanged;
            // 
            // sldrPlayerGlowOutlineRadius
            // 
            sldrPlayerGlowOutlineRadius.Depth = 0;
            sldrPlayerGlowOutlineRadius.ForeColor = Color.Black;
            sldrPlayerGlowOutlineRadius.Location = new Point(19, 203);
            sldrPlayerGlowOutlineRadius.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerGlowOutlineRadius.Name = "sldrPlayerGlowOutlineRadius";
            sldrPlayerGlowOutlineRadius.RangeMax = 255;
            sldrPlayerGlowOutlineRadius.ShowValue = false;
            sldrPlayerGlowOutlineRadius.Size = new Size(295, 40);
            sldrPlayerGlowOutlineRadius.TabIndex = 43;
            sldrPlayerGlowOutlineRadius.Text = "Outline Radius";
            toolTip.SetToolTip(sldrPlayerGlowOutlineRadius, "Adjusts outline function radius");
            sldrPlayerGlowOutlineRadius.UseAccentColor = true;
            sldrPlayerGlowOutlineRadius.Value = 100;
            sldrPlayerGlowOutlineRadius.ValueMax = 255;
            sldrPlayerGlowOutlineRadius.onValueChanged += sldrPlayerGlowOutsideRadius_onValueChanged;
            // 
            // sldrPlayerGlowBrightness
            // 
            sldrPlayerGlowBrightness.Depth = 0;
            sldrPlayerGlowBrightness.ForeColor = Color.Black;
            sldrPlayerGlowBrightness.Location = new Point(19, 249);
            sldrPlayerGlowBrightness.MouseState = MaterialSkin.MouseState.HOVER;
            sldrPlayerGlowBrightness.Name = "sldrPlayerGlowBrightness";
            sldrPlayerGlowBrightness.RangeMax = 255;
            sldrPlayerGlowBrightness.ShowValue = false;
            sldrPlayerGlowBrightness.Size = new Size(295, 40);
            sldrPlayerGlowBrightness.TabIndex = 45;
            sldrPlayerGlowBrightness.Text = "Brightness";
            toolTip.SetToolTip(sldrPlayerGlowBrightness, "Adjusts the brightness of the glow");
            sldrPlayerGlowBrightness.UseAccentColor = true;
            sldrPlayerGlowBrightness.Value = 100;
            sldrPlayerGlowBrightness.ValueMax = 255;
            sldrPlayerGlowBrightness.onValueChanged += sldrPlayerGlowBrightness_onValueChanged;
            // 
            // swPlayerGlowShieldBased
            // 
            swPlayerGlowShieldBased.Depth = 0;
            swPlayerGlowShieldBased.Font = new Font("Segoe UI", 9F);
            swPlayerGlowShieldBased.Location = new Point(19, 80);
            swPlayerGlowShieldBased.Margin = new Padding(0);
            swPlayerGlowShieldBased.MouseLocation = new Point(-1, -1);
            swPlayerGlowShieldBased.MouseState = MaterialSkin.MouseState.HOVER;
            swPlayerGlowShieldBased.Name = "swPlayerGlowShieldBased";
            swPlayerGlowShieldBased.Ripple = true;
            swPlayerGlowShieldBased.Size = new Size(196, 28);
            swPlayerGlowShieldBased.TabIndex = 47;
            swPlayerGlowShieldBased.Text = "Shield Based Color";
            toolTip.SetToolTip(swPlayerGlowShieldBased, "Enables glow on players");
            swPlayerGlowShieldBased.UseVisualStyleBackColor = true;
            swPlayerGlowShieldBased.CheckedChanged += swPlayerGlowShieldBased_CheckedChanged;
            // 
            // sldrViewModelEffect
            // 
            sldrViewModelEffect.Depth = 0;
            sldrViewModelEffect.ForeColor = Color.Black;
            sldrViewModelEffect.Location = new Point(17, 76);
            sldrViewModelEffect.MouseState = MaterialSkin.MouseState.HOVER;
            sldrViewModelEffect.Name = "sldrViewModelEffect";
            sldrViewModelEffect.RangeMax = 83;
            sldrViewModelEffect.ShowValue = false;
            sldrViewModelEffect.Size = new Size(295, 40);
            sldrViewModelEffect.TabIndex = 39;
            sldrViewModelEffect.Text = "Effect";
            toolTip.SetToolTip(sldrViewModelEffect, "Adjusts the effect of the view model");
            sldrViewModelEffect.UseAccentColor = true;
            sldrViewModelEffect.Value = 77;
            sldrViewModelEffect.ValueMax = 83;
            sldrViewModelEffect.onValueChanged += sldrViewModelEffect_onValueChanged;
            // 
            // swViewModelGlow
            // 
            swViewModelGlow.Depth = 0;
            swViewModelGlow.Font = new Font("Segoe UI", 9F);
            swViewModelGlow.Location = new Point(17, 45);
            swViewModelGlow.Margin = new Padding(0);
            swViewModelGlow.MouseLocation = new Point(-1, -1);
            swViewModelGlow.MouseState = MaterialSkin.MouseState.HOVER;
            swViewModelGlow.Name = "swViewModelGlow";
            swViewModelGlow.Ripple = true;
            swViewModelGlow.Size = new Size(119, 28);
            swViewModelGlow.TabIndex = 38;
            swViewModelGlow.Text = "Enabled";
            toolTip.SetToolTip(swViewModelGlow, "Enables glow on view model");
            swViewModelGlow.UseVisualStyleBackColor = true;
            swViewModelGlow.CheckedChanged += swViewModelGlow_CheckedChanged;
            // 
            // sldrItemGlowOutlineRadius
            // 
            sldrItemGlowOutlineRadius.Depth = 0;
            sldrItemGlowOutlineRadius.ForeColor = Color.Black;
            sldrItemGlowOutlineRadius.Location = new Point(17, 203);
            sldrItemGlowOutlineRadius.MouseState = MaterialSkin.MouseState.HOVER;
            sldrItemGlowOutlineRadius.Name = "sldrItemGlowOutlineRadius";
            sldrItemGlowOutlineRadius.RangeMax = 255;
            sldrItemGlowOutlineRadius.ShowValue = false;
            sldrItemGlowOutlineRadius.Size = new Size(295, 40);
            sldrItemGlowOutlineRadius.TabIndex = 43;
            sldrItemGlowOutlineRadius.Text = "Outline Radius";
            toolTip.SetToolTip(sldrItemGlowOutlineRadius, "Adjusts outline function radius");
            sldrItemGlowOutlineRadius.UseAccentColor = true;
            sldrItemGlowOutlineRadius.Value = 100;
            sldrItemGlowOutlineRadius.ValueMax = 255;
            sldrItemGlowOutlineRadius.onValueChanged += sldrItemGlowOutlineRadius_onValueChanged;
            // 
            // sldrItemGlowOutlineFunction
            // 
            sldrItemGlowOutlineFunction.Depth = 0;
            sldrItemGlowOutlineFunction.ForeColor = Color.Black;
            sldrItemGlowOutlineFunction.Location = new Point(17, 157);
            sldrItemGlowOutlineFunction.MouseState = MaterialSkin.MouseState.HOVER;
            sldrItemGlowOutlineFunction.Name = "sldrItemGlowOutlineFunction";
            sldrItemGlowOutlineFunction.RangeMax = 255;
            sldrItemGlowOutlineFunction.ShowValue = false;
            sldrItemGlowOutlineFunction.Size = new Size(295, 40);
            sldrItemGlowOutlineFunction.TabIndex = 41;
            sldrItemGlowOutlineFunction.Text = "Outline Function";
            toolTip.SetToolTip(sldrItemGlowOutlineFunction, "Adjusts glow outline function");
            sldrItemGlowOutlineFunction.UseAccentColor = true;
            sldrItemGlowOutlineFunction.Value = 100;
            sldrItemGlowOutlineFunction.ValueMax = 255;
            sldrItemGlowOutlineFunction.onValueChanged += sldrItemGlowOutlineFunction_onValueChanged;
            // 
            // sldrItemGlowInsideFunction
            // 
            sldrItemGlowInsideFunction.Depth = 0;
            sldrItemGlowInsideFunction.ForeColor = Color.Black;
            sldrItemGlowInsideFunction.Location = new Point(17, 111);
            sldrItemGlowInsideFunction.MouseState = MaterialSkin.MouseState.HOVER;
            sldrItemGlowInsideFunction.Name = "sldrItemGlowInsideFunction";
            sldrItemGlowInsideFunction.RangeMax = 255;
            sldrItemGlowInsideFunction.ShowValue = false;
            sldrItemGlowInsideFunction.Size = new Size(295, 40);
            sldrItemGlowInsideFunction.TabIndex = 39;
            sldrItemGlowInsideFunction.Text = "Inside Function";
            toolTip.SetToolTip(sldrItemGlowInsideFunction, "Adjusts glow inside function");
            sldrItemGlowInsideFunction.UseAccentColor = true;
            sldrItemGlowInsideFunction.Value = 100;
            sldrItemGlowInsideFunction.ValueMax = 255;
            sldrItemGlowInsideFunction.onValueChanged += sldrItemGlowInsideFunction_onValueChanged;
            // 
            // swItemGlow
            // 
            swItemGlow.Depth = 0;
            swItemGlow.Font = new Font("Segoe UI", 9F);
            swItemGlow.Location = new Point(17, 80);
            swItemGlow.Margin = new Padding(0);
            swItemGlow.MouseLocation = new Point(-1, -1);
            swItemGlow.MouseState = MaterialSkin.MouseState.HOVER;
            swItemGlow.Name = "swItemGlow";
            swItemGlow.Ripple = true;
            swItemGlow.Size = new Size(119, 28);
            swItemGlow.TabIndex = 38;
            swItemGlow.Text = "Enabled";
            toolTip.SetToolTip(swItemGlow, "Enables glow on items");
            swItemGlow.UseVisualStyleBackColor = true;
            swItemGlow.CheckedChanged += swItemGlow_CheckedChanged;
            // 
            // sldrItemGlowBrightness
            // 
            sldrItemGlowBrightness.Depth = 0;
            sldrItemGlowBrightness.ForeColor = Color.Black;
            sldrItemGlowBrightness.Location = new Point(17, 249);
            sldrItemGlowBrightness.MouseState = MaterialSkin.MouseState.HOVER;
            sldrItemGlowBrightness.Name = "sldrItemGlowBrightness";
            sldrItemGlowBrightness.ShowValue = false;
            sldrItemGlowBrightness.Size = new Size(295, 40);
            sldrItemGlowBrightness.TabIndex = 52;
            sldrItemGlowBrightness.Text = "Brightness";
            toolTip.SetToolTip(sldrItemGlowBrightness, "Adjusts item glow brightness");
            sldrItemGlowBrightness.UseAccentColor = true;
            sldrItemGlowBrightness.Value = 1;
            sldrItemGlowBrightness.ValueMax = 100;
            sldrItemGlowBrightness.onValueChanged += sldrItemGlowBrightness_onValueChanged;
            // 
            // swItemGlowColor
            // 
            swItemGlowColor.Depth = 0;
            swItemGlowColor.Font = new Font("Segoe UI", 9F);
            swItemGlowColor.Location = new Point(261, 76);
            swItemGlowColor.Margin = new Padding(0);
            swItemGlowColor.MouseLocation = new Point(-1, -1);
            swItemGlowColor.MouseState = MaterialSkin.MouseState.HOVER;
            swItemGlowColor.Name = "swItemGlowColor";
            swItemGlowColor.Ripple = true;
            swItemGlowColor.Size = new Size(157, 28);
            swItemGlowColor.TabIndex = 54;
            swItemGlowColor.Text = "Custom Color";
            toolTip.SetToolTip(swItemGlowColor, "Forces specific color for item glow");
            swItemGlowColor.UseVisualStyleBackColor = true;
            swItemGlowColor.CheckedChanged += swItemGlowColor_CheckedChanged;
            // 
            // cboItemGlowType
            // 
            cboItemGlowType.AutoResize = false;
            cboItemGlowType.BackColor = Color.FromArgb(255, 255, 255);
            cboItemGlowType.Depth = 0;
            cboItemGlowType.DrawMode = DrawMode.OwnerDrawVariable;
            cboItemGlowType.DropDownHeight = 118;
            cboItemGlowType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboItemGlowType.DropDownWidth = 121;
            cboItemGlowType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboItemGlowType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboItemGlowType.FormattingEnabled = true;
            cboItemGlowType.IntegralHeight = false;
            cboItemGlowType.ItemHeight = 29;
            cboItemGlowType.Items.AddRange(new object[] { "Red Tier", "Gold Tier", "Purple Tier", "Blue Tier", "Grey Tier", "Weapons", "Ammo" });
            cboItemGlowType.Location = new Point(17, 39);
            cboItemGlowType.MaxDropDownItems = 4;
            cboItemGlowType.MouseState = MaterialSkin.MouseState.OUT;
            cboItemGlowType.Name = "cboItemGlowType";
            cboItemGlowType.Size = new Size(119, 35);
            cboItemGlowType.StartIndex = 0;
            cboItemGlowType.TabIndex = 55;
            toolTip.SetToolTip(cboItemGlowType, "Adjusts the minimum item tier to show");
            cboItemGlowType.UseTallSize = false;
            cboItemGlowType.SelectedIndexChanged += cboItemGlowType_SelectedIndexChanged;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabRadar);
            tabControlMain.Controls.Add(tabSettings);
            tabControlMain.Depth = 0;
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.ImageList = iconList;
            tabControlMain.Location = new Point(0, 24);
            tabControlMain.Margin = new Padding(0);
            tabControlMain.MouseState = MaterialSkin.MouseState.HOVER;
            tabControlMain.Multiline = true;
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1380, 746);
            tabControlMain.TabIndex = 10;
            // 
            // tabRadar
            // 
            tabRadar.BackColor = Color.White;
            tabRadar.Controls.Add(mcRadarStats);
            tabRadar.Controls.Add(mcRadarSettings);
            tabRadar.Controls.Add(mcRadarMapSetup);
            tabRadar.Controls.Add(skMapCanvas);
            tabRadar.ImageKey = "radar.png";
            tabRadar.Location = new Point(4, 39);
            tabRadar.Name = "tabRadar";
            tabRadar.Padding = new Padding(3);
            tabRadar.Size = new Size(1372, 703);
            tabRadar.TabIndex = 0;
            tabRadar.Text = "Radar";
            // 
            // mcRadarStats
            // 
            mcRadarStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mcRadarStats.BackColor = Color.FromArgb(255, 255, 255);
            mcRadarStats.Controls.Add(lblRadarPlayersAliveValue);
            mcRadarStats.Controls.Add(lblRadarPlayersAlive);
            mcRadarStats.Controls.Add(lblRadarMemSValue);
            mcRadarStats.Controls.Add(lblRadarFPSValue);
            mcRadarStats.Controls.Add(lblRadarPlayersValue);
            mcRadarStats.Controls.Add(lblRadarMemS);
            mcRadarStats.Controls.Add(lblRadarFPS);
            mcRadarStats.Controls.Add(lblRadarPlayers);
            mcRadarStats.Depth = 0;
            mcRadarStats.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcRadarStats.Location = new Point(1275, 637);
            mcRadarStats.Margin = new Padding(14);
            mcRadarStats.MouseState = MaterialSkin.MouseState.HOVER;
            mcRadarStats.Name = "mcRadarStats";
            mcRadarStats.Padding = new Padding(14);
            mcRadarStats.Size = new Size(93, 62);
            mcRadarStats.TabIndex = 36;
            mcRadarStats.Visible = false;
            // 
            // lblRadarPlayersAliveValue
            // 
            lblRadarPlayersAliveValue.AutoSize = true;
            lblRadarPlayersAliveValue.Depth = 0;
            lblRadarPlayersAliveValue.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarPlayersAliveValue.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarPlayersAliveValue.Location = new Point(49, 17);
            lblRadarPlayersAliveValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarPlayersAliveValue.Name = "lblRadarPlayersAliveValue";
            lblRadarPlayersAliveValue.Size = new Size(8, 14);
            lblRadarPlayersAliveValue.TabIndex = 12;
            lblRadarPlayersAliveValue.Text = "0";
            // 
            // lblRadarPlayersAlive
            // 
            lblRadarPlayersAlive.AutoSize = true;
            lblRadarPlayersAlive.Depth = 0;
            lblRadarPlayersAlive.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarPlayersAlive.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarPlayersAlive.Location = new Point(17, 17);
            lblRadarPlayersAlive.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarPlayersAlive.Name = "lblRadarPlayersAlive";
            lblRadarPlayersAlive.Size = new Size(30, 14);
            lblRadarPlayersAlive.TabIndex = 11;
            lblRadarPlayersAlive.Text = "Alive:";
            // 
            // lblRadarMemSValue
            // 
            lblRadarMemSValue.AutoSize = true;
            lblRadarMemSValue.Depth = 0;
            lblRadarMemSValue.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarMemSValue.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarMemSValue.Location = new Point(49, 45);
            lblRadarMemSValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarMemSValue.Name = "lblRadarMemSValue";
            lblRadarMemSValue.Size = new Size(8, 14);
            lblRadarMemSValue.TabIndex = 10;
            lblRadarMemSValue.Text = "0";
            // 
            // lblRadarFPSValue
            // 
            lblRadarFPSValue.AutoSize = true;
            lblRadarFPSValue.Depth = 0;
            lblRadarFPSValue.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarFPSValue.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarFPSValue.Location = new Point(49, 31);
            lblRadarFPSValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarFPSValue.Name = "lblRadarFPSValue";
            lblRadarFPSValue.Size = new Size(8, 14);
            lblRadarFPSValue.TabIndex = 5;
            lblRadarFPSValue.Text = "0";
            // 
            // lblRadarPlayersValue
            // 
            lblRadarPlayersValue.AutoSize = true;
            lblRadarPlayersValue.Depth = 0;
            lblRadarPlayersValue.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarPlayersValue.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarPlayersValue.Location = new Point(49, 3);
            lblRadarPlayersValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarPlayersValue.Name = "lblRadarPlayersValue";
            lblRadarPlayersValue.Size = new Size(8, 14);
            lblRadarPlayersValue.TabIndex = 5;
            lblRadarPlayersValue.Text = "0";
            // 
            // lblRadarMemS
            // 
            lblRadarMemS.AutoSize = true;
            lblRadarMemS.Depth = 0;
            lblRadarMemS.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarMemS.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarMemS.Location = new Point(5, 45);
            lblRadarMemS.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarMemS.Name = "lblRadarMemS";
            lblRadarMemS.Size = new Size(42, 14);
            lblRadarMemS.TabIndex = 9;
            lblRadarMemS.Text = "Mem/s:";
            // 
            // lblRadarFPS
            // 
            lblRadarFPS.AutoSize = true;
            lblRadarFPS.Depth = 0;
            lblRadarFPS.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarFPS.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarFPS.Location = new Point(21, 31);
            lblRadarFPS.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarFPS.Name = "lblRadarFPS";
            lblRadarFPS.Size = new Size(26, 14);
            lblRadarFPS.TabIndex = 0;
            lblRadarFPS.Text = "FPS:";
            // 
            // lblRadarPlayers
            // 
            lblRadarPlayers.AutoSize = true;
            lblRadarPlayers.Depth = 0;
            lblRadarPlayers.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarPlayers.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            lblRadarPlayers.Location = new Point(3, 3);
            lblRadarPlayers.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarPlayers.Name = "lblRadarPlayers";
            lblRadarPlayers.Size = new Size(44, 14);
            lblRadarPlayers.TabIndex = 0;
            lblRadarPlayers.Text = "Players:";
            // 
            // mcRadarSettings
            // 
            mcRadarSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mcRadarSettings.BackColor = Color.FromArgb(255, 255, 255);
            mcRadarSettings.Controls.Add(btnToggleMapFree);
            mcRadarSettings.Depth = 0;
            mcRadarSettings.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcRadarSettings.Location = new Point(1239, 5);
            mcRadarSettings.Margin = new Padding(14);
            mcRadarSettings.MouseState = MaterialSkin.MouseState.HOVER;
            mcRadarSettings.Name = "mcRadarSettings";
            mcRadarSettings.Padding = new Padding(14);
            mcRadarSettings.Size = new Size(128, 46);
            mcRadarSettings.TabIndex = 48;
            // 
            // mcRadarMapSetup
            // 
            mcRadarMapSetup.BackColor = Color.FromArgb(255, 255, 255);
            mcRadarMapSetup.Controls.Add(btnMapSetupApply);
            mcRadarMapSetup.Controls.Add(txtMapSetupScale);
            mcRadarMapSetup.Controls.Add(txtMapSetupY);
            mcRadarMapSetup.Controls.Add(txtMapSetupX);
            mcRadarMapSetup.Controls.Add(lblRadarMapSetup);
            mcRadarMapSetup.Depth = 0;
            mcRadarMapSetup.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcRadarMapSetup.Location = new Point(5, 5);
            mcRadarMapSetup.Margin = new Padding(14);
            mcRadarMapSetup.MouseState = MaterialSkin.MouseState.HOVER;
            mcRadarMapSetup.Name = "mcRadarMapSetup";
            mcRadarMapSetup.Padding = new Padding(14);
            mcRadarMapSetup.Size = new Size(444, 95);
            mcRadarMapSetup.TabIndex = 18;
            mcRadarMapSetup.Visible = false;
            // 
            // lblRadarMapSetup
            // 
            lblRadarMapSetup.AutoSize = true;
            lblRadarMapSetup.Depth = 0;
            lblRadarMapSetup.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRadarMapSetup.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblRadarMapSetup.HighEmphasis = true;
            lblRadarMapSetup.Location = new Point(17, 14);
            lblRadarMapSetup.MouseState = MaterialSkin.MouseState.HOVER;
            lblRadarMapSetup.Name = "lblRadarMapSetup";
            lblRadarMapSetup.Size = new Size(78, 19);
            lblRadarMapSetup.TabIndex = 31;
            lblRadarMapSetup.Text = "Map Setup";
            lblRadarMapSetup.UseAccent = true;
            // 
            // skMapCanvas
            // 
            skMapCanvas.BackColor = Color.Black;
            skMapCanvas.Dock = DockStyle.Fill;
            skMapCanvas.Location = new Point(3, 3);
            skMapCanvas.Margin = new Padding(4, 3, 4, 3);
            skMapCanvas.Name = "skMapCanvas";
            skMapCanvas.Size = new Size(1366, 697);
            skMapCanvas.TabIndex = 13;
            skMapCanvas.VSync = true;
            skMapCanvas.PaintSurface += skMapCanvas_PaintSurface;
            skMapCanvas.MouseDown += skMapCanvas_MouseDown;
            skMapCanvas.MouseMove += skMapCanvas_MouseMovePlayer;
            skMapCanvas.MouseUp += skMapCanvas_MouseUp;
            // 
            // tabSettings
            // 
            tabSettings.BackColor = Color.White;
            tabSettings.Controls.Add(tabSelector);
            tabSettings.Controls.Add(tabControlSettings);
            tabSettings.ImageKey = "settings.png";
            tabSettings.Location = new Point(4, 39);
            tabSettings.Margin = new Padding(0);
            tabSettings.Name = "tabSettings";
            tabSettings.Size = new Size(1372, 703);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Settings";
            // 
            // tabSelector
            // 
            tabSelector.BaseTabControl = tabControlSettings;
            tabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            tabSelector.Depth = 0;
            tabSelector.Dock = DockStyle.Top;
            tabSelector.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabSelector.Location = new Point(0, 0);
            tabSelector.Margin = new Padding(0);
            tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            tabSelector.Name = "tabSelector";
            tabSelector.Size = new Size(1372, 36);
            tabSelector.TabIndex = 29;
            tabSelector.TabIndicatorHeight = 1;
            tabSelector.Text = "tabSelectorSettings";
            // 
            // tabControlSettings
            // 
            tabControlSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tabControlSettings.Controls.Add(tabSettingsGeneral);
            tabControlSettings.Controls.Add(tabSettingsMemoryWriting);
            tabControlSettings.Controls.Add(tabSettingsColors);
            tabControlSettings.Depth = 0;
            tabControlSettings.Font = new Font("Segoe UI", 9F);
            tabControlSettings.Location = new Point(0, 36);
            tabControlSettings.Margin = new Padding(0);
            tabControlSettings.MouseState = MaterialSkin.MouseState.HOVER;
            tabControlSettings.Multiline = true;
            tabControlSettings.Name = "tabControlSettings";
            tabControlSettings.SelectedIndex = 0;
            tabControlSettings.Size = new Size(1342, 668);
            tabControlSettings.TabIndex = 28;
            // 
            // tabSettingsGeneral
            // 
            tabSettingsGeneral.BackColor = Color.White;
            tabSettingsGeneral.Controls.Add(mcSettingsGeneralUI);
            tabSettingsGeneral.Controls.Add(mcSettingsGeneralPlayerInformation);
            tabSettingsGeneral.Controls.Add(mcSettingsGeneralRadar);
            tabSettingsGeneral.ImageKey = "(none)";
            tabSettingsGeneral.Location = new Point(4, 24);
            tabSettingsGeneral.Margin = new Padding(0);
            tabSettingsGeneral.Name = "tabSettingsGeneral";
            tabSettingsGeneral.Size = new Size(1334, 640);
            tabSettingsGeneral.TabIndex = 0;
            tabSettingsGeneral.Text = "General";
            // 
            // mcSettingsGeneralUI
            // 
            mcSettingsGeneralUI.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsGeneralUI.Controls.Add(swHighlightLastAlive);
            mcSettingsGeneralUI.Controls.Add(sldrZoomSensitivity);
            mcSettingsGeneralUI.Controls.Add(cboGlobalFont);
            mcSettingsGeneralUI.Controls.Add(sldrGlobalFontSize);
            mcSettingsGeneralUI.Controls.Add(lblSettingsGeneralUI);
            mcSettingsGeneralUI.Controls.Add(sldrUIScale);
            mcSettingsGeneralUI.Depth = 0;
            mcSettingsGeneralUI.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsGeneralUI.Location = new Point(206, 14);
            mcSettingsGeneralUI.Margin = new Padding(14);
            mcSettingsGeneralUI.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsGeneralUI.Name = "mcSettingsGeneralUI";
            mcSettingsGeneralUI.Padding = new Padding(14);
            mcSettingsGeneralUI.Size = new Size(445, 341);
            mcSettingsGeneralUI.TabIndex = 43;
            // 
            // sldrZoomSensitivity
            // 
            sldrZoomSensitivity.Depth = 0;
            sldrZoomSensitivity.ForeColor = Color.Black;
            sldrZoomSensitivity.Location = new Point(16, 81);
            sldrZoomSensitivity.MouseState = MaterialSkin.MouseState.HOVER;
            sldrZoomSensitivity.Name = "sldrZoomSensitivity";
            sldrZoomSensitivity.RangeMax = 30;
            sldrZoomSensitivity.RangeMin = 1;
            sldrZoomSensitivity.Size = new Size(304, 40);
            sldrZoomSensitivity.TabIndex = 41;
            sldrZoomSensitivity.Text = "Zoom Sensitivity";
            sldrZoomSensitivity.UseAccentColor = true;
            sldrZoomSensitivity.Value = 15;
            sldrZoomSensitivity.ValueMax = 30;
            sldrZoomSensitivity.onValueChanged += sldrZoomSensitivity_onValueChanged;
            // 
            // lblSettingsGeneralUI
            // 
            lblSettingsGeneralUI.AutoSize = true;
            lblSettingsGeneralUI.Depth = 0;
            lblSettingsGeneralUI.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsGeneralUI.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsGeneralUI.HighEmphasis = true;
            lblSettingsGeneralUI.Location = new Point(17, 12);
            lblSettingsGeneralUI.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsGeneralUI.Name = "lblSettingsGeneralUI";
            lblSettingsGeneralUI.Size = new Size(128, 24);
            lblSettingsGeneralUI.TabIndex = 33;
            lblSettingsGeneralUI.Text = "User Interface";
            lblSettingsGeneralUI.UseAccent = true;
            // 
            // mcSettingsGeneralPlayerInformation
            // 
            mcSettingsGeneralPlayerInformation.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoShieldLevel);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoKnocked);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoLastAlive);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoXPLevel);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoShield);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoLegend);
            mcSettingsGeneralPlayerInformation.Controls.Add(sldrPlayerInfoFontSize);
            mcSettingsGeneralPlayerInformation.Controls.Add(cboPlayerInfoFont);
            mcSettingsGeneralPlayerInformation.Controls.Add(sldrPlayerInfoFlagsFontSize);
            mcSettingsGeneralPlayerInformation.Controls.Add(cboPlayerInfoFlagsFont);
            mcSettingsGeneralPlayerInformation.Controls.Add(sldrPlayerInfoAimlineOpacity);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoAimline);
            mcSettingsGeneralPlayerInformation.Controls.Add(sldrPlayerInfoAimlineLength);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoHealth);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoDistance);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoHeight);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoFlags);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoActiveWeapon);
            mcSettingsGeneralPlayerInformation.Controls.Add(swPlayerInfoName);
            mcSettingsGeneralPlayerInformation.Controls.Add(cboPlayerInfoType);
            mcSettingsGeneralPlayerInformation.Controls.Add(lblSettingsGeneralPlayerInformation);
            mcSettingsGeneralPlayerInformation.Depth = 0;
            mcSettingsGeneralPlayerInformation.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsGeneralPlayerInformation.Location = new Point(663, 14);
            mcSettingsGeneralPlayerInformation.Margin = new Padding(14);
            mcSettingsGeneralPlayerInformation.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsGeneralPlayerInformation.Name = "mcSettingsGeneralPlayerInformation";
            mcSettingsGeneralPlayerInformation.Padding = new Padding(14);
            mcSettingsGeneralPlayerInformation.Size = new Size(642, 341);
            mcSettingsGeneralPlayerInformation.TabIndex = 42;
            // 
            // lblSettingsGeneralPlayerInformation
            // 
            lblSettingsGeneralPlayerInformation.AutoSize = true;
            lblSettingsGeneralPlayerInformation.Depth = 0;
            lblSettingsGeneralPlayerInformation.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsGeneralPlayerInformation.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsGeneralPlayerInformation.HighEmphasis = true;
            lblSettingsGeneralPlayerInformation.Location = new Point(17, 12);
            lblSettingsGeneralPlayerInformation.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsGeneralPlayerInformation.Name = "lblSettingsGeneralPlayerInformation";
            lblSettingsGeneralPlayerInformation.Size = new Size(167, 24);
            lblSettingsGeneralPlayerInformation.TabIndex = 33;
            lblSettingsGeneralPlayerInformation.Text = "Player Information";
            lblSettingsGeneralPlayerInformation.UseAccent = true;
            // 
            // mcSettingsGeneralRadar
            // 
            mcSettingsGeneralRadar.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsGeneralRadar.Controls.Add(swSpectators);
            mcSettingsGeneralRadar.Controls.Add(swRadarVsync);
            mcSettingsGeneralRadar.Controls.Add(swRadarStats);
            mcSettingsGeneralRadar.Controls.Add(lblSettingsGeneralRadar);
            mcSettingsGeneralRadar.Controls.Add(btnRestartRadar);
            mcSettingsGeneralRadar.Controls.Add(swMapHelper);
            mcSettingsGeneralRadar.Depth = 0;
            mcSettingsGeneralRadar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsGeneralRadar.Location = new Point(15, 14);
            mcSettingsGeneralRadar.Margin = new Padding(14);
            mcSettingsGeneralRadar.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsGeneralRadar.Name = "mcSettingsGeneralRadar";
            mcSettingsGeneralRadar.Padding = new Padding(14);
            mcSettingsGeneralRadar.Size = new Size(179, 341);
            mcSettingsGeneralRadar.TabIndex = 30;
            // 
            // lblSettingsGeneralRadar
            // 
            lblSettingsGeneralRadar.AutoSize = true;
            lblSettingsGeneralRadar.Depth = 0;
            lblSettingsGeneralRadar.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsGeneralRadar.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsGeneralRadar.HighEmphasis = true;
            lblSettingsGeneralRadar.Location = new Point(17, 15);
            lblSettingsGeneralRadar.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsGeneralRadar.Name = "lblSettingsGeneralRadar";
            lblSettingsGeneralRadar.Size = new Size(53, 24);
            lblSettingsGeneralRadar.TabIndex = 30;
            lblSettingsGeneralRadar.Text = "Radar";
            lblSettingsGeneralRadar.UseAccent = true;
            // 
            // tabSettingsMemoryWriting
            // 
            tabSettingsMemoryWriting.Controls.Add(mcSettingsMemoryWritingItemGlow);
            tabSettingsMemoryWriting.Controls.Add(mcSettingsMemoryWritingViewModelGlow);
            tabSettingsMemoryWriting.Controls.Add(swMasterSwitch);
            tabSettingsMemoryWriting.Controls.Add(mcSettingsMemoryWritingPlayerGlow);
            tabSettingsMemoryWriting.Location = new Point(4, 24);
            tabSettingsMemoryWriting.Name = "tabSettingsMemoryWriting";
            tabSettingsMemoryWriting.Padding = new Padding(3);
            tabSettingsMemoryWriting.Size = new Size(1334, 640);
            tabSettingsMemoryWriting.TabIndex = 1;
            tabSettingsMemoryWriting.Text = "Memory Writing";
            tabSettingsMemoryWriting.UseVisualStyleBackColor = true;
            // 
            // mcSettingsMemoryWritingItemGlow
            // 
            mcSettingsMemoryWritingItemGlow.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsMemoryWritingItemGlow.Controls.Add(cboItemGlowType);
            mcSettingsMemoryWritingItemGlow.Controls.Add(swItemGlowColor);
            mcSettingsMemoryWritingItemGlow.Controls.Add(txtItemGlowBrightness);
            mcSettingsMemoryWritingItemGlow.Controls.Add(sldrItemGlowBrightness);
            mcSettingsMemoryWritingItemGlow.Controls.Add(txtItemGlowOutlineRadius);
            mcSettingsMemoryWritingItemGlow.Controls.Add(sldrItemGlowOutlineRadius);
            mcSettingsMemoryWritingItemGlow.Controls.Add(txtItemGlowOutlineFunction);
            mcSettingsMemoryWritingItemGlow.Controls.Add(sldrItemGlowOutlineFunction);
            mcSettingsMemoryWritingItemGlow.Controls.Add(txtItemGlowInsideFunction);
            mcSettingsMemoryWritingItemGlow.Controls.Add(sldrItemGlowInsideFunction);
            mcSettingsMemoryWritingItemGlow.Controls.Add(swItemGlow);
            mcSettingsMemoryWritingItemGlow.Controls.Add(lblSettingsMemoryWritingItemGlow);
            mcSettingsMemoryWritingItemGlow.Depth = 0;
            mcSettingsMemoryWritingItemGlow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsMemoryWritingItemGlow.Location = new Point(439, 56);
            mcSettingsMemoryWritingItemGlow.Margin = new Padding(14);
            mcSettingsMemoryWritingItemGlow.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsMemoryWritingItemGlow.Name = "mcSettingsMemoryWritingItemGlow";
            mcSettingsMemoryWritingItemGlow.Padding = new Padding(14);
            mcSettingsMemoryWritingItemGlow.Size = new Size(437, 305);
            mcSettingsMemoryWritingItemGlow.TabIndex = 42;
            // 
            // txtItemGlowBrightness
            // 
            txtItemGlowBrightness.AnimateReadOnly = false;
            txtItemGlowBrightness.BackgroundImageLayout = ImageLayout.None;
            txtItemGlowBrightness.CharacterCasing = CharacterCasing.Normal;
            txtItemGlowBrightness.Depth = 0;
            txtItemGlowBrightness.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtItemGlowBrightness.HideSelection = true;
            txtItemGlowBrightness.LeadingIcon = null;
            txtItemGlowBrightness.Location = new Point(346, 253);
            txtItemGlowBrightness.MaxLength = 32767;
            txtItemGlowBrightness.MouseState = MaterialSkin.MouseState.OUT;
            txtItemGlowBrightness.Name = "txtItemGlowBrightness";
            txtItemGlowBrightness.PasswordChar = '\0';
            txtItemGlowBrightness.PrefixSuffixText = null;
            txtItemGlowBrightness.ReadOnly = false;
            txtItemGlowBrightness.RightToLeft = RightToLeft.No;
            txtItemGlowBrightness.SelectedText = "";
            txtItemGlowBrightness.SelectionLength = 0;
            txtItemGlowBrightness.SelectionStart = 0;
            txtItemGlowBrightness.ShortcutsEnabled = true;
            txtItemGlowBrightness.Size = new Size(72, 36);
            txtItemGlowBrightness.TabIndex = 53;
            txtItemGlowBrightness.TabStop = false;
            txtItemGlowBrightness.Text = "100";
            txtItemGlowBrightness.TextAlign = HorizontalAlignment.Left;
            txtItemGlowBrightness.TrailingIcon = null;
            txtItemGlowBrightness.UseSystemPasswordChar = false;
            txtItemGlowBrightness.UseTallSize = false;
            txtItemGlowBrightness.KeyDown += txtItemGlowBrightness_KeyDown;
            // 
            // txtItemGlowOutlineRadius
            // 
            txtItemGlowOutlineRadius.AnimateReadOnly = false;
            txtItemGlowOutlineRadius.BackgroundImageLayout = ImageLayout.None;
            txtItemGlowOutlineRadius.CharacterCasing = CharacterCasing.Normal;
            txtItemGlowOutlineRadius.Depth = 0;
            txtItemGlowOutlineRadius.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtItemGlowOutlineRadius.HideSelection = true;
            txtItemGlowOutlineRadius.LeadingIcon = null;
            txtItemGlowOutlineRadius.Location = new Point(346, 207);
            txtItemGlowOutlineRadius.MaxLength = 32767;
            txtItemGlowOutlineRadius.MouseState = MaterialSkin.MouseState.OUT;
            txtItemGlowOutlineRadius.Name = "txtItemGlowOutlineRadius";
            txtItemGlowOutlineRadius.PasswordChar = '\0';
            txtItemGlowOutlineRadius.PrefixSuffixText = null;
            txtItemGlowOutlineRadius.ReadOnly = false;
            txtItemGlowOutlineRadius.RightToLeft = RightToLeft.No;
            txtItemGlowOutlineRadius.SelectedText = "";
            txtItemGlowOutlineRadius.SelectionLength = 0;
            txtItemGlowOutlineRadius.SelectionStart = 0;
            txtItemGlowOutlineRadius.ShortcutsEnabled = true;
            txtItemGlowOutlineRadius.Size = new Size(72, 36);
            txtItemGlowOutlineRadius.TabIndex = 44;
            txtItemGlowOutlineRadius.TabStop = false;
            txtItemGlowOutlineRadius.Text = "255";
            txtItemGlowOutlineRadius.TextAlign = HorizontalAlignment.Left;
            txtItemGlowOutlineRadius.TrailingIcon = null;
            txtItemGlowOutlineRadius.UseSystemPasswordChar = false;
            txtItemGlowOutlineRadius.UseTallSize = false;
            txtItemGlowOutlineRadius.KeyDown += txtItemGlowOutlineRadius_KeyDown;
            // 
            // txtItemGlowOutlineFunction
            // 
            txtItemGlowOutlineFunction.AnimateReadOnly = false;
            txtItemGlowOutlineFunction.BackgroundImageLayout = ImageLayout.None;
            txtItemGlowOutlineFunction.CharacterCasing = CharacterCasing.Normal;
            txtItemGlowOutlineFunction.Depth = 0;
            txtItemGlowOutlineFunction.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtItemGlowOutlineFunction.HideSelection = true;
            txtItemGlowOutlineFunction.LeadingIcon = null;
            txtItemGlowOutlineFunction.Location = new Point(346, 161);
            txtItemGlowOutlineFunction.MaxLength = 32767;
            txtItemGlowOutlineFunction.MouseState = MaterialSkin.MouseState.OUT;
            txtItemGlowOutlineFunction.Name = "txtItemGlowOutlineFunction";
            txtItemGlowOutlineFunction.PasswordChar = '\0';
            txtItemGlowOutlineFunction.PrefixSuffixText = null;
            txtItemGlowOutlineFunction.ReadOnly = false;
            txtItemGlowOutlineFunction.RightToLeft = RightToLeft.No;
            txtItemGlowOutlineFunction.SelectedText = "";
            txtItemGlowOutlineFunction.SelectionLength = 0;
            txtItemGlowOutlineFunction.SelectionStart = 0;
            txtItemGlowOutlineFunction.ShortcutsEnabled = true;
            txtItemGlowOutlineFunction.Size = new Size(72, 36);
            txtItemGlowOutlineFunction.TabIndex = 42;
            txtItemGlowOutlineFunction.TabStop = false;
            txtItemGlowOutlineFunction.Text = "255";
            txtItemGlowOutlineFunction.TextAlign = HorizontalAlignment.Left;
            txtItemGlowOutlineFunction.TrailingIcon = null;
            txtItemGlowOutlineFunction.UseSystemPasswordChar = false;
            txtItemGlowOutlineFunction.UseTallSize = false;
            txtItemGlowOutlineFunction.KeyDown += txtItemGlowOutlineFunction_KeyDown;
            // 
            // txtItemGlowInsideFunction
            // 
            txtItemGlowInsideFunction.AnimateReadOnly = false;
            txtItemGlowInsideFunction.BackgroundImageLayout = ImageLayout.None;
            txtItemGlowInsideFunction.CharacterCasing = CharacterCasing.Normal;
            txtItemGlowInsideFunction.Depth = 0;
            txtItemGlowInsideFunction.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtItemGlowInsideFunction.HideSelection = true;
            txtItemGlowInsideFunction.LeadingIcon = null;
            txtItemGlowInsideFunction.Location = new Point(346, 115);
            txtItemGlowInsideFunction.MaxLength = 32767;
            txtItemGlowInsideFunction.MouseState = MaterialSkin.MouseState.OUT;
            txtItemGlowInsideFunction.Name = "txtItemGlowInsideFunction";
            txtItemGlowInsideFunction.PasswordChar = '\0';
            txtItemGlowInsideFunction.PrefixSuffixText = null;
            txtItemGlowInsideFunction.ReadOnly = false;
            txtItemGlowInsideFunction.RightToLeft = RightToLeft.No;
            txtItemGlowInsideFunction.SelectedText = "";
            txtItemGlowInsideFunction.SelectionLength = 0;
            txtItemGlowInsideFunction.SelectionStart = 0;
            txtItemGlowInsideFunction.ShortcutsEnabled = true;
            txtItemGlowInsideFunction.Size = new Size(72, 36);
            txtItemGlowInsideFunction.TabIndex = 40;
            txtItemGlowInsideFunction.TabStop = false;
            txtItemGlowInsideFunction.Text = "255";
            txtItemGlowInsideFunction.TextAlign = HorizontalAlignment.Left;
            txtItemGlowInsideFunction.TrailingIcon = null;
            txtItemGlowInsideFunction.UseSystemPasswordChar = false;
            txtItemGlowInsideFunction.UseTallSize = false;
            txtItemGlowInsideFunction.KeyDown += txtItemGlowInsideFunction_KeyDown;
            // 
            // lblSettingsMemoryWritingItemGlow
            // 
            lblSettingsMemoryWritingItemGlow.AutoSize = true;
            lblSettingsMemoryWritingItemGlow.Depth = 0;
            lblSettingsMemoryWritingItemGlow.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsMemoryWritingItemGlow.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsMemoryWritingItemGlow.HighEmphasis = true;
            lblSettingsMemoryWritingItemGlow.Location = new Point(17, 12);
            lblSettingsMemoryWritingItemGlow.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsMemoryWritingItemGlow.Name = "lblSettingsMemoryWritingItemGlow";
            lblSettingsMemoryWritingItemGlow.Size = new Size(92, 24);
            lblSettingsMemoryWritingItemGlow.TabIndex = 33;
            lblSettingsMemoryWritingItemGlow.Text = "Item Glow";
            lblSettingsMemoryWritingItemGlow.UseAccent = true;
            // 
            // mcSettingsMemoryWritingViewModelGlow
            // 
            mcSettingsMemoryWritingViewModelGlow.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsMemoryWritingViewModelGlow.Controls.Add(txtViewModelEffect);
            mcSettingsMemoryWritingViewModelGlow.Controls.Add(sldrViewModelEffect);
            mcSettingsMemoryWritingViewModelGlow.Controls.Add(swViewModelGlow);
            mcSettingsMemoryWritingViewModelGlow.Controls.Add(lblSettingsMemoryWritingViewModelGlow);
            mcSettingsMemoryWritingViewModelGlow.Depth = 0;
            mcSettingsMemoryWritingViewModelGlow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsMemoryWritingViewModelGlow.Location = new Point(889, 56);
            mcSettingsMemoryWritingViewModelGlow.Margin = new Padding(14);
            mcSettingsMemoryWritingViewModelGlow.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsMemoryWritingViewModelGlow.Name = "mcSettingsMemoryWritingViewModelGlow";
            mcSettingsMemoryWritingViewModelGlow.Padding = new Padding(14);
            mcSettingsMemoryWritingViewModelGlow.Size = new Size(409, 132);
            mcSettingsMemoryWritingViewModelGlow.TabIndex = 41;
            // 
            // txtViewModelEffect
            // 
            txtViewModelEffect.AnimateReadOnly = false;
            txtViewModelEffect.BackgroundImageLayout = ImageLayout.None;
            txtViewModelEffect.CharacterCasing = CharacterCasing.Normal;
            txtViewModelEffect.Depth = 0;
            txtViewModelEffect.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtViewModelEffect.HideSelection = true;
            txtViewModelEffect.LeadingIcon = null;
            txtViewModelEffect.Location = new Point(318, 80);
            txtViewModelEffect.MaxLength = 32767;
            txtViewModelEffect.MouseState = MaterialSkin.MouseState.OUT;
            txtViewModelEffect.Name = "txtViewModelEffect";
            txtViewModelEffect.PasswordChar = '\0';
            txtViewModelEffect.PrefixSuffixText = null;
            txtViewModelEffect.ReadOnly = false;
            txtViewModelEffect.RightToLeft = RightToLeft.No;
            txtViewModelEffect.SelectedText = "";
            txtViewModelEffect.SelectionLength = 0;
            txtViewModelEffect.SelectionStart = 0;
            txtViewModelEffect.ShortcutsEnabled = true;
            txtViewModelEffect.Size = new Size(72, 36);
            txtViewModelEffect.TabIndex = 40;
            txtViewModelEffect.TabStop = false;
            txtViewModelEffect.Text = "83";
            txtViewModelEffect.TextAlign = HorizontalAlignment.Left;
            txtViewModelEffect.TrailingIcon = null;
            txtViewModelEffect.UseSystemPasswordChar = false;
            txtViewModelEffect.UseTallSize = false;
            txtViewModelEffect.KeyDown += txtViewModelEffect_KeyDown;
            // 
            // lblSettingsMemoryWritingViewModelGlow
            // 
            lblSettingsMemoryWritingViewModelGlow.AutoSize = true;
            lblSettingsMemoryWritingViewModelGlow.Depth = 0;
            lblSettingsMemoryWritingViewModelGlow.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsMemoryWritingViewModelGlow.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsMemoryWritingViewModelGlow.HighEmphasis = true;
            lblSettingsMemoryWritingViewModelGlow.Location = new Point(17, 12);
            lblSettingsMemoryWritingViewModelGlow.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsMemoryWritingViewModelGlow.Name = "lblSettingsMemoryWritingViewModelGlow";
            lblSettingsMemoryWritingViewModelGlow.Size = new Size(156, 24);
            lblSettingsMemoryWritingViewModelGlow.TabIndex = 33;
            lblSettingsMemoryWritingViewModelGlow.Text = "View Model Glow";
            lblSettingsMemoryWritingViewModelGlow.UseAccent = true;
            // 
            // mcSettingsMemoryWritingPlayerGlow
            // 
            mcSettingsMemoryWritingPlayerGlow.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(swPlayerGlowShieldBased);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(txtPlayerGlowBrightness);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(sldrPlayerGlowBrightness);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(txtPlayerGlowOutlineRadius);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(sldrPlayerGlowOutlineRadius);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(txtPlayerGlowOutlineFunction);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(sldrPlayerGlowOutlineFunction);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(txtPlayerGlowInsideFunction);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(sldrPlayerGlowInsideFunction);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(swPlayerGlow);
            mcSettingsMemoryWritingPlayerGlow.Controls.Add(lblSettingsMemoryWritingPlayerGlow);
            mcSettingsMemoryWritingPlayerGlow.Depth = 0;
            mcSettingsMemoryWritingPlayerGlow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsMemoryWritingPlayerGlow.Location = new Point(15, 56);
            mcSettingsMemoryWritingPlayerGlow.Margin = new Padding(14);
            mcSettingsMemoryWritingPlayerGlow.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsMemoryWritingPlayerGlow.Name = "mcSettingsMemoryWritingPlayerGlow";
            mcSettingsMemoryWritingPlayerGlow.Padding = new Padding(14);
            mcSettingsMemoryWritingPlayerGlow.Size = new Size(409, 305);
            mcSettingsMemoryWritingPlayerGlow.TabIndex = 40;
            // 
            // txtPlayerGlowBrightness
            // 
            txtPlayerGlowBrightness.AnimateReadOnly = false;
            txtPlayerGlowBrightness.BackgroundImageLayout = ImageLayout.None;
            txtPlayerGlowBrightness.CharacterCasing = CharacterCasing.Normal;
            txtPlayerGlowBrightness.Depth = 0;
            txtPlayerGlowBrightness.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPlayerGlowBrightness.HideSelection = true;
            txtPlayerGlowBrightness.LeadingIcon = null;
            txtPlayerGlowBrightness.Location = new Point(320, 253);
            txtPlayerGlowBrightness.MaxLength = 32767;
            txtPlayerGlowBrightness.MouseState = MaterialSkin.MouseState.OUT;
            txtPlayerGlowBrightness.Name = "txtPlayerGlowBrightness";
            txtPlayerGlowBrightness.PasswordChar = '\0';
            txtPlayerGlowBrightness.PrefixSuffixText = null;
            txtPlayerGlowBrightness.ReadOnly = false;
            txtPlayerGlowBrightness.RightToLeft = RightToLeft.No;
            txtPlayerGlowBrightness.SelectedText = "";
            txtPlayerGlowBrightness.SelectionLength = 0;
            txtPlayerGlowBrightness.SelectionStart = 0;
            txtPlayerGlowBrightness.ShortcutsEnabled = true;
            txtPlayerGlowBrightness.Size = new Size(72, 36);
            txtPlayerGlowBrightness.TabIndex = 46;
            txtPlayerGlowBrightness.TabStop = false;
            txtPlayerGlowBrightness.Text = "255";
            txtPlayerGlowBrightness.TextAlign = HorizontalAlignment.Left;
            txtPlayerGlowBrightness.TrailingIcon = null;
            txtPlayerGlowBrightness.UseSystemPasswordChar = false;
            txtPlayerGlowBrightness.UseTallSize = false;
            txtPlayerGlowBrightness.KeyDown += txtPlayerGlowBrightness_KeyDown;
            // 
            // txtPlayerGlowOutlineRadius
            // 
            txtPlayerGlowOutlineRadius.AnimateReadOnly = false;
            txtPlayerGlowOutlineRadius.BackgroundImageLayout = ImageLayout.None;
            txtPlayerGlowOutlineRadius.CharacterCasing = CharacterCasing.Normal;
            txtPlayerGlowOutlineRadius.Depth = 0;
            txtPlayerGlowOutlineRadius.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPlayerGlowOutlineRadius.HideSelection = true;
            txtPlayerGlowOutlineRadius.LeadingIcon = null;
            txtPlayerGlowOutlineRadius.Location = new Point(320, 207);
            txtPlayerGlowOutlineRadius.MaxLength = 32767;
            txtPlayerGlowOutlineRadius.MouseState = MaterialSkin.MouseState.OUT;
            txtPlayerGlowOutlineRadius.Name = "txtPlayerGlowOutlineRadius";
            txtPlayerGlowOutlineRadius.PasswordChar = '\0';
            txtPlayerGlowOutlineRadius.PrefixSuffixText = null;
            txtPlayerGlowOutlineRadius.ReadOnly = false;
            txtPlayerGlowOutlineRadius.RightToLeft = RightToLeft.No;
            txtPlayerGlowOutlineRadius.SelectedText = "";
            txtPlayerGlowOutlineRadius.SelectionLength = 0;
            txtPlayerGlowOutlineRadius.SelectionStart = 0;
            txtPlayerGlowOutlineRadius.ShortcutsEnabled = true;
            txtPlayerGlowOutlineRadius.Size = new Size(72, 36);
            txtPlayerGlowOutlineRadius.TabIndex = 44;
            txtPlayerGlowOutlineRadius.TabStop = false;
            txtPlayerGlowOutlineRadius.Text = "255";
            txtPlayerGlowOutlineRadius.TextAlign = HorizontalAlignment.Left;
            txtPlayerGlowOutlineRadius.TrailingIcon = null;
            txtPlayerGlowOutlineRadius.UseSystemPasswordChar = false;
            txtPlayerGlowOutlineRadius.UseTallSize = false;
            txtPlayerGlowOutlineRadius.KeyDown += txtPlayerGlowOutlineRadius_KeyDown;
            // 
            // txtPlayerGlowOutlineFunction
            // 
            txtPlayerGlowOutlineFunction.AnimateReadOnly = false;
            txtPlayerGlowOutlineFunction.BackgroundImageLayout = ImageLayout.None;
            txtPlayerGlowOutlineFunction.CharacterCasing = CharacterCasing.Normal;
            txtPlayerGlowOutlineFunction.Depth = 0;
            txtPlayerGlowOutlineFunction.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPlayerGlowOutlineFunction.HideSelection = true;
            txtPlayerGlowOutlineFunction.LeadingIcon = null;
            txtPlayerGlowOutlineFunction.Location = new Point(320, 161);
            txtPlayerGlowOutlineFunction.MaxLength = 32767;
            txtPlayerGlowOutlineFunction.MouseState = MaterialSkin.MouseState.OUT;
            txtPlayerGlowOutlineFunction.Name = "txtPlayerGlowOutlineFunction";
            txtPlayerGlowOutlineFunction.PasswordChar = '\0';
            txtPlayerGlowOutlineFunction.PrefixSuffixText = null;
            txtPlayerGlowOutlineFunction.ReadOnly = false;
            txtPlayerGlowOutlineFunction.RightToLeft = RightToLeft.No;
            txtPlayerGlowOutlineFunction.SelectedText = "";
            txtPlayerGlowOutlineFunction.SelectionLength = 0;
            txtPlayerGlowOutlineFunction.SelectionStart = 0;
            txtPlayerGlowOutlineFunction.ShortcutsEnabled = true;
            txtPlayerGlowOutlineFunction.Size = new Size(72, 36);
            txtPlayerGlowOutlineFunction.TabIndex = 42;
            txtPlayerGlowOutlineFunction.TabStop = false;
            txtPlayerGlowOutlineFunction.Text = "255";
            txtPlayerGlowOutlineFunction.TextAlign = HorizontalAlignment.Left;
            txtPlayerGlowOutlineFunction.TrailingIcon = null;
            txtPlayerGlowOutlineFunction.UseSystemPasswordChar = false;
            txtPlayerGlowOutlineFunction.UseTallSize = false;
            txtPlayerGlowOutlineFunction.KeyDown += txtPlayerGlowOutlineFunction_KeyDown;
            // 
            // txtPlayerGlowInsideFunction
            // 
            txtPlayerGlowInsideFunction.AnimateReadOnly = false;
            txtPlayerGlowInsideFunction.BackgroundImageLayout = ImageLayout.None;
            txtPlayerGlowInsideFunction.CharacterCasing = CharacterCasing.Normal;
            txtPlayerGlowInsideFunction.Depth = 0;
            txtPlayerGlowInsideFunction.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPlayerGlowInsideFunction.HideSelection = true;
            txtPlayerGlowInsideFunction.LeadingIcon = null;
            txtPlayerGlowInsideFunction.Location = new Point(320, 115);
            txtPlayerGlowInsideFunction.MaxLength = 32767;
            txtPlayerGlowInsideFunction.MouseState = MaterialSkin.MouseState.OUT;
            txtPlayerGlowInsideFunction.Name = "txtPlayerGlowInsideFunction";
            txtPlayerGlowInsideFunction.PasswordChar = '\0';
            txtPlayerGlowInsideFunction.PrefixSuffixText = null;
            txtPlayerGlowInsideFunction.ReadOnly = false;
            txtPlayerGlowInsideFunction.RightToLeft = RightToLeft.No;
            txtPlayerGlowInsideFunction.SelectedText = "";
            txtPlayerGlowInsideFunction.SelectionLength = 0;
            txtPlayerGlowInsideFunction.SelectionStart = 0;
            txtPlayerGlowInsideFunction.ShortcutsEnabled = true;
            txtPlayerGlowInsideFunction.Size = new Size(72, 36);
            txtPlayerGlowInsideFunction.TabIndex = 40;
            txtPlayerGlowInsideFunction.TabStop = false;
            txtPlayerGlowInsideFunction.Text = "255";
            txtPlayerGlowInsideFunction.TextAlign = HorizontalAlignment.Left;
            txtPlayerGlowInsideFunction.TrailingIcon = null;
            txtPlayerGlowInsideFunction.UseSystemPasswordChar = false;
            txtPlayerGlowInsideFunction.UseTallSize = false;
            txtPlayerGlowInsideFunction.KeyDown += txtPlayerGlowInsideFunction_KeyDown;
            // 
            // lblSettingsMemoryWritingPlayerGlow
            // 
            lblSettingsMemoryWritingPlayerGlow.AutoSize = true;
            lblSettingsMemoryWritingPlayerGlow.Depth = 0;
            lblSettingsMemoryWritingPlayerGlow.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsMemoryWritingPlayerGlow.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsMemoryWritingPlayerGlow.HighEmphasis = true;
            lblSettingsMemoryWritingPlayerGlow.Location = new Point(17, 12);
            lblSettingsMemoryWritingPlayerGlow.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsMemoryWritingPlayerGlow.Name = "lblSettingsMemoryWritingPlayerGlow";
            lblSettingsMemoryWritingPlayerGlow.Size = new Size(108, 24);
            lblSettingsMemoryWritingPlayerGlow.TabIndex = 33;
            lblSettingsMemoryWritingPlayerGlow.Text = "Player Glow";
            lblSettingsMemoryWritingPlayerGlow.UseAccent = true;
            // 
            // tabSettingsColors
            // 
            tabSettingsColors.Controls.Add(mcSettingsColorsItemGlow);
            tabSettingsColors.Controls.Add(mcSettingsColorsPlayerGlow);
            tabSettingsColors.Controls.Add(mcSettingsColorsOther);
            tabSettingsColors.Controls.Add(mcSettingsColorsPlayers);
            tabSettingsColors.Location = new Point(4, 24);
            tabSettingsColors.Name = "tabSettingsColors";
            tabSettingsColors.Padding = new Padding(3);
            tabSettingsColors.Size = new Size(1334, 640);
            tabSettingsColors.TabIndex = 2;
            tabSettingsColors.Text = "Colors";
            tabSettingsColors.UseVisualStyleBackColor = true;
            // 
            // mcSettingsColorsItemGlow
            // 
            mcSettingsColorsItemGlow.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowPurple);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowPurpleTier);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowGold);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowGoldTier);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowAmmoBoxes);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowAmmoBoxes);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowWeapons);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowWeapons);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowGrey);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowGreyTier);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowBlue);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowBlueTier);
            mcSettingsColorsItemGlow.Controls.Add(picItemGlowRed);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlowRedTier);
            mcSettingsColorsItemGlow.Controls.Add(lblSettingsColorsItemGlow);
            mcSettingsColorsItemGlow.Depth = 0;
            mcSettingsColorsItemGlow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsColorsItemGlow.Location = new Point(415, 14);
            mcSettingsColorsItemGlow.Margin = new Padding(14);
            mcSettingsColorsItemGlow.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsColorsItemGlow.Name = "mcSettingsColorsItemGlow";
            mcSettingsColorsItemGlow.Padding = new Padding(14);
            mcSettingsColorsItemGlow.Size = new Size(186, 322);
            mcSettingsColorsItemGlow.TabIndex = 64;
            // 
            // picItemGlowPurple
            // 
            picItemGlowPurple.BackColor = Color.Transparent;
            picItemGlowPurple.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowPurple.Location = new Point(110, 102);
            picItemGlowPurple.Name = "picItemGlowPurple";
            picItemGlowPurple.Size = new Size(70, 23);
            picItemGlowPurple.TabIndex = 60;
            picItemGlowPurple.TabStop = false;
            picItemGlowPurple.Click += picItemGlowPurple_Click;
            // 
            // lblSettingsColorsItemGlowPurpleTier
            // 
            lblSettingsColorsItemGlowPurpleTier.AutoSize = true;
            lblSettingsColorsItemGlowPurpleTier.Depth = 0;
            lblSettingsColorsItemGlowPurpleTier.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowPurpleTier.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowPurpleTier.Location = new Point(34, 102);
            lblSettingsColorsItemGlowPurpleTier.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowPurpleTier.Name = "lblSettingsColorsItemGlowPurpleTier";
            lblSettingsColorsItemGlowPurpleTier.Size = new Size(70, 17);
            lblSettingsColorsItemGlowPurpleTier.TabIndex = 59;
            lblSettingsColorsItemGlowPurpleTier.Text = "Purple Tier:";
            // 
            // picItemGlowGold
            // 
            picItemGlowGold.BackColor = Color.Transparent;
            picItemGlowGold.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowGold.Location = new Point(110, 72);
            picItemGlowGold.Name = "picItemGlowGold";
            picItemGlowGold.Size = new Size(70, 23);
            picItemGlowGold.TabIndex = 58;
            picItemGlowGold.TabStop = false;
            picItemGlowGold.Click += picItemGlowGold_Click;
            // 
            // lblSettingsColorsItemGlowGoldTier
            // 
            lblSettingsColorsItemGlowGoldTier.AutoSize = true;
            lblSettingsColorsItemGlowGoldTier.Depth = 0;
            lblSettingsColorsItemGlowGoldTier.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowGoldTier.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowGoldTier.Location = new Point(45, 72);
            lblSettingsColorsItemGlowGoldTier.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowGoldTier.Name = "lblSettingsColorsItemGlowGoldTier";
            lblSettingsColorsItemGlowGoldTier.Size = new Size(59, 17);
            lblSettingsColorsItemGlowGoldTier.TabIndex = 57;
            lblSettingsColorsItemGlowGoldTier.Text = "Gold Tier:";
            // 
            // picItemGlowAmmoBoxes
            // 
            picItemGlowAmmoBoxes.BackColor = Color.Transparent;
            picItemGlowAmmoBoxes.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowAmmoBoxes.Location = new Point(110, 219);
            picItemGlowAmmoBoxes.Name = "picItemGlowAmmoBoxes";
            picItemGlowAmmoBoxes.Size = new Size(70, 23);
            picItemGlowAmmoBoxes.TabIndex = 56;
            picItemGlowAmmoBoxes.TabStop = false;
            picItemGlowAmmoBoxes.Click += picItemGlowAmmoBoxes_Click;
            // 
            // lblSettingsColorsItemGlowAmmoBoxes
            // 
            lblSettingsColorsItemGlowAmmoBoxes.AutoSize = true;
            lblSettingsColorsItemGlowAmmoBoxes.Depth = 0;
            lblSettingsColorsItemGlowAmmoBoxes.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowAmmoBoxes.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowAmmoBoxes.Location = new Point(18, 219);
            lblSettingsColorsItemGlowAmmoBoxes.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowAmmoBoxes.Name = "lblSettingsColorsItemGlowAmmoBoxes";
            lblSettingsColorsItemGlowAmmoBoxes.Size = new Size(86, 17);
            lblSettingsColorsItemGlowAmmoBoxes.TabIndex = 55;
            lblSettingsColorsItemGlowAmmoBoxes.Text = "Ammo Boxes:";
            // 
            // picItemGlowWeapons
            // 
            picItemGlowWeapons.BackColor = Color.Transparent;
            picItemGlowWeapons.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowWeapons.Location = new Point(110, 190);
            picItemGlowWeapons.Name = "picItemGlowWeapons";
            picItemGlowWeapons.Size = new Size(70, 23);
            picItemGlowWeapons.TabIndex = 54;
            picItemGlowWeapons.TabStop = false;
            picItemGlowWeapons.Click += picItemGlowWeapons_Click;
            // 
            // lblSettingsColorsItemGlowWeapons
            // 
            lblSettingsColorsItemGlowWeapons.AutoSize = true;
            lblSettingsColorsItemGlowWeapons.Depth = 0;
            lblSettingsColorsItemGlowWeapons.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowWeapons.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowWeapons.Location = new Point(42, 190);
            lblSettingsColorsItemGlowWeapons.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowWeapons.Name = "lblSettingsColorsItemGlowWeapons";
            lblSettingsColorsItemGlowWeapons.Size = new Size(62, 17);
            lblSettingsColorsItemGlowWeapons.TabIndex = 53;
            lblSettingsColorsItemGlowWeapons.Text = "Weapons:";
            // 
            // picItemGlowGrey
            // 
            picItemGlowGrey.BackColor = Color.Transparent;
            picItemGlowGrey.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowGrey.Location = new Point(110, 161);
            picItemGlowGrey.Name = "picItemGlowGrey";
            picItemGlowGrey.Size = new Size(70, 23);
            picItemGlowGrey.TabIndex = 52;
            picItemGlowGrey.TabStop = false;
            picItemGlowGrey.Click += picItemGlowGrey_Click;
            // 
            // lblSettingsColorsItemGlowGreyTier
            // 
            lblSettingsColorsItemGlowGreyTier.AutoSize = true;
            lblSettingsColorsItemGlowGreyTier.Depth = 0;
            lblSettingsColorsItemGlowGreyTier.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowGreyTier.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowGreyTier.Location = new Point(45, 161);
            lblSettingsColorsItemGlowGreyTier.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowGreyTier.Name = "lblSettingsColorsItemGlowGreyTier";
            lblSettingsColorsItemGlowGreyTier.Size = new Size(59, 17);
            lblSettingsColorsItemGlowGreyTier.TabIndex = 51;
            lblSettingsColorsItemGlowGreyTier.Text = "Grey Tier:";
            // 
            // picItemGlowBlue
            // 
            picItemGlowBlue.BackColor = Color.Transparent;
            picItemGlowBlue.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowBlue.Location = new Point(110, 132);
            picItemGlowBlue.Name = "picItemGlowBlue";
            picItemGlowBlue.Size = new Size(70, 23);
            picItemGlowBlue.TabIndex = 50;
            picItemGlowBlue.TabStop = false;
            picItemGlowBlue.Click += picItemGlowBlue_Click;
            // 
            // lblSettingsColorsItemGlowBlueTier
            // 
            lblSettingsColorsItemGlowBlueTier.AutoSize = true;
            lblSettingsColorsItemGlowBlueTier.Depth = 0;
            lblSettingsColorsItemGlowBlueTier.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowBlueTier.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowBlueTier.Location = new Point(47, 132);
            lblSettingsColorsItemGlowBlueTier.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowBlueTier.Name = "lblSettingsColorsItemGlowBlueTier";
            lblSettingsColorsItemGlowBlueTier.Size = new Size(57, 17);
            lblSettingsColorsItemGlowBlueTier.TabIndex = 49;
            lblSettingsColorsItemGlowBlueTier.Text = "Blue Tier:";
            // 
            // picItemGlowRed
            // 
            picItemGlowRed.BackColor = Color.Transparent;
            picItemGlowRed.BorderStyle = BorderStyle.FixedSingle;
            picItemGlowRed.Location = new Point(110, 42);
            picItemGlowRed.Name = "picItemGlowRed";
            picItemGlowRed.Size = new Size(70, 23);
            picItemGlowRed.TabIndex = 46;
            picItemGlowRed.TabStop = false;
            picItemGlowRed.Click += picItemGlowRed_Click;
            // 
            // lblSettingsColorsItemGlowRedTier
            // 
            lblSettingsColorsItemGlowRedTier.AutoSize = true;
            lblSettingsColorsItemGlowRedTier.Depth = 0;
            lblSettingsColorsItemGlowRedTier.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlowRedTier.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsItemGlowRedTier.Location = new Point(50, 42);
            lblSettingsColorsItemGlowRedTier.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlowRedTier.Name = "lblSettingsColorsItemGlowRedTier";
            lblSettingsColorsItemGlowRedTier.Size = new Size(54, 17);
            lblSettingsColorsItemGlowRedTier.TabIndex = 44;
            lblSettingsColorsItemGlowRedTier.Text = "Red Tier:";
            // 
            // lblSettingsColorsItemGlow
            // 
            lblSettingsColorsItemGlow.AutoSize = true;
            lblSettingsColorsItemGlow.Depth = 0;
            lblSettingsColorsItemGlow.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsColorsItemGlow.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsColorsItemGlow.HighEmphasis = true;
            lblSettingsColorsItemGlow.Location = new Point(17, 12);
            lblSettingsColorsItemGlow.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsItemGlow.Name = "lblSettingsColorsItemGlow";
            lblSettingsColorsItemGlow.Size = new Size(92, 24);
            lblSettingsColorsItemGlow.TabIndex = 33;
            lblSettingsColorsItemGlow.Text = "Item Glow";
            lblSettingsColorsItemGlow.UseAccent = true;
            // 
            // mcSettingsColorsPlayerGlow
            // 
            mcSettingsColorsPlayerGlow.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowCrackedShield);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowCrackedShield);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowKnocked);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowKnocked);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowRedShield);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowRedShield);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowPurpleShield);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowPurpleShield);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowBlueShield);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowBlueShield);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowGreyShield);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowGreyShield);
            mcSettingsColorsPlayerGlow.Controls.Add(picPlayerGlowColor);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlowColor);
            mcSettingsColorsPlayerGlow.Controls.Add(lblSettingsColorsPlayerGlow);
            mcSettingsColorsPlayerGlow.Depth = 0;
            mcSettingsColorsPlayerGlow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsColorsPlayerGlow.Location = new Point(218, 14);
            mcSettingsColorsPlayerGlow.Margin = new Padding(14);
            mcSettingsColorsPlayerGlow.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsColorsPlayerGlow.Name = "mcSettingsColorsPlayerGlow";
            mcSettingsColorsPlayerGlow.Padding = new Padding(14);
            mcSettingsColorsPlayerGlow.Size = new Size(186, 322);
            mcSettingsColorsPlayerGlow.TabIndex = 46;
            // 
            // picPlayerGlowCrackedShield
            // 
            picPlayerGlowCrackedShield.BackColor = Color.Transparent;
            picPlayerGlowCrackedShield.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowCrackedShield.Location = new Point(110, 161);
            picPlayerGlowCrackedShield.Name = "picPlayerGlowCrackedShield";
            picPlayerGlowCrackedShield.Size = new Size(70, 23);
            picPlayerGlowCrackedShield.TabIndex = 60;
            picPlayerGlowCrackedShield.TabStop = false;
            picPlayerGlowCrackedShield.Click += picPlayerGlowCrackedShield_Click;
            // 
            // lblSettingsColorsPlayerGlowCrackedShield
            // 
            lblSettingsColorsPlayerGlowCrackedShield.AutoSize = true;
            lblSettingsColorsPlayerGlowCrackedShield.Depth = 0;
            lblSettingsColorsPlayerGlowCrackedShield.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowCrackedShield.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowCrackedShield.Location = new Point(9, 161);
            lblSettingsColorsPlayerGlowCrackedShield.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowCrackedShield.Name = "lblSettingsColorsPlayerGlowCrackedShield";
            lblSettingsColorsPlayerGlowCrackedShield.Size = new Size(95, 17);
            lblSettingsColorsPlayerGlowCrackedShield.TabIndex = 59;
            lblSettingsColorsPlayerGlowCrackedShield.Text = "Cracked Shield:";
            // 
            // picPlayerGlowKnocked
            // 
            picPlayerGlowKnocked.BackColor = Color.Transparent;
            picPlayerGlowKnocked.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowKnocked.Location = new Point(110, 190);
            picPlayerGlowKnocked.Name = "picPlayerGlowKnocked";
            picPlayerGlowKnocked.Size = new Size(70, 23);
            picPlayerGlowKnocked.TabIndex = 58;
            picPlayerGlowKnocked.TabStop = false;
            picPlayerGlowKnocked.Click += picPlayerGlowKnocked_Click;
            // 
            // lblSettingsColorsPlayerGlowKnocked
            // 
            lblSettingsColorsPlayerGlowKnocked.AutoSize = true;
            lblSettingsColorsPlayerGlowKnocked.Depth = 0;
            lblSettingsColorsPlayerGlowKnocked.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowKnocked.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowKnocked.Location = new Point(46, 189);
            lblSettingsColorsPlayerGlowKnocked.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowKnocked.Name = "lblSettingsColorsPlayerGlowKnocked";
            lblSettingsColorsPlayerGlowKnocked.Size = new Size(58, 17);
            lblSettingsColorsPlayerGlowKnocked.TabIndex = 57;
            lblSettingsColorsPlayerGlowKnocked.Text = "Knocked:";
            // 
            // picPlayerGlowRedShield
            // 
            picPlayerGlowRedShield.BackColor = Color.Transparent;
            picPlayerGlowRedShield.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowRedShield.Location = new Point(110, 42);
            picPlayerGlowRedShield.Name = "picPlayerGlowRedShield";
            picPlayerGlowRedShield.Size = new Size(70, 23);
            picPlayerGlowRedShield.TabIndex = 56;
            picPlayerGlowRedShield.TabStop = false;
            picPlayerGlowRedShield.Click += picPlayerGlowRedShield_Click;
            // 
            // lblSettingsColorsPlayerGlowRedShield
            // 
            lblSettingsColorsPlayerGlowRedShield.AutoSize = true;
            lblSettingsColorsPlayerGlowRedShield.Depth = 0;
            lblSettingsColorsPlayerGlowRedShield.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowRedShield.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowRedShield.Location = new Point(36, 42);
            lblSettingsColorsPlayerGlowRedShield.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowRedShield.Name = "lblSettingsColorsPlayerGlowRedShield";
            lblSettingsColorsPlayerGlowRedShield.Size = new Size(68, 17);
            lblSettingsColorsPlayerGlowRedShield.TabIndex = 55;
            lblSettingsColorsPlayerGlowRedShield.Text = "Red Shield:";
            // 
            // picPlayerGlowPurpleShield
            // 
            picPlayerGlowPurpleShield.BackColor = Color.Transparent;
            picPlayerGlowPurpleShield.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowPurpleShield.Location = new Point(110, 72);
            picPlayerGlowPurpleShield.Name = "picPlayerGlowPurpleShield";
            picPlayerGlowPurpleShield.Size = new Size(70, 23);
            picPlayerGlowPurpleShield.TabIndex = 54;
            picPlayerGlowPurpleShield.TabStop = false;
            picPlayerGlowPurpleShield.Click += picPlayerGlowPurpleShield_Click;
            // 
            // lblSettingsColorsPlayerGlowPurpleShield
            // 
            lblSettingsColorsPlayerGlowPurpleShield.AutoSize = true;
            lblSettingsColorsPlayerGlowPurpleShield.Depth = 0;
            lblSettingsColorsPlayerGlowPurpleShield.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowPurpleShield.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowPurpleShield.Location = new Point(20, 72);
            lblSettingsColorsPlayerGlowPurpleShield.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowPurpleShield.Name = "lblSettingsColorsPlayerGlowPurpleShield";
            lblSettingsColorsPlayerGlowPurpleShield.Size = new Size(84, 17);
            lblSettingsColorsPlayerGlowPurpleShield.TabIndex = 53;
            lblSettingsColorsPlayerGlowPurpleShield.Text = "Purple Shield:";
            // 
            // picPlayerGlowBlueShield
            // 
            picPlayerGlowBlueShield.BackColor = Color.Transparent;
            picPlayerGlowBlueShield.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowBlueShield.Location = new Point(110, 102);
            picPlayerGlowBlueShield.Name = "picPlayerGlowBlueShield";
            picPlayerGlowBlueShield.Size = new Size(70, 23);
            picPlayerGlowBlueShield.TabIndex = 52;
            picPlayerGlowBlueShield.TabStop = false;
            picPlayerGlowBlueShield.Click += picPlayerGlowBlueShield_Click;
            // 
            // lblSettingsColorsPlayerGlowBlueShield
            // 
            lblSettingsColorsPlayerGlowBlueShield.AutoSize = true;
            lblSettingsColorsPlayerGlowBlueShield.Depth = 0;
            lblSettingsColorsPlayerGlowBlueShield.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowBlueShield.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowBlueShield.Location = new Point(33, 102);
            lblSettingsColorsPlayerGlowBlueShield.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowBlueShield.Name = "lblSettingsColorsPlayerGlowBlueShield";
            lblSettingsColorsPlayerGlowBlueShield.Size = new Size(71, 17);
            lblSettingsColorsPlayerGlowBlueShield.TabIndex = 51;
            lblSettingsColorsPlayerGlowBlueShield.Text = "Blue Shield:";
            // 
            // picPlayerGlowGreyShield
            // 
            picPlayerGlowGreyShield.BackColor = Color.Transparent;
            picPlayerGlowGreyShield.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowGreyShield.Location = new Point(110, 132);
            picPlayerGlowGreyShield.Name = "picPlayerGlowGreyShield";
            picPlayerGlowGreyShield.Size = new Size(70, 23);
            picPlayerGlowGreyShield.TabIndex = 50;
            picPlayerGlowGreyShield.TabStop = false;
            picPlayerGlowGreyShield.Click += picPlayerGlowGreyShield_Click;
            // 
            // lblSettingsColorsPlayerGlowGreyShield
            // 
            lblSettingsColorsPlayerGlowGreyShield.AutoSize = true;
            lblSettingsColorsPlayerGlowGreyShield.Depth = 0;
            lblSettingsColorsPlayerGlowGreyShield.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowGreyShield.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowGreyShield.Location = new Point(31, 132);
            lblSettingsColorsPlayerGlowGreyShield.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowGreyShield.Name = "lblSettingsColorsPlayerGlowGreyShield";
            lblSettingsColorsPlayerGlowGreyShield.Size = new Size(73, 17);
            lblSettingsColorsPlayerGlowGreyShield.TabIndex = 49;
            lblSettingsColorsPlayerGlowGreyShield.Text = "Grey Shield:";
            // 
            // picPlayerGlowColor
            // 
            picPlayerGlowColor.BackColor = Color.Transparent;
            picPlayerGlowColor.BorderStyle = BorderStyle.FixedSingle;
            picPlayerGlowColor.Location = new Point(110, 219);
            picPlayerGlowColor.Name = "picPlayerGlowColor";
            picPlayerGlowColor.Size = new Size(70, 23);
            picPlayerGlowColor.TabIndex = 46;
            picPlayerGlowColor.TabStop = false;
            picPlayerGlowColor.Click += picPlayerGlowVisible_Click;
            // 
            // lblSettingsColorsPlayerGlowColor
            // 
            lblSettingsColorsPlayerGlowColor.AutoSize = true;
            lblSettingsColorsPlayerGlowColor.Depth = 0;
            lblSettingsColorsPlayerGlowColor.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlowColor.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayerGlowColor.Location = new Point(51, 219);
            lblSettingsColorsPlayerGlowColor.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlowColor.Name = "lblSettingsColorsPlayerGlowColor";
            lblSettingsColorsPlayerGlowColor.Size = new Size(53, 17);
            lblSettingsColorsPlayerGlowColor.TabIndex = 44;
            lblSettingsColorsPlayerGlowColor.Text = "Custom:";
            // 
            // lblSettingsColorsPlayerGlow
            // 
            lblSettingsColorsPlayerGlow.AutoSize = true;
            lblSettingsColorsPlayerGlow.Depth = 0;
            lblSettingsColorsPlayerGlow.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsColorsPlayerGlow.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsColorsPlayerGlow.HighEmphasis = true;
            lblSettingsColorsPlayerGlow.Location = new Point(17, 12);
            lblSettingsColorsPlayerGlow.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayerGlow.Name = "lblSettingsColorsPlayerGlow";
            lblSettingsColorsPlayerGlow.Size = new Size(108, 24);
            lblSettingsColorsPlayerGlow.TabIndex = 33;
            lblSettingsColorsPlayerGlow.Text = "Player Glow";
            lblSettingsColorsPlayerGlow.UseAccent = true;
            // 
            // mcSettingsColorsOther
            // 
            mcSettingsColorsOther.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsColorsOther.Controls.Add(btnResetTheme);
            mcSettingsColorsOther.Controls.Add(picOtherAccent);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorOtherAccent);
            mcSettingsColorsOther.Controls.Add(picOtherPrimaryLight);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorOtherPrimaryLight);
            mcSettingsColorsOther.Controls.Add(picOtherPrimaryDark);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorOtherPrimaryDark);
            mcSettingsColorsOther.Controls.Add(picOtherPrimary);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorOtherPrimary);
            mcSettingsColorsOther.Controls.Add(picOtherTextOutline);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorOtherTextOutline);
            mcSettingsColorsOther.Controls.Add(lblSettingsColorsOther);
            mcSettingsColorsOther.Depth = 0;
            mcSettingsColorsOther.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsColorsOther.Location = new Point(612, 14);
            mcSettingsColorsOther.Margin = new Padding(14);
            mcSettingsColorsOther.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsColorsOther.Name = "mcSettingsColorsOther";
            mcSettingsColorsOther.Padding = new Padding(14);
            mcSettingsColorsOther.Size = new Size(186, 322);
            mcSettingsColorsOther.TabIndex = 45;
            // 
            // picOtherAccent
            // 
            picOtherAccent.BackColor = Color.Transparent;
            picOtherAccent.BorderStyle = BorderStyle.FixedSingle;
            picOtherAccent.Location = new Point(109, 160);
            picOtherAccent.Name = "picOtherAccent";
            picOtherAccent.Size = new Size(70, 23);
            picOtherAccent.TabIndex = 58;
            picOtherAccent.TabStop = false;
            picOtherAccent.Click += picOtherAccent_Click;
            // 
            // lblSettingsColorOtherAccent
            // 
            lblSettingsColorOtherAccent.AutoSize = true;
            lblSettingsColorOtherAccent.Depth = 0;
            lblSettingsColorOtherAccent.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorOtherAccent.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorOtherAccent.Location = new Point(56, 160);
            lblSettingsColorOtherAccent.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorOtherAccent.Name = "lblSettingsColorOtherAccent";
            lblSettingsColorOtherAccent.Size = new Size(47, 17);
            lblSettingsColorOtherAccent.TabIndex = 57;
            lblSettingsColorOtherAccent.Text = "Accent:";
            // 
            // picOtherPrimaryLight
            // 
            picOtherPrimaryLight.BackColor = Color.Transparent;
            picOtherPrimaryLight.BorderStyle = BorderStyle.FixedSingle;
            picOtherPrimaryLight.Location = new Point(109, 131);
            picOtherPrimaryLight.Name = "picOtherPrimaryLight";
            picOtherPrimaryLight.Size = new Size(70, 23);
            picOtherPrimaryLight.TabIndex = 56;
            picOtherPrimaryLight.TabStop = false;
            picOtherPrimaryLight.Click += picOtherPrimaryLight_Click;
            // 
            // lblSettingsColorOtherPrimaryLight
            // 
            lblSettingsColorOtherPrimaryLight.AutoSize = true;
            lblSettingsColorOtherPrimaryLight.Depth = 0;
            lblSettingsColorOtherPrimaryLight.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorOtherPrimaryLight.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorOtherPrimaryLight.Location = new Point(15, 131);
            lblSettingsColorOtherPrimaryLight.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorOtherPrimaryLight.Name = "lblSettingsColorOtherPrimaryLight";
            lblSettingsColorOtherPrimaryLight.Size = new Size(88, 17);
            lblSettingsColorOtherPrimaryLight.TabIndex = 55;
            lblSettingsColorOtherPrimaryLight.Text = "Primary Light:";
            // 
            // picOtherPrimaryDark
            // 
            picOtherPrimaryDark.BackColor = Color.Transparent;
            picOtherPrimaryDark.BorderStyle = BorderStyle.FixedSingle;
            picOtherPrimaryDark.Location = new Point(109, 102);
            picOtherPrimaryDark.Name = "picOtherPrimaryDark";
            picOtherPrimaryDark.Size = new Size(70, 23);
            picOtherPrimaryDark.TabIndex = 54;
            picOtherPrimaryDark.TabStop = false;
            picOtherPrimaryDark.Click += picOtherPrimaryDark_Click;
            // 
            // lblSettingsColorOtherPrimaryDark
            // 
            lblSettingsColorOtherPrimaryDark.AutoSize = true;
            lblSettingsColorOtherPrimaryDark.Depth = 0;
            lblSettingsColorOtherPrimaryDark.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorOtherPrimaryDark.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorOtherPrimaryDark.Location = new Point(18, 102);
            lblSettingsColorOtherPrimaryDark.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorOtherPrimaryDark.Name = "lblSettingsColorOtherPrimaryDark";
            lblSettingsColorOtherPrimaryDark.Size = new Size(85, 17);
            lblSettingsColorOtherPrimaryDark.TabIndex = 53;
            lblSettingsColorOtherPrimaryDark.Text = "Primary Dark:";
            // 
            // picOtherPrimary
            // 
            picOtherPrimary.BackColor = Color.Transparent;
            picOtherPrimary.BorderStyle = BorderStyle.FixedSingle;
            picOtherPrimary.Location = new Point(109, 72);
            picOtherPrimary.Name = "picOtherPrimary";
            picOtherPrimary.Size = new Size(70, 23);
            picOtherPrimary.TabIndex = 52;
            picOtherPrimary.TabStop = false;
            picOtherPrimary.Click += picOtherPrimary_Click;
            // 
            // lblSettingsColorOtherPrimary
            // 
            lblSettingsColorOtherPrimary.AutoSize = true;
            lblSettingsColorOtherPrimary.Depth = 0;
            lblSettingsColorOtherPrimary.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorOtherPrimary.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorOtherPrimary.Location = new Point(50, 72);
            lblSettingsColorOtherPrimary.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorOtherPrimary.Name = "lblSettingsColorOtherPrimary";
            lblSettingsColorOtherPrimary.Size = new Size(53, 17);
            lblSettingsColorOtherPrimary.TabIndex = 51;
            lblSettingsColorOtherPrimary.Text = "Primary:";
            // 
            // picOtherTextOutline
            // 
            picOtherTextOutline.BackColor = Color.Transparent;
            picOtherTextOutline.BorderStyle = BorderStyle.FixedSingle;
            picOtherTextOutline.Location = new Point(109, 42);
            picOtherTextOutline.Name = "picOtherTextOutline";
            picOtherTextOutline.Size = new Size(70, 23);
            picOtherTextOutline.TabIndex = 46;
            picOtherTextOutline.TabStop = false;
            picOtherTextOutline.Click += picOtherTextOutline_Click;
            // 
            // lblSettingsColorOtherTextOutline
            // 
            lblSettingsColorOtherTextOutline.AutoSize = true;
            lblSettingsColorOtherTextOutline.Depth = 0;
            lblSettingsColorOtherTextOutline.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorOtherTextOutline.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorOtherTextOutline.Location = new Point(25, 42);
            lblSettingsColorOtherTextOutline.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorOtherTextOutline.Name = "lblSettingsColorOtherTextOutline";
            lblSettingsColorOtherTextOutline.Size = new Size(78, 17);
            lblSettingsColorOtherTextOutline.TabIndex = 44;
            lblSettingsColorOtherTextOutline.Text = "Text Outline:";
            // 
            // lblSettingsColorsOther
            // 
            lblSettingsColorsOther.AutoSize = true;
            lblSettingsColorsOther.Depth = 0;
            lblSettingsColorsOther.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsColorsOther.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsColorsOther.HighEmphasis = true;
            lblSettingsColorsOther.Location = new Point(17, 12);
            lblSettingsColorsOther.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsOther.Name = "lblSettingsColorsOther";
            lblSettingsColorsOther.Size = new Size(51, 24);
            lblSettingsColorsOther.TabIndex = 33;
            lblSettingsColorsOther.Text = "Other";
            lblSettingsColorsOther.UseAccent = true;
            // 
            // mcSettingsColorsPlayers
            // 
            mcSettingsColorsPlayers.BackColor = Color.FromArgb(255, 255, 255);
            mcSettingsColorsPlayers.Controls.Add(picPlayersLastAlive);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorPlayersLastAlive);
            mcSettingsColorsPlayers.Controls.Add(picPlayersMixtapeEnemy);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorsPlayersMixtapeEnemy);
            mcSettingsColorsPlayers.Controls.Add(picPlayersTeamHover);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorsPlayersTeamHover);
            mcSettingsColorsPlayers.Controls.Add(picPlayersTeammate);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorsPlayersTeammate);
            mcSettingsColorsPlayers.Controls.Add(picPlayersLocalPlayer);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorsPlayersLocalPlayer);
            mcSettingsColorsPlayers.Controls.Add(lblSettingsColorsPlayers);
            mcSettingsColorsPlayers.Depth = 0;
            mcSettingsColorsPlayers.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mcSettingsColorsPlayers.Location = new Point(15, 14);
            mcSettingsColorsPlayers.Margin = new Padding(14);
            mcSettingsColorsPlayers.MouseState = MaterialSkin.MouseState.HOVER;
            mcSettingsColorsPlayers.Name = "mcSettingsColorsPlayers";
            mcSettingsColorsPlayers.Padding = new Padding(14);
            mcSettingsColorsPlayers.Size = new Size(191, 322);
            mcSettingsColorsPlayers.TabIndex = 44;
            // 
            // picPlayersLastAlive
            // 
            picPlayersLastAlive.BackColor = Color.Transparent;
            picPlayersLastAlive.BorderStyle = BorderStyle.FixedSingle;
            picPlayersLastAlive.Location = new Point(115, 161);
            picPlayersLastAlive.Name = "picPlayersLastAlive";
            picPlayersLastAlive.Size = new Size(70, 23);
            picPlayersLastAlive.TabIndex = 61;
            picPlayersLastAlive.TabStop = false;
            picPlayersLastAlive.Click += picPlayersLastAlive_Click;
            // 
            // lblSettingsColorPlayersLastAlive
            // 
            lblSettingsColorPlayersLastAlive.AutoSize = true;
            lblSettingsColorPlayersLastAlive.Depth = 0;
            lblSettingsColorPlayersLastAlive.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorPlayersLastAlive.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorPlayersLastAlive.Location = new Point(45, 161);
            lblSettingsColorPlayersLastAlive.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorPlayersLastAlive.Name = "lblSettingsColorPlayersLastAlive";
            lblSettingsColorPlayersLastAlive.Size = new Size(64, 17);
            lblSettingsColorPlayersLastAlive.TabIndex = 60;
            lblSettingsColorPlayersLastAlive.Text = "Last Alive:";
            // 
            // picPlayersMixtapeEnemy
            // 
            picPlayersMixtapeEnemy.BackColor = Color.Transparent;
            picPlayersMixtapeEnemy.BorderStyle = BorderStyle.FixedSingle;
            picPlayersMixtapeEnemy.Location = new Point(115, 132);
            picPlayersMixtapeEnemy.Name = "picPlayersMixtapeEnemy";
            picPlayersMixtapeEnemy.Size = new Size(70, 23);
            picPlayersMixtapeEnemy.TabIndex = 58;
            picPlayersMixtapeEnemy.TabStop = false;
            picPlayersMixtapeEnemy.Click += picPlayersMixtapeEnemy_Click;
            // 
            // lblSettingsColorsPlayersMixtapeEnemy
            // 
            lblSettingsColorsPlayersMixtapeEnemy.AutoSize = true;
            lblSettingsColorsPlayersMixtapeEnemy.Depth = 0;
            lblSettingsColorsPlayersMixtapeEnemy.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayersMixtapeEnemy.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayersMixtapeEnemy.Location = new Point(10, 132);
            lblSettingsColorsPlayersMixtapeEnemy.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayersMixtapeEnemy.Name = "lblSettingsColorsPlayersMixtapeEnemy";
            lblSettingsColorsPlayersMixtapeEnemy.Size = new Size(99, 17);
            lblSettingsColorsPlayersMixtapeEnemy.TabIndex = 57;
            lblSettingsColorsPlayersMixtapeEnemy.Text = "Mixtape Enemy:";
            // 
            // picPlayersTeamHover
            // 
            picPlayersTeamHover.BackColor = Color.Transparent;
            picPlayersTeamHover.BorderStyle = BorderStyle.FixedSingle;
            picPlayersTeamHover.Location = new Point(115, 102);
            picPlayersTeamHover.Name = "picPlayersTeamHover";
            picPlayersTeamHover.Size = new Size(70, 23);
            picPlayersTeamHover.TabIndex = 56;
            picPlayersTeamHover.TabStop = false;
            picPlayersTeamHover.Click += picPlayersTeamHover_Click;
            // 
            // lblSettingsColorsPlayersTeamHover
            // 
            lblSettingsColorsPlayersTeamHover.AutoSize = true;
            lblSettingsColorsPlayersTeamHover.Depth = 0;
            lblSettingsColorsPlayersTeamHover.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayersTeamHover.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayersTeamHover.Location = new Point(30, 102);
            lblSettingsColorsPlayersTeamHover.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayersTeamHover.Name = "lblSettingsColorsPlayersTeamHover";
            lblSettingsColorsPlayersTeamHover.Size = new Size(79, 17);
            lblSettingsColorsPlayersTeamHover.TabIndex = 55;
            lblSettingsColorsPlayersTeamHover.Text = "Team Hover:";
            // 
            // picPlayersTeammate
            // 
            picPlayersTeammate.BackColor = Color.Transparent;
            picPlayersTeammate.BorderStyle = BorderStyle.FixedSingle;
            picPlayersTeammate.Location = new Point(115, 72);
            picPlayersTeammate.Name = "picPlayersTeammate";
            picPlayersTeammate.Size = new Size(70, 23);
            picPlayersTeammate.TabIndex = 54;
            picPlayersTeammate.TabStop = false;
            picPlayersTeammate.Click += picPlayersTeammate_Click;
            // 
            // lblSettingsColorsPlayersTeammate
            // 
            lblSettingsColorsPlayersTeammate.AutoSize = true;
            lblSettingsColorsPlayersTeammate.Depth = 0;
            lblSettingsColorsPlayersTeammate.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayersTeammate.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayersTeammate.Location = new Point(38, 72);
            lblSettingsColorsPlayersTeammate.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayersTeammate.Name = "lblSettingsColorsPlayersTeammate";
            lblSettingsColorsPlayersTeammate.Size = new Size(71, 17);
            lblSettingsColorsPlayersTeammate.TabIndex = 53;
            lblSettingsColorsPlayersTeammate.Text = "Teammate:";
            // 
            // picPlayersLocalPlayer
            // 
            picPlayersLocalPlayer.BackColor = Color.Transparent;
            picPlayersLocalPlayer.BorderStyle = BorderStyle.FixedSingle;
            picPlayersLocalPlayer.Location = new Point(115, 42);
            picPlayersLocalPlayer.Name = "picPlayersLocalPlayer";
            picPlayersLocalPlayer.Size = new Size(70, 23);
            picPlayersLocalPlayer.TabIndex = 52;
            picPlayersLocalPlayer.TabStop = false;
            picPlayersLocalPlayer.Click += picPlayersLocalPlayer_Click;
            // 
            // lblSettingsColorsPlayersLocalPlayer
            // 
            lblSettingsColorsPlayersLocalPlayer.AutoSize = true;
            lblSettingsColorsPlayersLocalPlayer.Depth = 0;
            lblSettingsColorsPlayersLocalPlayer.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSettingsColorsPlayersLocalPlayer.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblSettingsColorsPlayersLocalPlayer.Location = new Point(32, 42);
            lblSettingsColorsPlayersLocalPlayer.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayersLocalPlayer.Name = "lblSettingsColorsPlayersLocalPlayer";
            lblSettingsColorsPlayersLocalPlayer.Size = new Size(77, 17);
            lblSettingsColorsPlayersLocalPlayer.TabIndex = 51;
            lblSettingsColorsPlayersLocalPlayer.Text = "LocalPlayer:";
            // 
            // lblSettingsColorsPlayers
            // 
            lblSettingsColorsPlayers.AutoSize = true;
            lblSettingsColorsPlayers.Depth = 0;
            lblSettingsColorsPlayers.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSettingsColorsPlayers.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblSettingsColorsPlayers.HighEmphasis = true;
            lblSettingsColorsPlayers.Location = new Point(17, 12);
            lblSettingsColorsPlayers.MouseState = MaterialSkin.MouseState.HOVER;
            lblSettingsColorsPlayers.Name = "lblSettingsColorsPlayers";
            lblSettingsColorsPlayers.Size = new Size(68, 24);
            lblSettingsColorsPlayers.TabIndex = 33;
            lblSettingsColorsPlayers.Text = "Players";
            lblSettingsColorsPlayers.UseAccent = true;
            // 
            // iconList
            // 
            iconList.ColorDepth = ColorDepth.Depth32Bit;
            iconList.ImageStream = (ImageListStreamer)resources.GetObject("iconList.ImageStream");
            iconList.TransparentColor = Color.Transparent;
            iconList.Images.SetKeyName(0, "radar.png");
            iconList.Images.SetKeyName(1, "settings.png");
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1380, 770);
            Controls.Add(tabControlMain);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tabControlMain;
            DrawerWidth = 180;
            FormStyle = FormStyles.ActionBar_None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            Padding = new Padding(0, 24, 0, 0);
            Text = "d";
            Shown += frmMain_Shown;
            tabControlMain.ResumeLayout(false);
            tabRadar.ResumeLayout(false);
            mcRadarStats.ResumeLayout(false);
            mcRadarStats.PerformLayout();
            mcRadarSettings.ResumeLayout(false);
            mcRadarMapSetup.ResumeLayout(false);
            mcRadarMapSetup.PerformLayout();
            tabSettings.ResumeLayout(false);
            tabControlSettings.ResumeLayout(false);
            tabSettingsGeneral.ResumeLayout(false);
            mcSettingsGeneralUI.ResumeLayout(false);
            mcSettingsGeneralUI.PerformLayout();
            mcSettingsGeneralPlayerInformation.ResumeLayout(false);
            mcSettingsGeneralPlayerInformation.PerformLayout();
            mcSettingsGeneralRadar.ResumeLayout(false);
            mcSettingsGeneralRadar.PerformLayout();
            tabSettingsMemoryWriting.ResumeLayout(false);
            mcSettingsMemoryWritingItemGlow.ResumeLayout(false);
            mcSettingsMemoryWritingItemGlow.PerformLayout();
            mcSettingsMemoryWritingViewModelGlow.ResumeLayout(false);
            mcSettingsMemoryWritingViewModelGlow.PerformLayout();
            mcSettingsMemoryWritingPlayerGlow.ResumeLayout(false);
            mcSettingsMemoryWritingPlayerGlow.PerformLayout();
            tabSettingsColors.ResumeLayout(false);
            mcSettingsColorsItemGlow.ResumeLayout(false);
            mcSettingsColorsItemGlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picItemGlowPurple).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowGold).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowAmmoBoxes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowWeapons).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowGrey).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowBlue).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItemGlowRed).EndInit();
            mcSettingsColorsPlayerGlow.ResumeLayout(false);
            mcSettingsColorsPlayerGlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowCrackedShield).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowKnocked).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowRedShield).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowPurpleShield).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowBlueShield).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowGreyShield).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayerGlowColor).EndInit();
            mcSettingsColorsOther.ResumeLayout(false);
            mcSettingsColorsOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picOtherAccent).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimaryLight).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimaryDark).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOtherPrimary).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOtherTextOutline).EndInit();
            mcSettingsColorsPlayers.ResumeLayout(false);
            mcSettingsColorsPlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPlayersLastAlive).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersMixtapeEnemy).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersTeamHover).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersTeammate).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlayersLocalPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ColorDialog colDialog;
        private ToolTip toolTip;
        private MaterialSkin.Controls.MaterialTabControl tabControlMain;
        private TabPage tabRadar;
        private TabPage tabSettings;
        private MaterialSkin.Controls.MaterialTabControl tabControlSettings;
        private TabPage tabSettingsGeneral;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private ImageList iconList;
        private MaterialSkin.Controls.MaterialCard mcSettingsGeneralRadar;
        private MaterialSkin.Controls.MaterialSwitch swMapHelper;
        private MaterialSkin.Controls.MaterialButton btnRestartRadar;
        private MaterialSkin.Controls.MaterialLabel lblSettingsGeneralRadar;
        private SkiaSharp.Views.Desktop.SKGLControl skMapCanvas;
        private MaterialSkin.Controls.MaterialCard mcRadarMapSetup;
        private MaterialSkin.Controls.MaterialLabel lblRadarMapSetup;
        private MaterialSkin.Controls.MaterialTextBox2 txtMapSetupX;
        private MaterialSkin.Controls.MaterialButton btnMapSetupApply;
        private MaterialSkin.Controls.MaterialTextBox2 txtMapSetupScale;
        private MaterialSkin.Controls.MaterialTextBox2 txtMapSetupY;
        private MaterialSkin.Controls.MaterialButton btnToggleMapFree;
        private MaterialSkin.Controls.MaterialCard mcRadarSettings;
        private MaterialSkin.Controls.MaterialSwitch swRadarStats;
        private MaterialSkin.Controls.MaterialCard mcRadarStats;
        private MaterialSkin.Controls.MaterialLabel lblRadarFPS;
        private MaterialSkin.Controls.MaterialLabel lblRadarFPSValue;
        private MaterialSkin.Controls.MaterialLabel lblRadarMemSValue;
        private MaterialSkin.Controls.MaterialLabel lblRadarMemS;
        private MaterialSkin.Controls.MaterialLabel lblRadarPlayersValue;
        private MaterialSkin.Controls.MaterialLabel lblRadarPlayers;
        private MaterialSkin.Controls.MaterialSwitch swRadarVsync;
        private TabPage tabSettingsMemoryWriting;
        private MaterialSkin.Controls.MaterialCard mcSettingsMemoryWritingPlayerGlow;
        private MaterialSkin.Controls.MaterialSwitch swMasterSwitch;
        private MaterialSkin.Controls.MaterialSwitch swPlayerGlow;
        private MaterialSkin.Controls.MaterialLabel lblSettingsMemoryWritingPlayerGlow;
        private MaterialSkin.Controls.MaterialCard mcSettingsGeneralPlayerInformation;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerInfoFontSize;
        private MaterialSkin.Controls.MaterialComboBox cboPlayerInfoFont;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerInfoFlagsFontSize;
        private MaterialSkin.Controls.MaterialComboBox cboPlayerInfoFlagsFont;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerInfoAimlineOpacity;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoAimline;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerInfoAimlineLength;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoHealth;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoDistance;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoHeight;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoFlags;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoActiveWeapon;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoName;
        private MaterialSkin.Controls.MaterialComboBox cboPlayerInfoType;
        private MaterialSkin.Controls.MaterialLabel lblSettingsGeneralPlayerInformation;
        private MaterialSkin.Controls.MaterialCard mcSettingsGeneralUI;
        private MaterialSkin.Controls.MaterialSlider sldrZoomSensitivity;
        private MaterialSkin.Controls.MaterialComboBox cboGlobalFont;
        private MaterialSkin.Controls.MaterialSlider sldrGlobalFontSize;
        private MaterialSkin.Controls.MaterialLabel lblSettingsGeneralUI;
        private MaterialSkin.Controls.MaterialSlider sldrUIScale;
        private TabPage tabSettingsColors;
        private MaterialSkin.Controls.MaterialCard mcSettingsColorsOther;
        private MaterialSkin.Controls.MaterialButton btnResetTheme;
        private PictureBox picOtherAccent;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorOtherAccent;
        private PictureBox picOtherPrimaryLight;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorOtherPrimaryLight;
        private PictureBox picOtherPrimaryDark;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorOtherPrimaryDark;
        private PictureBox picOtherPrimary;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorOtherPrimary;
        private PictureBox picOtherTextOutline;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorOtherTextOutline;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsOther;
        private MaterialSkin.Controls.MaterialCard mcSettingsColorsPlayers;
        private PictureBox picPlayersTeamHover;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayersTeamHover;
        private PictureBox picPlayersTeammate;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayersTeammate;
        private PictureBox picPlayersLocalPlayer;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayersLocalPlayer;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayers;
        private MaterialSkin.Controls.MaterialLabel lblRadarPlayersAliveValue;
        private MaterialSkin.Controls.MaterialLabel lblRadarPlayersAlive;
        private MaterialSkin.Controls.MaterialSwitch swSpectators;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoLegend;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoShield;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoXPLevel;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoLastAlive;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoKnocked;
        private MaterialSkin.Controls.MaterialSwitch swHighlightLastAlive;
        private PictureBox picPlayersLastAlive;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorPlayersLastAlive;
        private PictureBox picPlayersMixtapeEnemy;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayersMixtapeEnemy;
        private MaterialSkin.Controls.MaterialSwitch swPlayerInfoShieldLevel;
        private MaterialSkin.Controls.MaterialTextBox2 txtPlayerGlowInsideFunction;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerGlowInsideFunction;
        private MaterialSkin.Controls.MaterialTextBox2 txtPlayerGlowOutlineRadius;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerGlowOutlineRadius;
        private MaterialSkin.Controls.MaterialTextBox2 txtPlayerGlowOutlineFunction;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerGlowOutlineFunction;
        private MaterialSkin.Controls.MaterialTextBox2 txtPlayerGlowBrightness;
        private MaterialSkin.Controls.MaterialSlider sldrPlayerGlowBrightness;
        private MaterialSkin.Controls.MaterialSwitch swPlayerGlowShieldBased;
        private MaterialSkin.Controls.MaterialCard mcSettingsColorsPlayerGlow;
        private PictureBox picPlayerGlowColor;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowColor;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlow;
        private PictureBox picPlayerGlowRedShield;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowRedShield;
        private PictureBox picPlayerGlowPurpleShield;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowPurpleShield;
        private PictureBox picPlayerGlowBlueShield;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowBlueShield;
        private PictureBox picPlayerGlowGreyShield;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowGreyShield;
        private PictureBox picPlayerGlowKnocked;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowKnocked;
        private PictureBox picPlayerGlowCrackedShield;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsPlayerGlowCrackedShield;
        private MaterialSkin.Controls.MaterialCard mcSettingsMemoryWritingViewModelGlow;
        private MaterialSkin.Controls.MaterialTextBox2 txtViewModelEffect;
        private MaterialSkin.Controls.MaterialSlider sldrViewModelEffect;
        private MaterialSkin.Controls.MaterialSwitch swViewModelGlow;
        private MaterialSkin.Controls.MaterialLabel lblSettingsMemoryWritingViewModelGlow;
        private MaterialSkin.Controls.MaterialCard mcSettingsMemoryWritingItemGlow;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemGlowOutlineRadius;
        private MaterialSkin.Controls.MaterialSlider sldrItemGlowOutlineRadius;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemGlowOutlineFunction;
        private MaterialSkin.Controls.MaterialSlider sldrItemGlowOutlineFunction;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemGlowInsideFunction;
        private MaterialSkin.Controls.MaterialSlider sldrItemGlowInsideFunction;
        private MaterialSkin.Controls.MaterialSwitch swItemGlow;
        private MaterialSkin.Controls.MaterialLabel lblSettingsMemoryWritingItemGlow;
        private MaterialSkin.Controls.MaterialTextBox2 txtItemGlowBrightness;
        private MaterialSkin.Controls.MaterialSlider sldrItemGlowBrightness;
        private MaterialSkin.Controls.MaterialSwitch swItemGlowColor;
        private MaterialSkin.Controls.MaterialComboBox cboItemGlowType;
        private MaterialSkin.Controls.MaterialCard mcSettingsColorsItemGlow;
        private PictureBox picItemGlowPurple;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowPurpleTier;
        private PictureBox picItemGlowGold;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowGoldTier;
        private PictureBox picItemGlowAmmoBoxes;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowAmmoBoxes;
        private PictureBox picItemGlowWeapons;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowWeapons;
        private PictureBox picItemGlowGrey;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowGreyTier;
        private PictureBox picItemGlowBlue;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowBlueTier;
        private PictureBox picItemGlowRed;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlowRedTier;
        private MaterialSkin.Controls.MaterialLabel lblSettingsColorsItemGlow;
    }
}

