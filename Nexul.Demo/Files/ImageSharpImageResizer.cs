using System;
using System.Drawing;
using System.IO;

namespace Nexul.Demo.Files
{
    /// <summary>
    /// resizes images with cross platform ImageSharp library.
    /// https://github.com/SixLabors/ImageSharp?WT.mc_id=-blog-scottha
    /// </summary>
    public class ImageSharpImageResizer : IImageResizer
    {   //TODO: implement this resizer.
        public byte[] ConvertImageToArray(Image img, string fileExtension)
        {
            throw new NotImplementedException();
        }

        public void Copy(Stream source, Stream target)
        {
            throw new NotImplementedException();
        }

        public string FormatSize(long sizeBytes)
        {
            throw new NotImplementedException();
        }

        public Image ImageFromByteArray(byte[] rawBytes)
        {
            throw new NotImplementedException();
        }

        public Image Resize(Image imgToResize, Size size)
        {
            throw new NotImplementedException();
        }
    }
}
