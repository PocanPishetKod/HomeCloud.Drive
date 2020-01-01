using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCloud.Drive.ViewModels
{
    public class FileViewModel
    {
        public IFormFile File { get; set; }
        public int? DirectoryDescryptorId { get; set; }
    }
}
