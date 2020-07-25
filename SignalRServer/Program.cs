using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CreateWebHostBuider(args).Build().Run();



            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static IWebHostBuilder CreateWebHostBuider(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            return builder;
        }
    }
}
