using System;
using System.ComponentModel.DataAnnotations;

namespace Nexul.Demo.Files
{
    public class File
    {
        [Key]
        public Guid FileId { get; set; }
        /// <summary>
        /// Basic properties of the uploaded file.
        /// </summary>
        public FileMetadata Metadata { get; set; }

        public byte[] FileBlob { get; set; }
    }
}
