using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace VirtualArtGallery.Utility
{
    static class DbConnUtil
    {
        private static IConfiguration _configuration;
        static DbConnUtil()
        {
            GetAppSettingsFile();
            
        }
        private static void GetAppSettingsFile() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

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
