using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CoreFramework.Config
{
    public static class JsonConfig
    {
        private static IConfiguration _configuration { get; set; }

       public static string GetJsonValue(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appConfig.json", optional: false, reloadOnChange: true)
                .AddJsonFile("hubConfig.json", optional: false, reloadOnChange: true)
                .AddJsonFile("nodeConfig.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            return _configuration[key];
        }
    }
}
