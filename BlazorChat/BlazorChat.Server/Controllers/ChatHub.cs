using BlazorChat.Models;
using BlazorChat.Server.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BlazorChat.Server.Controllers
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessage(ChatMessage chatMessage)
        {
            await Clients.All.RecieveMessage(chatMessage);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecieveMessage(new ChatMessage() { User = "Host", Message = "Welcome" });
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.RecieveMessage(new ChatMessage() { User = "Host", Message = Context.ConnectionId + " left" });
            await base.OnDisconnectedAsync(exception);
        }

    }
}
