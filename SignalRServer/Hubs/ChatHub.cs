using Domain.Entities.Messaging;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(ChatMessage message, string userName)
    {
        await Clients.All.SendAsync("ReceiveMessage", message, userName);
    }
    public async Task ChatNotificationAsync(string message, Guid receiverUserId, Guid senderUserId)
    {
        await Clients.All.SendAsync("ReceiveChatNotification", message, receiverUserId, senderUserId);
    }
}