using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos
{
    public class ClinicSiteDto
    {
        public int Id { get; set; }
       [Required(ErrorMessage = "Required")] public string Name { get; set; }
        public int ClinicId { get; set; }

    }
}
