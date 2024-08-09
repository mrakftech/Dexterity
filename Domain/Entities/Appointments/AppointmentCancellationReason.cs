using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Appointments
{
    public class AppointmentCancellationReason
    {
        public int Id { get; set; }
       [Required] public string Reason { get; set; }
       public bool IsDefault { get; set; }
    }
}
