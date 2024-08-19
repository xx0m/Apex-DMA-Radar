using SkiaSharp;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace apex_dma_radar
{
    /// <summary>
    /// Defines map position for the 2D Map.
    /// </summary>
    public struct MapPosition
    {
        public MapPosition()
        {
        }
        /// <summary>
        /// Contains the Skia Interface (UI) Scaling Value.
        /// </summary>
        public float UIScale = 0;

        /// <summary>
        /// X coordinate on Bitmap.
        /// </summary>
        public float X = 0;

        /// <summary>
        /// Y coordinate on Bitmap.
        /// </summary>
        public float Y = 0;

        /// <summary>
        /// Unit 'height' as determined by Vector3.Z
        /// </summary>
        public float Height = 0;

        /// <summary>
        /// Get exact player location (with optional X,Y offsets).
        /// </summary>
        public SKPoint GetPoint(float xOff = 0, float yOff = 0)
        {
            return new SKPoint(X + xOff, Y + yOff);
        }

        /// <summary>
        /// Gets the point where the Aimline 'Line' ends. Applies UI Scaling internally.
        /// </summary>
        private SKPoint GetAimlineEndpoint(double radians, float aimlineLength)
        {
            aimlineLength *= UIScale;
            return new SKPoint((float)(this.X + Math.Cos(radians) * aimlineLength), (float)(this.Y + Math.Sin(radians) * aimlineLength));
        }

        /// <summary>
        /// Gets up arrow where loot is. IDisposable. Applies UI Scaling internally.
        /// </summary>
        private SKPath GetUpArrow(float size = 6)
        {
            size *= UIScale;
            SKPath path = new SKPath();
            path.MoveTo(X, Y);
            path.LineTo(X - size, Y + size);
            path.LineTo(X + size, Y + size);
            path.Close();

            return path;
        }

        /// <summary>
        /// Gets down arrow where loot is. IDisposable. Applies UI Scaling internally.
        /// </summary>
        private SKPath GetDownArrow(float size = 6)
        {
            size *= UIScale;
            SKPath path = new SKPath();
            path.MoveTo(X, Y);
            path.LineTo(X - size, Y - size);
            path.LineTo(X + size, Y - size);
            path.Close();

            return path;
        }

        /// <summary>
        /// Draws a Player Marker on this location.
        /// </summary>
        public void DrawPlayerMarker(SKCanvas canvas, Player player, AimlineSettings aimlineSettings, int? mouseoverGrp)
        {
            var x = (player.IsLocalPlayer ? player.Rotation.X : player.Yaw);
            var radians = x.ToRadians();
            //SKPaint markerPaint, aimlinePaint;
            SKPaint markerPaint;

            if (mouseoverGrp == player.TeamID)
            {
                markerPaint = SKPaints.PaintMouseoverGroup;
                markerPaint.Color = Extensions.SKColorFromPaintColor("TeamHover");
            }
            else
            {
                markerPaint = player.GetEntityPaint();
            }

            var playerPoint = this.GetPoint();
            canvas.DrawCircle(playerPoint, 6 * UIScale, markerPaint);

            if (aimlineSettings.Enabled)
            {
                var alpha = ((byte)(player.IsKnocked || player.IsSkyDiving || player.IsRespawning ? 100 : aimlineSettings.Opacity));

                markerPaint.Color = markerPaint.Color.WithAlpha(alpha);

                canvas.DrawLine(playerPoint, this.GetAimlineEndpoint(radians, aimlineSettings.Length), markerPaint);
            }
        }

        /// <summary>
        /// Draws Player Text on this location.
        /// </summary>
        public void DrawPlayerText(SKCanvas canvas, Player player, string[] aboveLines, string[] belowLines, string[] rightLines, string[] leftLines, int? mouseoverGrp)
        {
            var type = player.Type.ToString();
            var text = Extensions.PlayerTypeTextPaints[type];
            var flagsText = Extensions.PlayerTypeFlagTextPaints[type];
            var textOutline = Extensions.GetTextOutlinePaint();

            if (mouseoverGrp is not null && mouseoverGrp == player.TeamID)
            {
                text = SKPaints.TextMouseoverGroup;
                text.Color = Extensions.SKColorFromPaintColor("TeamHover");
            }
            else
            {
                text.Color = Extensions.GetTextColor(player);
            }

            flagsText.Color = text.Color;

            textOutline.Typeface = text.Typeface;
            textOutline.TextSize = text.TextSize;

            var circleRadius = 6 * UIScale;
            var lineHeight = 12 * UIScale;
            var aboveOffset = circleRadius - 5 * UIScale;
            var belowOffset = circleRadius + 15 * UIScale;
            var sideOffset = circleRadius + 8 * UIScale;

            var aboveTextHeight = aboveLines.Length * lineHeight;

            for (int i = 0; i < aboveLines.Length; i++)
            {
                var bounds = new SKRect();
                text.MeasureText(aboveLines[i], ref bounds);
                var xOffset = -bounds.Width / 2;
                var yOffset = -aboveOffset - aboveTextHeight + (lineHeight * i);

                var coords = this.GetPoint(xOffset, yOffset);
                canvas.DrawText(aboveLines[i], coords, textOutline);
                canvas.DrawText(aboveLines[i], coords, text);
            }

            for (int i = 0; i < belowLines.Length; i++)
            {
                var bounds = new SKRect();
                text.MeasureText(belowLines[i], ref bounds);
                var xOffset = -bounds.Width / 2;
                var yOffset = belowOffset + (lineHeight * i);

                var coords = this.GetPoint(xOffset, yOffset);
                canvas.DrawText(belowLines[i], coords, textOutline);
                canvas.DrawText(belowLines[i], coords, text);
            }

            for (int i = 0; i < leftLines.Length; i++)
            {
                var bounds = new SKRect();
                text.MeasureText(leftLines[i], ref bounds);
                var xOffset = -sideOffset - bounds.Width;
                var yOffset = (lineHeight * i);
                var coords = this.GetPoint(xOffset, yOffset);
                canvas.DrawText(leftLines[i], coords, textOutline);
                canvas.DrawText(leftLines[i], coords, text);
            }

            textOutline.Typeface = flagsText.Typeface;
            textOutline.TextSize = flagsText.TextSize;

            for (int i = 0; i < rightLines.Length; i++)
            {
                var yOffset = (lineHeight * i);
                var coords = this.GetPoint(sideOffset, yOffset);
                canvas.DrawText(rightLines[i], coords, textOutline);
                canvas.DrawText(rightLines[i], coords, flagsText);
            }
        }

        /// <summary>
        /// Draws player tool tip based on if theyre alive or not
        /// </summary>
        public void DrawToolTip(SKCanvas canvas, Player player)
        {
            if (!player.IsActive || player.IsDead)
                return;

            DrawHostileTooltip(canvas, player);
        }

        /// <summary>
        /// Draws tool tip of hostile players 
        /// </summary>
        private void DrawHostileTooltip(SKCanvas canvas, Player player)
        {
            var lines = new List<string>();

            lines.Insert(0, $"{player.Name}");
            lines.Insert(0, $"Health: {player.Health}/{player.MaxHealth}");
            lines.Insert(0, $"Shield: {player.Shield}/{player.MaxShield}");
            lines.Insert(0, $"Shield level: {player.ShieldLevel}");
            lines.Insert(0, $"Yaw: {(player.IsLocalPlayer ? player.Rotation.X : player.Yaw)}");
            lines.Insert(0, $"Level: {player.Level}");
            lines.Insert(0, $"Weapon: {(player.HoldingGrenade ? "Grenade" : player.ActiveWeapon)}");
            lines.Insert(0, $"Legend: {player.Legend}");

            DrawToolTip(canvas, string.Join("\n", lines));
        }

        /// <summary>
        /// Draws the tool tip for players/hostiles
        /// </summary>
        private void DrawToolTip(SKCanvas canvas, string tooltipText)
        {
            var lines = tooltipText.Split('\n');
            var maxWidth = 0f;

            foreach (var line in lines)
            {
                var width = SKPaints.TextBase.MeasureText(line);
                maxWidth = Math.Max(maxWidth, width);
            }

            var textSpacing = 12 * UIScale;
            var padding = 3 * UIScale;

            var height = lines.Length * textSpacing;

            var left = X + padding;
            var top = Y - padding;
            var right = left + maxWidth + padding * 2;
            var bottom = top + height + padding * 2;

            var backgroundRect = new SKRect(left, top, right, bottom);
            canvas.DrawRect(backgroundRect, SKPaints.PaintTransparentBacker);

            var y = bottom - (padding * 1.5f);
            foreach (var line in lines)
            {
                canvas.DrawText(line, left + padding, y, SKPaints.TextBase);
                y -= textSpacing;
            }
        }
    }

    /// <summary>
    /// Defines a Map for use in the GUI.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Name of map (Ex: Customs)
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// 'MapConfig' class instance
        /// </summary>
        public readonly MapConfig ConfigFile;
        /// <summary>
        /// File path to Map .JSON Config
        /// </summary>
        public readonly string ConfigFilePath;

        public Map(string name, MapConfig config, string configPath, string mapID)
        {
            Name = name;
            ConfigFile = config;
            ConfigFilePath = configPath;
            MapID = mapID;
        }

        public readonly string MapID;
    }

    /// <summary>
    /// Contains multiple map parameters used by the GUI.
    /// </summary>
    public class MapParameters
    {
        /// <summary>
        /// Contains the Skia Interface (UI) Scaling Value.
        /// </summary>
        public float UIScale;
        /// <summary>
        /// Contains the 'index' of which map layer to display.
        /// For example: Labs has 3 floors, so there is a Bitmap image for 'each' floor.
        /// Index is dependent on LocalPlayer height.
        /// </summary>
        public int MapLayerIndex;
        /// <summary>
        /// Rectangular 'zoomed' bounds of the Bitmap to display.
        /// </summary>
        public SKRect Bounds;
        /// <summary>
        /// Regular -> Zoomed 'X' Scale correction.
        /// </summary>
        public float XScale;
        /// <summary>
        /// Regular -> Zoomed 'Y' Scale correction.
        /// </summary>
        public float YScale;
    }

    /// <summary>
    /// Defines a .JSON Map Config File
    /// </summary>
    public class MapConfig
    {
        [JsonIgnore]
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };

        [JsonPropertyName("mapID")]
        public List<string> MapID { get; set; } // New property for map IDs

        [JsonPropertyName("x")]
        public float X { get; set; }

        [JsonPropertyName("y")]
        public float Y { get; set; }

        [JsonPropertyName("scale")]
        public float Scale { get; set; }

        // Updated to match new JSON format
        [JsonPropertyName("mapLayers")]
        public List<MapLayer> MapLayers { get; set; }

        public static MapConfig LoadFromFile(string file)
        {
            var json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<MapConfig>(json, _jsonOptions);
        }

        public void Save(Map map)
        {
            var json = JsonSerializer.Serialize(this, _jsonOptions);
            File.WriteAllText(map.ConfigFilePath, json);
        }
    }

    public class MapLayer
    {
        [JsonPropertyName("minHeight")]
        public float MinHeight { get; set; }

        [JsonPropertyName("filename")]
        public string Filename { get; set; }
    }
}
