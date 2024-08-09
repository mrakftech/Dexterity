using System.ComponentModel.DataAnnotations;
using Services.Features.PatientManagement.Dtos.Get;
using Services.Features.UserAccounts.Dtos.User;
using Shared.Constants.Module;

namespace Services.Features.Messaging.Dtos.UserTasks;

public class UserTaskDto
{
    public DateTime TaskDate { get; set; } = DateTime.Today;
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime StartTime { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today;
    public DateTime EndTime { get; set; } = DateTime.Today;

    [Required] public string Subject { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public string Status { get; set; } = UserTaskConstants.TaskStatus.Active;
    public string Color { get; set; } 
    public bool IsPrivate { get; set; }

    public Guid UserId { get; set; }
    public Guid PatientId { get; set; }
    public PatientListDto Patient { get; set; }

    public HashSet<HealthcareDto> SelectedHealthCares { get; set; } = new();
}