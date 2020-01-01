using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCloud.Drive.ViewModels
{
    public class DirectoryDescryptorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDirectoryDescryptorId { get; set; }
    }
}
