using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NetCoreWebApi
{
    public static class AppConfiguration
    {
        public static string SiteUrl => "http://localhost:5000";
        public static string SecretKey { get; } = Guid.NewGuid().ToString();
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(AppConfiguration.SiteUrl);
    }
}
