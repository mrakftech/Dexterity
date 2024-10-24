using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class Course
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Order { get; set; }
    public List<Shot> AssignedShots { get; set; }
}