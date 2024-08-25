using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;

namespace Domain.Entities.WaitingRoom;

public class WaitingAppointment
{
    public int Id { get; set; }
    public string Status { get; set; }

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    
    
}