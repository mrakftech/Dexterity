using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Domain.Entities.WaitingRoom;

namespace Domain.Entities.Settings.Clinic;

public class Clinic
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<WaitingAppointment> WaitingAppointments { get; set; }

}