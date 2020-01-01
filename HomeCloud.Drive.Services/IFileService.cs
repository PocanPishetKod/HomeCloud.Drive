using HomeCloud.Drive.Core.Entities;
using HomeCloud.Drive.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services
{
    public interface IFileService
    {
        IEnumerable<FileDescriptor> GetFileDescryptors(int? directoryDescriptorId);
        Task<FileWithDataModel> GetFileAsync(int fileDescriptorId);
        Task<FileDescriptor> AddFile(FileWithDataModel fileForData);
        Task DeleteFile(int fileDescryptorId);
    }
}
