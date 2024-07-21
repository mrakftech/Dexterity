namespace Services.Features.Messaging.Dtos.UserTasks;

public class UserTaskDto
{
    public DateTime TaskDate { get; set; } = DateTime.Today;
    public string Subject { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
}