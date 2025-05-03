using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.DrugManagement;

public class DrugSubstitute : BaseEntity
{
    [Range(1,int.MaxValue,ErrorMessage = "*")] public int OriginalDrugId { get; set; }
    [Range(1,int.MaxValue,ErrorMessage = "*")]public int SubtituteDrugId { get; set; }
    public bool  Active { get; set; }
}