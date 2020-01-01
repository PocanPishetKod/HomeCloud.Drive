using HomeCloud.Drive.Data;
using HomeCloud.Drive.Data.Repositories;
using HomeCloud.Drive.Services;
using HomeCloud.Drive.Services.Interfaces.Data;
using HomeCloud.Drive.Services.Interfaces.Files;
using HomeCloud.Drive.Services.FileRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.DIRegistrator
{
    public static class Registrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            ContextRegistrator.RegisterDbContext(services, configuration);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            ServicesRegistrator.RegisterServices(services);
            ContextRegistrator.RegisterRepositories(services);
            return services;
        }
    }
}
