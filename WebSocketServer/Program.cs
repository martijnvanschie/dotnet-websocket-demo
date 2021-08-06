using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace WebSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the WebSocket Server...");
            CreateWebHostBuider(args).Build().Run();
            Console.WriteLine("Press any key to shutdown server...");
            Console.ReadKey();
        }

        private static IWebHostBuilder CreateWebHostBuider(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            Console.WriteLine("WebSocket Server started!");

            return builder;
        }
    }
}
