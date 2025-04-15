
using Microsoft.AspNetCore.SignalR;

namespace Deco_Sara.Signalr
{
    public class ChatHub:Hub
    {
        // This method will be called by the client to send a message.
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message); // Broadcast to all connected clients
        }

        // Optionally, handle messages for specific users
        public async Task SendMessageToUser(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", "Support Agent", message);
        }
    }
}
