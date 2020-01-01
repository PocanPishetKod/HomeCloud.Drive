using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCloud.Drive.Services.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static string GetBasePath(this IConfiguration configuration)
        {
            return configuration.GetSection("FileRepositoryPath").Value;
        }
    }
}
