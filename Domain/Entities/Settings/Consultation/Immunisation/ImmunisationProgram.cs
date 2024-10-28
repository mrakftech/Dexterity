using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.Consultation;

namespace Domain.Entities.Settings.Consultation.Immunisation;

public class ImmunisationProgram : IBaseId
{
    [Key] public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefualt { get; set; }
    public bool IsChildhood { get; set; }

    public List<ImmunisationSchedule> ImmunisationSchedules { get; set; }
}