using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketServer.Pipelines
{
    public static class WebSocketApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebSocketLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketLogger>();
        }
    }

    public class WebSocketLogger
    {
        private readonly RequestDelegate _next;

        public WebSocketLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                Console.WriteLine("WebSocket Call handled");
                WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
                await Echo(context, ws);
            }
            else
            {
                await _next(context);
            }

        }

        private async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                Console.WriteLine($"Received message: {Encoding.UTF8.GetString(buffer, 0, result.Count)}");
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
