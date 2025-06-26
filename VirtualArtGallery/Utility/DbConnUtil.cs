using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace VirtualArtGallery.Utility
{
    static class DbConnUtil
    {
        private static IConfiguration _configuration;
        //static class will have static constructor only and everything in it will be static
        static DbConnUtil()
        {
            GetAppSettingsFile();
            
        }
        private static void GetAppSettingsFile() {
            //configuration builder class is responsible for building all config (loading files)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())//This is where to look for json file
                .AddJsonFile("appsettings.json");//tells configuration builder which file to be loaded

            _configuration = builder.Build();

        }
        public static string? GetConnectionString() 
        {
            return _configuration.GetConnectionString("LocalConnectionString");
        }
        public static SqlConnection GetConnectionObject()
        {
            SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
            return sqlConnection;
        }
    }
}
