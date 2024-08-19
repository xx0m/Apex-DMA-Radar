using SkiaSharp;

namespace apex_dma_radar
{
    /// <summary>
    /// Extension methods go here.
    /// </summary>
    public static class Extensions
    {
        #region Generic Extensions
        /// <summary>
        /// Restarts a timer from 0. (Timer will be started if not already running)
        /// </summary>
        public static void Restart(this System.Timers.Timer t)
        {
            t.Stop();
            t.Start();
        }

        /// <summary>
        /// Converts 'Degrees' to 'Radians'.
        /// </summary>
        public static double ToRadians(this float degrees)
        {
            return (Math.PI / 180) * degrees;
        }
        /// <summary>
        /// Converts 'Radians' to 'Degrees'.
        /// </summary>
        public static double ToDegrees(this float radians)
        {
            return (180 / Math.PI) * radians;
        }
        /// <summary>
        /// Converts 'Degrees' to 'Radians'.
        /// </summary>
        public static double ToRadians(this double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
        /// <summary>
        /// Converts 'Radians' to 'Degrees'.
        /// </summary>
        public static double ToDegrees(this double radians)
        {
            return (180 / Math.PI) * radians;
        }

        public static double ToMeters(this double gameUnits)
        {
            return (gameUnits / 39.37007874);
        }

        public static float ToMeters(this float gameUnits)
        {
            return (float)(gameUnits / 39.37007874);
        }
        #endregion

        #region GUI Extensions
        public static Dictionary<string, SKPaint> PlayerTypeTextPaints = new Dictionary<string, SKPaint>();
        public static Dictionary<string, SKPaint> PlayerTypeFlagTextPaints = new Dictionary<string, SKPaint>();
        public static Dictionary<string, SKColor> SKColors = new Dictionary<string, SKColor>();
        private static Config _config = Program.Config;

        /// <summary>
        /// Convert game position to 'Bitmap' Map Position coordinates.
        /// </summary>
        public static MapPosition ToMapPos(this System.Numerics.Vector3 vector, Map map)
        {
            return new MapPosition()
            {
                X = map.ConfigFile.X + (vector.X * map.ConfigFile.Scale),
                Y = map.ConfigFile.Y - (vector.Y * map.ConfigFile.Scale), // Invert 'Y' unity 0,0 bottom left, C# top left
                Height = vector.Z // Keep as float, calculation done later
            };
        }

        /// <summary>
        /// Gets 'Zoomed' map position coordinates.
        /// </summary>
        public static MapPosition ToZoomedPos(this MapPosition location, MapParameters mapParams)
        {
            return new MapPosition()
            {
                UIScale = mapParams.UIScale,
                X = (location.X - mapParams.Bounds.Left) * mapParams.XScale,
                Y = (location.Y - mapParams.Bounds.Top) * mapParams.YScale,
                Height = location.Height
            };
        }

        /// <summary>
        /// Ghetto helper method to get the Color from a PaintColor object by Key & return a new SKColor object based on it
        /// </summary>
        public static SKColor SKColorFromPaintColor(string key, byte alpha = 0)
        {
            var col = Extensions.SKColors[key];

            if (alpha > 0)
                col = col.WithAlpha(alpha);

            return col;
        }

        /// <summary>
        /// Gets drawing paintbrush based on Player Type
        /// </summary>
        public static SKPaint GetEntityPaint(this Player player)
        {
            SKPaint basePaint = SKPaints.PaintBase.Clone();
            var alpha = (byte)(player.IsSkyDiving || player.IsRespawning || player.IsKnocked ? 100 : 255);
            SKColor col;

            if (player.IsLocalPlayer)
                col = SKColorFromPaintColor("LocalPlayer");
            else if (player.IsTeammate)
                col = SKColorFromPaintColor("Teammate");
            else if (Memory.Level.IsSquadBased)
                col = SKColorFromPaintColor("MixtapeEnemy");
            else if (player.IsLastAliveInSquad && _config.HighlightLastAlive)
                col = SKColorFromPaintColor("LastAlive");
            else
                col = TeamManager.GetTeamColor(player.TeamID);

            basePaint.Color = col.WithAlpha(alpha);

            return basePaint;
        }

        /// <summary>
        /// Gets color of text based on Player Type
        /// </summary>
        public static SKColor GetTextColor(Player player)
        {
            var alpha = (byte)(player.IsSkyDiving || player.IsRespawning || player.IsKnocked ? 155 : 255);
            SKColor col;

            if (player.IsLocalPlayer)
                col = SKColorFromPaintColor("LocalPlayer");
            else if (player.IsTeammate)
                col = SKColorFromPaintColor("Teammate");
            else if (Memory.Level.IsSquadBased)
                col = SKColorFromPaintColor("MixtapeEnemy");
            else if (player.IsLastAliveInSquad && _config.HighlightLastAlive)
                col = SKColorFromPaintColor("LastAlive");
            else
                col = TeamManager.GetTeamColor(player.TeamID);

            return col.WithAlpha(alpha);
        }

        /// <summary>
        /// Determines the text outline color.
        /// </summary>
        public static SKPaint GetTextOutlinePaint()
        {
            SKPaint paintToUse = SKPaints.TextBaseOutline.Clone();
            paintToUse.Color = Extensions.SKColorFromPaintColor("TextOutline");
            return paintToUse;
        }
        #endregion
    }
}
