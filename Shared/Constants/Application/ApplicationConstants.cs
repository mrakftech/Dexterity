namespace Shared.Constants.Application;

public static class ApplicationConstants
{
    public const string DefaultPassword = "Dexterity123@";
    public const string AppRegion = "US";


    public static List<ResetDuration> GetPasswordResetDuration()
    {
        var durations = new List<ResetDuration>()
        {
            new(1, "Every 30 Days"),
            new(2, "Every 60 Days"),
            new(3, "Every 90 Days"),
            new(4, "Every 6 Months"),
            new(5, "Every 1 Year"),
            new(6, "Every 5 Years")
        };

        return durations;
    }

    public class ResetDuration(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
    public static class SignalR
    {
        public const string Host = "https://localhost:7177";
        public const string HubUrl = "/chatHub";
        public const string SendUpdateDashboard = "UpdateDashboardAsync";
        public const string ReceiveUpdateDashboard = "UpdateDashboard";
        public const string PingRequest = "PingRequestAsync";
        
        public const string ReceiveChatNotification = "ReceiveChatNotification";
        public const string SendChatNotification = "ChatNotificationAsync";
        public const string ReceiveMessage = "ReceiveMessage";
        public const string SendMessage = "SendMessageAsync";

        public const string OnConnect = "OnConnectAsync";
        public const string ConnectUser = "ConnectUser";
        public const string DisconnectUser = "DisconnectUser";


    }
}