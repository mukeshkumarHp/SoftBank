using Autofac;
using SoftBankApp.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SoftBank.Core;

namespace SoftBankApp.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.Build().
                    
                });


    }
}
