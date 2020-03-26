using System;
using System.Drawing;
using System.IO;

namespace Nexul.Demo.Files
{
    public interface IImageResizer
    {
        Image ImageFromByteArray(byte[] rawBytes);
        Image Resize(Image imgToResize, Size size);

        /// <summary>
        /// Copies an image to a byte array.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fileExtension">The extension of the file.</param>
        byte[] ConvertImageToArray(Image img, string fileExtension);

        /// <summary>
        /// Copies the contents of one stream to another.
        /// </summary>
        void Copy(Stream source, Stream target);

        /// <summary>
        /// Formats a file size into the relevant largest unit.
        /// </summary>
        string FormatSize(Int64 sizeBytes);
    }
}
