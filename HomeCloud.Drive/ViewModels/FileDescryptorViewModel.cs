using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCloud.Drive.ViewModels
{
    public class FileDescryptorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DirectoryDescryptorId { get; set; }
    }
}
