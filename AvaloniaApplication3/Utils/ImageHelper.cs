using System;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaApplication3.Utils
{
    public static class ImageHelper
    {
        /// <summary>
        /// 加载普通图片（如预览图、大图等）
        /// </summary>
        /// <param name="relativePath">资源路径，如 Assets/Images/bg.png</param>
        public static Bitmap? LoadImage(string relativePath)
        {
            return LoadBitmap(relativePath);
        }

        /// <summary>
        /// 加载图标资源（建议小图标或控件按钮图标）
        /// </summary>
        /// <param name="relativePath">资源路径，如 Assets/Icons/close.png</param>
        /// <param name="targetSize">可选缩放大小，用于手动缩小图标</param>
        public static Bitmap? LoadIcon(string relativePath, Size? targetSize = null)
        {
            var bitmap = LoadBitmap(relativePath);

            if (bitmap != null && targetSize.HasValue)
            {
                var pixelSize = new PixelSize((int)targetSize.Value.Width, (int)targetSize.Value.Height);
                return bitmap.CreateScaledBitmap(pixelSize, BitmapInterpolationMode.HighQuality);
            }

            return bitmap;
        }


        /// <summary>
        /// 核心加载函数，统一处理 avares:// 资源
        /// </summary>
        private static Bitmap? LoadBitmap(string relativePath)
        {
            try
            {
                var uri = new Uri($"avares://AvaloniaApplication3/{relativePath}");
                using var stream = AssetLoader.Open(uri);
                return new Bitmap(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ImageHelper] 加载图片失败: {relativePath}, 错误: {ex.Message}");
                return null;
            }
        }
    }
}