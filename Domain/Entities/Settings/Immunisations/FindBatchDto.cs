using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Immunisations;

public class FindBatchDto
{
    [Required(ErrorMessage = "Batch number is required")] public string BatchNumber { get; set; }
    public int ShotId { get; set; }
}