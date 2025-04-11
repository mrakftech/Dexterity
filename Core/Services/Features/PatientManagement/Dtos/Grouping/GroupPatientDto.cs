namespace Services.Features.PatientManagement.Dtos.Grouping;

public  class GroupPatientDto
{
    public string RelationshipToPatient { get; set; }
    public GroupDto Group { get; set; }
    public int GroupId { get; set; }
    public Guid PatientId { get; set; }
}