namespace Shared.Requests.Messaging.UserTasks;

public class UpsertUserTaskRequest
{
    public DateOnly TaskDate { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
}