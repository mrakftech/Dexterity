using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class ProgramCourse: IBaseId
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    
    public ImmunisationProgram ImmunisationProgram { get; set; }
    public Guid ImmunisationProgramId { get; set; }
    public int Order { get; set; }
}