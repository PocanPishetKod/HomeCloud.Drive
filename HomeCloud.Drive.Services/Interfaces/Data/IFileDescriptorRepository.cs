using HomeCloud.Drive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services.Interfaces.Data
{
    public interface IFileDescriptorRepository
    {
        IEnumerable<FileDescriptor> GetFileDescriptors(int? directoryDescriptorId);
        Task<FileDescriptor> GetFileDescriptorAsync(int fileDescriptorId);
        Task AddFileDescryptorAsync(FileDescriptor fileDescriptor);
        Task DeleteFileDescryptorAsync(FileDescriptor fileDescriptor);
    }
}
