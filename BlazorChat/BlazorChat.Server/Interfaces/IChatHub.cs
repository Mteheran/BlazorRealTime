using BlazorChat.Models;
using System.Threading.Tasks;

namespace BlazorChat.Server.Interfaces
{
    public interface IChatHub
    {
        Task SendMessage(ChatMessage chatMessage);
        Task RecieveMessage(ChatMessage chatMessage);
    }
}
