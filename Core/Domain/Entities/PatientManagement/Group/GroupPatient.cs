namespace Domain.Entities.PatientManagement.Group;

public class GroupPatient
{
    public int Id { get; set; }
    public string RelationshipToPatient { get; set; }


    public Group Group { get; set; }
    public int GroupId { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}