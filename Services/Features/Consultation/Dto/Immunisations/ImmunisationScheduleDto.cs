using Domain.Entities.Settings.Consultation.Immunisation;

namespace Services.Features.Consultation.Dto.Immunisations;

public class ImmunisationScheduleDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ImmunisationProgram ImmunisationProgram { get; set; }
    public Guid? ImmunisationProgramId { get; set; }

    public List<Course> Courses { get; set; }
}