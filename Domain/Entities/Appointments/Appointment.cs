using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Appointments;

public class Appointment : IBaseId, IBaseActionBy, IBaseActionOn
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public int Duration { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Color { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }

    public AppointmentType AppointmentType { get; set; }
    public int AppointmentTypeId { get; set; }
    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }
    public int CancelReasonId { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

    public User Hcp { get; set; }
    public Guid HcpId { get; set; }

}