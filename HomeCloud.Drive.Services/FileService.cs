using HomeCloud.Drive.Core.Entities;
using HomeCloud.Drive.Services.Interfaces.Data;
using HomeCloud.Drive.Services.Interfaces.Files;
using HomeCloud.Drive.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Services
{
    public class FileService : IFileService
    {
        private readonly IFileDescriptorRepository _fileDescriptorRepository;
        private readonly IFileSystemRepository _fileSystemRepository;
        private readonly IDirectoryDescriptorRepository _directoryDescriptorRepository;

        public FileService(IFileDescriptorRepository fileDescriptorRepository, IFileSystemRepository fileSystemRepository, IDirectoryDescriptorRepository directoryDescriptorRepository)
        {
            _fileDescriptorRepository = fileDescriptorRepository;
            _fileSystemRepository = fileSystemRepository;
            _directoryDescriptorRepository = directoryDescriptorRepository;
        }

        public IEnumerable<FileDescriptor> GetFileDescryptors(int? directoryDescriptorId)
        {
            return _fileDescriptorRepository
                .GetFileDescriptors(directoryDescriptorId);
        }

        public async Task<FileWithDataModel> GetFileAsync(int fileDescriptorId)
        {
            var fileDescriptor = await _fileDescriptorRepository.GetFileDescriptorAsync(fileDescriptorId);
            if (fileDescriptor == null)
            {
                return null;
            }

            return new FileWithDataModel(fileDescriptor.Name, fileDescriptor.DirectoryDescriptorId,
                _fileSystemRepository.GetFileStream(fileDescriptor.Path), fileDescriptor.ContentType);
        }

        public async Task<FileDescriptor> AddFile(FileWithDataModel fileForData)
        {
            if (fileForData == null)
            {
                throw new ArgumentNullException(nameof(fileForData));
            }

            string path;
            if (fileForData.DirectoryDescryptorId.HasValue)
            {
                var directoryDescryptor = await _directoryDescriptorRepository.GetDirectoryDescriptor((int)fileForData.DirectoryDescryptorId);
                if (directoryDescryptor == null)
                {
                    throw new Exception(nameof(directoryDescryptor));
                }

                path = Path.Combine(directoryDescryptor.Path, fileForData.FileName);
            }
            else
            {
                path = fileForData.FileName;
            }

            await _fileSystemRepository.CreateFile(path, fileForData.Stream);

            var fileDescryptor = new FileDescriptor()
            {
                DirectoryDescriptorId = fileForData.DirectoryDescryptorId.HasValue ? fileForData.DirectoryDescryptorId : null,
                Name = fileForData.FileName,
                Path = path,
                Extension = Path.GetExtension(path),
                ContentType = fileForData.ContentType
            };
            await _fileDescriptorRepository.AddFileDescryptorAsync(fileDescryptor);

            return fileDescryptor;
        }

        public async Task DeleteFile(int fileDescryptorId)
        {
            if (fileDescryptorId <= 0)
            {
                throw new ArgumentException(nameof(fileDescryptorId));
            }

            var fileDescryptor = await _fileDescriptorRepository.GetFileDescriptorAsync(fileDescryptorId);
            if (fileDescryptor == null)
            {
                throw new Exception(nameof(fileDescryptor));
            }

            _fileSystemRepository.DeleteFileOrDirectory(fileDescryptor.Path);
            await _fileDescriptorRepository.DeleteFileDescryptorAsync(fileDescryptor);
        }
    }
}
