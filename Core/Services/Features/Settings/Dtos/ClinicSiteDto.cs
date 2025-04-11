using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos
{
    public class ClinicSiteDto
    {
        public Guid Id { get; set; }
       [Required(ErrorMessage = "Required")] public string Name { get; set; }
        public int ClinicId { get; set; }

    }
}
