using Microsoft.AspNetCore.Mvc;
using Nexul.Demo.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexul.Demo.MvcWeb.ApiControllers
{
    /// <summary>
    /// Allows download of file metadata, file content, and uploading files.
    /// </summary>
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly IFileData _fileData;

        public FileController(IFileData fileData)
        {
            _fileData = fileData;
        }
        //TODO: add action methods here.
    }
}
