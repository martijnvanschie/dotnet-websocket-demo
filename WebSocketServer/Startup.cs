using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSocketServer.Pipelines;

namespace WebSocketServer
{
    class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseWebSockets();

            app.UseWebSocketLogger();

            app.UseCors(builder => builder
                .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapHub<ChatHub>("/chathub");
            // });
        }
    }
}
