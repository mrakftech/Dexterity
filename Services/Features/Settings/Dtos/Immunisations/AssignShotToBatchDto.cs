using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos.Immunisations;

public class AssignShotToBatchDto
{
    [Required(ErrorMessage = "Batch number is required")] public string BatchNumber { get; set; }
    public Guid ShotId { get; set; }
}