using System.ComponentModel.DataAnnotations;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Messaging;

public class ChatMessage
{
    [Key]
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public Guid ToUserId { get; set; }
    public Guid FromUserId { get; set; }

    public virtual User FromUser { get; set; }
    public virtual User ToUser { get; set; }
}