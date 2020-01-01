using HomeCloud.Drive.Data.Repositories;
using HomeCloud.Drive.Services.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Data
{
    public static class ContextRegistrator
    {
        public static IServiceCollection RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<DriveDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("testConnection"));
                x.UseLazyLoadingProxies();
            });

            return services;
        }

        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IFileDescriptorRepository, FileDescriptorRepository>();
            services.AddTransient<IDirectoryDescriptorRepository, DirectoryDescriptorRepository>();

            return services;
        }
    }
}
