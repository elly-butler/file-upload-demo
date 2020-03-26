using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Nexul.Demo.Files
{
    /// <summary>
    /// A compatibility layer to resize images, runs on Windows and Linux.
    /// </summary>
    public class CompatImageResizer : IImageResizer
    {
        public Image ImageFromByteArray(byte[] rawBytes)
        {
            if (rawBytes == null || rawBytes.Length == 0)
                return null;
            using (var contentStream = new MemoryStream(rawBytes))
            {
                return Image.FromStream(contentStream);
            }
        }
        public Image Resize(Image imgToResize, Size size)
        {   //http://www.switchonthecode.com/tutorials/csharp-tutorial-image-editing-saving-cropping-and-resizing
            var sourceWidth = imgToResize.Width;
            var sourceHeight = imgToResize.Height;

            // ReSharper disable RedundantCast
            var nPercentW = ((float)size.Width / (float)sourceWidth);
            var nPercentH = ((float)size.Height / (float)sourceHeight);
            // ReSharper restore RedundantCast
            var nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var b = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
        /// <summary>
        /// Copies an image to a byte array.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fileExtension">The extension of the file.</param>
        /// <returns></returns>
        public byte[] ConvertImageToArray(Image img, String fileExtension)
        {
            var format = System.Drawing.Imaging.ImageFormat.Jpeg;
            var ext = fileExtension.ToLower().Replace(".", "");
            if (ext.Contains("jpg") || ext.Contains("jpeg"))
                format = System.Drawing.Imaging.ImageFormat.Jpeg;
            else if (ext.Contains("png"))
                format = System.Drawing.Imaging.ImageFormat.Png;
            else if (ext.Contains("gif"))
                format = System.Drawing.Imaging.ImageFormat.Gif;
            else if (ext.Contains("bmp"))
                format = System.Drawing.Imaging.ImageFormat.Bmp;
            else if (ext.Contains("ico"))
                format = System.Drawing.Imaging.ImageFormat.Icon;
            else if (ext.Contains("tif"))
                format = System.Drawing.Imaging.ImageFormat.Tiff;
            else if (ext.Contains("wmf"))
                format = System.Drawing.Imaging.ImageFormat.Wmf;
            else if (ext.Contains("emf"))
                format = System.Drawing.Imaging.ImageFormat.Emf;

            using (var ms = new MemoryStream())
            {
                img.Save(ms, format);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Copies the contents of one stream to another.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Copy(Stream source, Stream target)
        {
            var buffer = new byte[0x10000];
            try
            {
                int bytes;
                while ((bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    target.Write(buffer, 0, bytes);
                }
            }
            finally
            {
                target.Flush();
            }
        }

        /// <summary>
        /// Formats a file size into the relevant largest unit.
        /// </summary>
        /// <param name="sizeBytes"></param>
        /// <returns></returns>
        public string FormatSize(Int64 sizeBytes)
        {
            if (sizeBytes <= 0)
                return "";
            if (sizeBytes > 1024 * 1024 * 1024)
                return string.Format("{0}GB", sizeBytes / (1024 * 1024 * 1024));
            if (sizeBytes > 1024 * 1024)
                return string.Format("{0}MB", sizeBytes / (1024 * 1024));
            if (sizeBytes > 1024)
                return string.Format("{0}KB", sizeBytes / 1024);
            return string.Format("{0}B", sizeBytes);
        }
    }
}
