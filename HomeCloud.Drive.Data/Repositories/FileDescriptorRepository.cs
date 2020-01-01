using HomeCloud.Drive.Core.Entities;
using HomeCloud.Drive.Services.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCloud.Drive.Data.Repositories
{
    public class FileDescriptorRepository : IFileDescriptorRepository
    {
        private readonly DriveDbContext _driveDbContext;

        public FileDescriptorRepository(DriveDbContext driveDbContext)
        {
            _driveDbContext = driveDbContext;
        }

        public IEnumerable<FileDescriptor> GetFileDescriptors(int? directoryDescriptorId)
        {
            return _driveDbContext
                .FileDescriptors
                .Where(x => x.DirectoryDescriptorId == directoryDescriptorId);
        }

        public async Task<FileDescriptor> GetFileDescriptorAsync(int fileDescriptorId)
        {
            return await _driveDbContext
                .FileDescriptors
                .FirstOrDefaultAsync(x => x.Id == fileDescriptorId);
        }

        public async Task AddFileDescryptorAsync(FileDescriptor fileDescriptor)
        {
            if (fileDescriptor == null)
            {
                throw new ArgumentNullException(nameof(fileDescriptor));
            }

            await _driveDbContext.FileDescriptors.AddAsync(fileDescriptor);
            await _driveDbContext.SaveChangesAsync();
        }

        public async Task DeleteFileDescryptorAsync(FileDescriptor fileDescriptor)
        {
            if (fileDescriptor == null)
            {
                throw new ArgumentNullException(nameof(fileDescriptor));
            }

            _driveDbContext.FileDescriptors.Remove(fileDescriptor);
            await _driveDbContext.SaveChangesAsync();
        }
    }
}
