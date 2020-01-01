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
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryDescriptorRepository _directoryDescriptorRepository;
        private readonly IFileSystemRepository _fileSystemRepository;

        public DirectoryService(IDirectoryDescriptorRepository directoryDescriptorRepository, IFileSystemRepository fileSystemRepository)
        {
            _directoryDescriptorRepository = directoryDescriptorRepository;
            _fileSystemRepository = fileSystemRepository;
        }

        private async Task<DirectoryDescriptor> AddDirectoryWithParent(DirectoryModel directoryModel)
        {
            var parentDirectoryDescryptor = await _directoryDescriptorRepository
                    .GetDirectoryDescriptor((int)directoryModel.ParentDirectoryDescryptorId);

            if (parentDirectoryDescryptor == null)
            {
                throw new Exception();
            }

            var path = Path.Combine(parentDirectoryDescryptor.Path, directoryModel.Name);

            _fileSystemRepository.CreateDirectory(path);

            var directoryDescryptor = new DirectoryDescriptor()
            {
                ParentDirectoryDescryptorId = directoryModel.ParentDirectoryDescryptorId,
                Name = directoryModel.Name,
                Path = path
            };
            await _directoryDescriptorRepository.AddDirectoryDescryptor(directoryDescryptor);

            return directoryDescryptor;
        }

        private async Task<DirectoryDescriptor> AddDirectoryWithoutParent(DirectoryModel directoryModel)
        {
            var path = directoryModel.Name;
            _fileSystemRepository.CreateDirectory(path);

            var directoryDescryptor = new DirectoryDescriptor()
            {
                Name = directoryModel.Name,
                Path = path
            };
            await _directoryDescriptorRepository.AddDirectoryDescryptor(directoryDescryptor);

            return directoryDescryptor;
        }

        public async Task<DirectoryDescriptor> AddDirectory(DirectoryModel directoryModel)
        {
            if (directoryModel == null)
            {
                throw new ArgumentNullException(nameof(directoryModel));
            }

            bool directoryExists;
            if (!directoryModel.ParentDirectoryDescryptorId.HasValue)
            {
                directoryExists = await _directoryDescriptorRepository
                    .DirectoryDescryptorExists(directoryModel.Name);
            }
            else
            {
                directoryExists = await _directoryDescriptorRepository
                    .DirectoryDescryptorExists(directoryModel.Name, (int)directoryModel.ParentDirectoryDescryptorId);
            }

            if (directoryExists)
            {
                throw new Exception();
            }

            DirectoryDescriptor directoryDescriptor;
            if (directoryModel.ParentDirectoryDescryptorId.HasValue)
            {
                directoryDescriptor = await AddDirectoryWithParent(directoryModel);
            }
            else
            {
                directoryDescriptor = await AddDirectoryWithoutParent(directoryModel);
            }

            return directoryDescriptor;
        }

        public async Task DeleteDirectory(int directoryDescryptorId)
        {
            if (directoryDescryptorId <= 0)
            {
                throw new ArgumentException(nameof(directoryDescryptorId));
            }

            var directoryDescryptor = await _directoryDescriptorRepository
                .GetDirectoryDescriptor(directoryDescryptorId);

            if (directoryDescryptor == null)
            {
                throw new Exception();
            }

            _fileSystemRepository.DeleteFileOrDirectory(directoryDescryptor.Path);
            await _directoryDescriptorRepository.DeleteDirectoryDescryptor(directoryDescryptor);
        }

        public IEnumerable<DirectoryDescriptor> GetDirectories(int? parentDirectoryDescryptorId)
        {
            return _directoryDescriptorRepository
                .GetDirectoryDescriptors(parentDirectoryDescryptorId);
        }

        public async Task RenameDirectory(int directoryDescryptorId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
