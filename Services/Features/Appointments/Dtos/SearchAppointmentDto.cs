using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Features.PatientManagement.Dtos;
using Services.Features.PatientManagement.Dtos.Details;

namespace Services.Features.Appointments.Dtos
{
    public class SearchAppointmentDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; }
        public PatientListDto Patient { get; set; }
    }
}
