using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Immunisations;

public class UpsertBatchDto
{
    [Required] public string BatchNumber { get; set; }
    public DateTime Expiry { get; set; } = DateTime.Now.AddYears(1);
    public string TradeName { get; set; }
    public string ManfactureName { get; set; }
    public int BatchCount { get; set; }
    public int Remaining { get; set; }
    public bool IsActive { get; set; }
    public int DrugId { get; set; }
    public int ShotId { get; set; }
}