using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features.Settings.Dtos
{
    public class ClinicSiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClinicId { get; set; }

    }
}
