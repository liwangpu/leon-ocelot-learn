using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace App_APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
            return builder;
        }

    }
}
