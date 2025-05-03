
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.DrugManagement;

public class DrugInstruction : BaseEntity
{
   [Required(ErrorMessage = "*")] public string Description { get; set; }
   [Required(ErrorMessage = "*")]  public string Code { get; set; }
}