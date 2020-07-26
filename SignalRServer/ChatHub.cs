using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer
{
    internal class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Connection from [{Context.ConnectionId}]");
            Clients.Caller.SendAsync("ReceivedConnection", Context.ConnectionId);
            return base.OnConnectedAsync();
        }


        public async Task SendMessage(string message)
        {
            Console.WriteLine($"Receive message [{message}] from client [{Context.ConnectionId}]");
            await Clients.All.SendAsync("ReceiveMessage", $"Receive message [{message}] from client [{Context.ConnectionId}]");
        }
    }
}