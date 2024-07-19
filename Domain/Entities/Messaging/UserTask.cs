using Domain.Contracts;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Messaging;

public class UserTask : IBaseId
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateOnly TaskDate { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }
}