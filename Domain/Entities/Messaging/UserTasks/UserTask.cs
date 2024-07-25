using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Messaging.UserTasks;

public class UserTask : IBaseId
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime TaskDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime EndTime { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public string Color { get; set; }
    public bool IsPrivate { get; set; }

    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
    
    public User AssignedBy { get; set; }
    public Guid? AssignedById { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }


}