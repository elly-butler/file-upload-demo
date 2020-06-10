using System;

namespace Nexul.Demo.Files
{
    public class FileImageAlternate
    {
        public Guid FileImageAlternateId { get; set; }
        public Guid FileId { get; set; }
        public FileImageAlternateMetadata Metadata { get; set; }
        public byte[] FileBlob { get; set; }
    }
}
