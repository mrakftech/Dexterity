using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Appointments
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }
    }
}
