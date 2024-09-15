using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Services.Features.UserAccounts.Dtos.User;
using Shared.Constants.Module.Consultation;

namespace Services.Features.Consultation.Dto.Reminder;

public class GetReminderDto
{
    public int Id { get; set; }
    public string Date { get; set; }
    public ReminderPriority Priority { get; set; }
    public string Message { get; set; }
    public bool IsActive { get; set; }


    public Guid HcpId { get; set; }
    public string DoctorName { get; set; }
    public Guid PatientId { get; set; }
}