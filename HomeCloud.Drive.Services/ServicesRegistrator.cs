using HomeCloud.Drive.Services.FileRepository;
using HomeCloud.Drive.Services.Interfaces.Files;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IDirectoryService, DirectoryService>();
            services.AddTransient<IFileSystemRepository, FileSystemService>();

            return services;
        }
    }
}
