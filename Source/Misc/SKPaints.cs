using SkiaSharp;

namespace apex_dma_radar
{
    internal static class SKPaints
    {
        #region Radar Paints
        public static readonly SKPaint PaintBase = new SKPaint() {
            Color = SKColors.WhiteSmoke,
            StrokeWidth = 3,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            FilterQuality = SKFilterQuality.High
        };

        public static readonly SKPaint TextBase = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.WhiteSmoke,
            TextSize = 13,
            TextEncoding = SKTextEncoding.Utf8,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial"),
            FilterQuality = SKFilterQuality.High
        };

        public static readonly SKPaint TextBaseOutline = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 2,
            TextSize = 13,
            TextEncoding = SKTextEncoding.Utf8,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial"),
            FilterQuality = SKFilterQuality.High
        };

        public static readonly SKPaint PaintMouseoverGroup = new SKPaint()
        {
            Color = SKColors.LawnGreen,
            StrokeWidth = 3,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            FilterQuality = SKFilterQuality.High
        };

        public static readonly SKPaint TextMouseoverGroup = new SKPaint()
        {
            Color = SKColors.LawnGreen,
            IsStroke = false,
            TextSize = 12,
            TextEncoding = SKTextEncoding.Utf8,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold),
            FilterQuality = SKFilterQuality.High
        };
        #endregion

        #region Render/Misc Paints
        public static readonly SKPaint PaintBitmap = new SKPaint()
        {
            IsAntialias = true,
            FilterQuality = SKFilterQuality.High
        };

        public static readonly SKPaint TextRadarStatus = new SKPaint()
        {
            Color = SKColors.Red,
            IsStroke = false,
            TextSize = 48,
            TextEncoding = SKTextEncoding.Utf8,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold),
            TextAlign = SKTextAlign.Center
        };

        public static readonly SKPaint PaintTransparentBacker = new SKPaint()
        {
            Color = SKColors.Black.WithAlpha(0xBE), // Transparent backer
            StrokeWidth = 1,
            Style = SKPaintStyle.Fill,
        };
        #endregion
    }

    public class PaintColor {
        public Colors Color { get; set; }
        public string Name { get; set; }

        public struct Colors {
            public byte A { get; set; }
            public byte R { get; set; }
            public byte G { get; set; }
            public byte B { get; set; }
        }
    }
}
