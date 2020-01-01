using HomeCloud.Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services.Interfaces.Data
{
    public interface IDirectoryDescriptorRepository
    {
        IEnumerable<DirectoryDescriptor> GetDirectoryDescriptors(int? parentDirectoryDescryptorId);
        Task<DirectoryDescriptor> GetDirectoryDescriptor(int directoryDescryptorId);
        Task AddDirectoryDescryptor(DirectoryDescriptor directoryDescriptor);
        Task UpdateDirectoryDescryptor(DirectoryDescriptor directoryDescriptor);
        Task DeleteDirectoryDescryptor(int directoryDescryptorId);
        Task DeleteDirectoryDescryptor(DirectoryDescriptor directoryDescriptor);
        Task<bool> DirectoryDescryptorExists(string directoryName);
        Task<bool> DirectoryDescryptorExists(string directoryName, int parentDirectoryDescryptorId);
    }
}
