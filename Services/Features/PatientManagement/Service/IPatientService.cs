using Services.Features.PatientManagement.Dtos.Get;
using Services.Features.PatientManagement.Dtos.Upsert;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public interface IPatientService 
{
    public Task<List<PatientListDto>> GetPatients();

    public Task<PatientDto> GetPatient(Guid id);
    public Task<IResult> QuickCreatePatient(QuickAddPatientDto dto, CancellationToken cancellationToken);
    public Task<IResult> CreatePatient(AddPatientDto request);
    public Task<IResult> DeletePatient(Guid id);
}