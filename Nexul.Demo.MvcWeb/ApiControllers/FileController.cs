using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexul.Demo.Files;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexul.Demo.MvcWeb.ApiControllers
{
    /// <summary>
    /// Allows download of file metadata, file content, and uploading files.
    /// </summary>
    [Route("api/file")]
    public class FileController : Controller
    {
        private readonly IFileData _fileData;

        public FileController(IFileData fileData)
        {
            _fileData = fileData;
        }
        //TODO: add retrieval action methods here.

        [HttpPost("upload")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> model)
        { 
            // see other considerations and solutions in the docs:
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1
            long size = model.Sum(f => f.Length);
            
            var files = new List<File>();
            foreach (var formFile in model)
            {
                if (formFile.Length > 0)
                {
                    byte[] content;
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        content = memoryStream.ToArray();
                    }
                    var filename = formFile.FileName;
                    files.Add(new File
                    {
                        FileBlob = content,
                        Metadata = new FileMetadata
                        {
                            ContentType = formFile.ContentType,
                            Extension = System.IO.Path.GetExtension(filename),
                            Size = content.LongLength,
                            FileType = FileType.Image, // TODO: set based on file extension
                            //UserId = Add identity to project to get user id
                        }
                    });
                }
            }

            files.ForEach(f => _fileData.InsertFile(f));
            return Ok(files.Select(x => x.Metadata));
        }
    }
}
