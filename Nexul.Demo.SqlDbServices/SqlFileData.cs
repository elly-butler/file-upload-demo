using Nexul.Demo.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexul.Demo.SqlDbServices
{
    public class SqlFileData : IFileData
    {
        public File GetFile(string fileId)
        {
            throw new NotImplementedException();
        }

        public FileMetadata GetFileMetadata(string fileId)
        {
            throw new NotImplementedException();
        }

        public List<FileMetadata> GetUserFiles(string userId, string skipPastId = null, int take = 50)
        {
            throw new NotImplementedException();
        }

        public void InsertFile(File item)
        {
            throw new NotImplementedException();
        }

        public void UpdateFile(File updated, File existing)
        {
            throw new NotImplementedException();
        }
        public void Delete(FileMetadata metadata)
        {
            throw new NotImplementedException();
        }
    }
}
