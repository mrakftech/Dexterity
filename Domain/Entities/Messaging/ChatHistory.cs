using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Messaging;

public class ChatHistory
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Type { get; set; }
    public string UserName { get; set; }
    public string Message { get; set; }
    public Guid UserId { get; set; }
}