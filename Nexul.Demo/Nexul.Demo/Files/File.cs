namespace Nexul.Demo.Files
{
    public class File
    {
        /// <summary>
        /// Basic properties of the uploaded file.
        /// </summary>
        public FileMetadata Metadata { get; set; }

        public byte[] FileBlob { get; set; }
    }
}
