namespace Services.Features.Messaging.Dtos.InstantChat;

public class ChatHistoryDto
{
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string UserName { get; set; }
    public string Message { get; set; }
}