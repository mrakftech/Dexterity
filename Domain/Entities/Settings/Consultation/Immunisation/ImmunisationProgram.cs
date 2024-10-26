using Domain.Entities.Consultation;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class ImmunisationProgram
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefualt { get; set; }
    public bool IsChildhood { get; set; }

    public ImmunisationSchedule ImmunisationSchedule { get; set; }

}