namespace Domain.Entities.Settings.Immunisation;

public class ImmunisationSetup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefualt { get; set; }
    public bool IsChildhood { get; set; }
}