using HomeCloud.Drive.Core.Entities;
using HomeCloud.Drive.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services
{
    public interface IDirectoryService
    {
        public IEnumerable<DirectoryDescriptor> GetDirectories(int? parentDirectoryDescryptorId);
        public Task<DirectoryDescriptor> AddDirectory(DirectoryModel directoryModel);
        public Task RenameDirectory(int directoryDescryptorId, string newName);
        public Task DeleteDirectory(int directoryDescryptorId);
    }
}
