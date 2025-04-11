using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos.Grouping;

public class UpsertGroupDto
{
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    [Required(ErrorMessage = "Required")] public string GroupHead { get; set; }
    public decimal Balance { get; set; } = 0;
}