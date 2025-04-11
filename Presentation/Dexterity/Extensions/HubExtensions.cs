using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Constants.Application;

namespace Dexterity.Extensions;

public static class HubExtensions
{
    public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager)
    {
        if (hubConnection == null)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri($"{ApplicationConstants.SignalR.Host}{ApplicationConstants.SignalR.HubUrl}"))
                .Build();
        }
        return hubConnection;
    }
}