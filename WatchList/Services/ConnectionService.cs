using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

namespace WatchList.Services
{
    public class ConnectionService
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            //Determines which string to connect with.
            var connectionString = configuration.GetConnectionString("DefaultConnection"); //app settings .json will use this is DefaultConnection is available.
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL"); //Only available if this application is running remotely.Make sure Variable is singular to avoid error.
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }
        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}

//This service is similar to what is used as my ConnectionHelper in the Six Degrees Application.
