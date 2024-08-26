using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Domain.Entities.WaitingRoom;

namespace Domain.Entities.Settings.Hospital;

public class Clinic
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }

    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<WaitingAppointment> WaitingAppointments { get; set; }

}