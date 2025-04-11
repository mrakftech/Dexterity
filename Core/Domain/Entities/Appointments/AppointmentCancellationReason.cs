using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Appointments
{
    public class AppointmentCancellationReason : IBaseId
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")] public string Reason { get; set; }
        public bool IsDefault { get; set; }
    }
}