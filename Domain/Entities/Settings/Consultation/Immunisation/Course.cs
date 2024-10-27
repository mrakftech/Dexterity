using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class Course : IBaseId
{
    [Key] public Guid Id { get; set; } = Guid.Empty;
    [Required] public string Name { get; set; }
    public bool IsActive { get; set; }
}