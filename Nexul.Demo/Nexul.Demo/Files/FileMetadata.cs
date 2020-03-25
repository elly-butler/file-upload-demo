using System;
using System.ComponentModel.DataAnnotations;

namespace Nexul.Demo.Files
{
    /// <summary>
    /// Basic attributes about a file and who originally uploaded it.
    /// </summary>
    public class FileMetadata
    {
        /// <summary>
        /// Unique system identity of this file.
        /// </summary>
        [Key]
        public Guid FileId { get; set; }

        /// <summary>
        /// The size in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The basic type of file.  See ContentType for specifics.
        /// </summary>
        public FileType FileType { get; set; }

        /// <summary>
        /// The file extension.
        /// </summary>
        [MaxLength(25)]
        public string Extension { get; set; }

        /// <summary>
        /// The content type used for streaming the file to a client.
        /// </summary>
        [MaxLength(225)]
        public string ContentType { get; set; }

        /// <summary>
        /// The identity of the user that uploaded the file.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The date and time when the file was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; }

        public FileMetadata()
        {
        }

        public FileMetadata(FileMetadata source)
        {
            FileId = source.FileId;
            Size = source.Size;
            FileType = source.FileType;
            Extension = source.Extension;
            ContentType = source.ContentType;
            UserId = source.UserId;
            UploadDate = source.UploadDate;
        }
    }
}