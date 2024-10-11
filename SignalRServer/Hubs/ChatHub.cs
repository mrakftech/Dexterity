using Domain.Entities.Messaging;
using Microsoft.AspNetCore.SignalR;
using Shared.Constants.Application;

namespace SignalRServer.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(ChatMessage message, string userName)
    {
        await Clients.All.SendAsync(ApplicationConstants.SignalR.ReceiveMessage, message, userName);
    }
    public async Task ChatNotificationAsync(string message, Guid receiverUserId, Guid senderUserId)
    {
        await Clients.All.SendAsync(ApplicationConstants.SignalR.ReceiveChatNotification, message, receiverUserId, senderUserId);
    }
    public async Task OnConnectAsync(Guid userId)
    {
        await Clients.All.SendAsync(ApplicationConstants.SignalR.ConnectUser, userId);
    }
    
    public async Task OnDisconnectAsync(Guid userId)
    {
        await Clients.All.SendAsync(ApplicationConstants.SignalR.DisconnectUser, userId);
    }
   
}