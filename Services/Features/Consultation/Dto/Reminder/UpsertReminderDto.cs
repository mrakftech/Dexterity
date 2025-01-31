using System.ComponentModel.DataAnnotations;
using Services.State;
using Shared.Constants.Module.Consultation;

namespace Services.Features.Consultation.Dto.Reminder;

public class UpsertReminderDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public DateTime RemindDate { get; set; }
    public int RemindMeIn { get; set; }
    public ReminderPriority Priority { get; set; }
    [Required(ErrorMessage = "Required")] public string Message { get; set; }
    public bool IsActive { get; set; }


    public Guid HcpId { get; set; } = ApplicationState.Auth.CurrentUser.UserId;
    public Guid PatientId { get; set; } = ApplicationState.SelectedPatient.PatientId;
}