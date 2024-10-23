namespace Domain.Entities.Settings.Consultation.Immunisation;

public class CourseSchedule
{
    public int Id { get; set; }
    
    public Course Course { get; set; }
    public int CourseId { get; set; }

    public ImmunisationSetup ImmunisationSetup { get; set; }
    public int ImmunisationSetupId { get; set; }

    public int Order { get; set; }
}