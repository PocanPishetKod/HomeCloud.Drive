using HomeCloud.Drive.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Data
{
    public class DriveDbContext : DbContext
    {
        public DriveDbContext(DbContextOptions<DriveDbContext> options) : base(options) { }

        public DbSet<DirectoryDescriptor> DirectoryDescriptors { get; set; }
        public DbSet<FileDescriptor> FileDescriptors { get; set; }
    }
}
