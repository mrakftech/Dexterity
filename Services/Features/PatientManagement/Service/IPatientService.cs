using Services.Features.PatientManagement.Dtos;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public interface IPatientService 
{
    public Task<List<PatientListDto>> GetPatients();

    public Task<PatientDto> GetPatient(Guid id);
    public Task<IResult> CreatePatient(UpsertPatientDto dto, CancellationToken cancellationToken);
    public Task<IResult> DeletePatient(Guid id);
}