using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Clinic;

namespace Domain.Entities.WaitingRoom;

public class WaitingAppointment
{
    public int Id { get; set; }
    public string Status { get; set; }

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }
    
    
}