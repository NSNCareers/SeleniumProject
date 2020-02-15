using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace CoreFramework.Config
{
    public static class JsonConfig
    {
        private static IConfiguration _configuration { get; set; }

       public static string GetJsonValue(string key)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appConfig.json").Build();

            string value = builder[key];

            return value;
        }
    }
}
