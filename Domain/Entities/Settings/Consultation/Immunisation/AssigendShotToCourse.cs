namespace Domain.Entities.Settings.Consultation.Immunisation;

public class AssigendShotToCourse
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public int CourseId { get; set; }
    public Shot Shot { get; set; }
    public int ShotId { get; set; }
    public int Order { get; set; }
}