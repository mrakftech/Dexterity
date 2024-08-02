using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Practice;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Appointments;

public class Appointment : IBaseActionBy, IBaseActionOn
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public bool IsAllDay { get; set; }
    public string RecurrenceRule { get; set; }
    public string RecurrenceException { get; set; }
    public int? RecurrenceID { get; set; }
    public string Status { get; set; }

    public int Duration { get; set; }


    public int CancelReasonId { get; set; }

    public AppointmentType AppointmentType { get; set; }
    public int AppointmentTypeId { get; set; }

    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }

    public ClinicSite ClinicSite { get; set; }
    public int ClinicSiteId { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }

    public User Hcp { get; set; }
    public Guid HcpId { get; set; }


    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}