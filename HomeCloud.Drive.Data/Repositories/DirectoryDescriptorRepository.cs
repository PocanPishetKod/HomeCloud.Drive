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
    public class DirectoryDescriptorRepository : IDirectoryDescriptorRepository
    {
        private readonly DriveDbContext _driveDbContext;

        public DirectoryDescriptorRepository(DriveDbContext driveDbContext)
        {
            _driveDbContext = driveDbContext;
        }

        public async Task AddDirectoryDescryptor(DirectoryDescriptor directoryDescriptor)
        {
            if (directoryDescriptor == null)
            {
                throw new ArgumentNullException(nameof(directoryDescriptor));
            }

            await _driveDbContext.AddAsync(directoryDescriptor);
            await _driveDbContext.SaveChangesAsync();
        }

        public async Task DeleteDirectoryDescryptor(int directoryDescryptorId)
        {
            if (directoryDescryptorId <= 0)
            {
                throw new ArgumentException(nameof(directoryDescryptorId));
            }

            var directoryDescryptor = await GetDirectoryDescriptor(directoryDescryptorId);
            if (directoryDescryptor == null)
            {
                throw new ArgumentException(nameof(directoryDescryptorId));
            }

            await DeleteDirectoryDescryptor(directoryDescryptor);
        }

        public async Task DeleteDirectoryDescryptor(DirectoryDescriptor directoryDescriptor)
        {
            if (directoryDescriptor == null)
            {
                throw new ArgumentNullException(nameof(directoryDescriptor));
            }

            _driveDbContext.DirectoryDescriptors.Remove(directoryDescriptor);
            await _driveDbContext.SaveChangesAsync();
        }

        public async Task<bool> DirectoryDescryptorExists(string directoryName)
        {
            if (string.IsNullOrWhiteSpace(directoryName))
            {
                throw new ArgumentException(nameof(directoryName));
            }

            directoryName = directoryName.Trim().ToUpper();

            return await _driveDbContext
                .DirectoryDescriptors
                .AnyAsync(x => x.Name.ToUpper() == directoryName);
        }

        public async Task<bool> DirectoryDescryptorExists(string directoryName, int parentDirectoryDescryptorId)
        {
            directoryName = directoryName.Trim().ToUpper();

            return await _driveDbContext
                .DirectoryDescriptors
                .AnyAsync(x => x.ParentDirectoryDescryptorId == parentDirectoryDescryptorId && x.Name.ToUpper() == directoryName);
        }

        public async Task<DirectoryDescriptor> GetDirectoryDescriptor(int directoryDescryptorId)
        {
            return await _driveDbContext
                .DirectoryDescriptors
                .FirstOrDefaultAsync(x => x.Id == directoryDescryptorId);
        }

        public IEnumerable<DirectoryDescriptor> GetDirectoryDescriptors(int? parentDirectoryDescryptorId)
        {
            return _driveDbContext
                .DirectoryDescriptors
                .Where(x => x.ParentDirectoryDescryptorId == parentDirectoryDescryptorId);
        }

        public async Task UpdateDirectoryDescryptor(DirectoryDescriptor directoryDescriptor)
        {
            if (directoryDescriptor == null)
            {
                throw new ArgumentNullException(nameof(directoryDescriptor));
            }

            _driveDbContext.Update(directoryDescriptor);
            await _driveDbContext.SaveChangesAsync();
        }
    }
}
