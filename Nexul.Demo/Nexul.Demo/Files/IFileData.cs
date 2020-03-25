using System;
using System.Collections.Generic;

namespace Nexul.Demo.Files
{
    public interface IFileData
    {
        /// <summary>
        /// Gets a single file metadata and blob data by identity.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        File GetFile(String fileId);

        /// <summary>
        /// Gets a single file's metadata only.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        FileMetadata GetFileMetadata(String fileId);

        /// <summary>
        /// Gets all files uploaded by a user.
        /// </summary>
        /// <param name="userId">The uploading user identity.</param>
        /// <param name="skipPastId">In paging scenarios, pick the file id to skip past.</param>
        /// <param name="take">The maximum number of items to get.</param>
        /// <returns></returns>
        List<FileMetadata> GetUserFiles(String userId, String skipPastId = null, int take = 50);
        
        /// <summary>
        /// uploads a new file and associated metadata.
        /// </summary>
        /// <param name="item"></param>
        /// 
        void InsertFile(File item);

        /// <summary>
        /// Updates a file, such as with a new owner (from anonymous to the newly logged in or registered user)
        /// </summary>
        /// <param name="updated"></param>
        /// <param name="existing"></param>
        void UpdateFile(File updated, File existing);

        void Delete(FileMetadata metadata);
    }
}
