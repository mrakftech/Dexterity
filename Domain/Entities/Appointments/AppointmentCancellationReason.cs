using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Appointments
{
    public class AppointmentCancellationReason
    {
        public int Id { get; set; }
       [Required] public string Reason { get; set; }
       public bool IsDefault { get; set; }
    }
}
