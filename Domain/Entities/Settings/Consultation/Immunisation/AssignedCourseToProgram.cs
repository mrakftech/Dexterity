namespace Domain.Entities.Settings.Consultation.Immunisation;

public class AssignedCourseToProgram
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public int CourseId { get; set; }
    public ImmunisationProgram ImmunisationProgram { get; set; }
    public int ImmunisationProgramId { get; set; }
    public int Order { get; set; }
}