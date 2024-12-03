using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Shared.Constants.Module.Consultation;

namespace Domain.Entities.Consultation.Common;

public class Reminder
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime RemindDate { get; set; }
    public ReminderPriority Priority { get; set; }
    public string Message { get; set; }
    public bool IsActive { get; set; }


    public User Hcp { get; set; }
    public Guid HcpId { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}