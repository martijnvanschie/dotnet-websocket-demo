using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

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
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}