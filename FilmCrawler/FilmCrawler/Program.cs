using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace FilmCrawler
{
    public class Program
    {           
        // The ConfigureServices call here allows for
        // ConfigureContainer to be supported in Startup with
        // a strongly-typed ContainerBuilder.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }    
    }
}
