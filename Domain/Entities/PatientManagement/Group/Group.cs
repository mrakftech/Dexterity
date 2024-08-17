namespace Domain.Entities.PatientManagement.Group;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GroupHead { get; set; }
    public decimal Balance { get; set; }
    
    public virtual ICollection<GroupPatient> RegisteredPatients { get; set; }

}