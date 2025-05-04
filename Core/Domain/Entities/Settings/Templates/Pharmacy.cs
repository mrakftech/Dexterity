using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Templates;

public class Pharmacy : BaseEntity
{
    [Required(ErrorMessage = "*")] public string Name { get; set; }
    [Required(ErrorMessage = "*")] public string Address { get; set; }
    [Required(ErrorMessage = "*")] public string Contact { get; set; }
}