using System.Collections.ObjectModel;
using Domain.Entities.PatientManagement;
using Services.Contracts.Repositroy;
using Shared.Dtos.Patient;
using Shared.Responses.Patient;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public interface IPatientRepository : IRepositoryBase<Patient>
{
    public Task<List<PatientListResponse>> GetPatients();

    public Task<PatientResponse> GetPatient(Guid id);
    public Task<IResult> CreatePatient(PatientRequest request, CancellationToken cancellationToken);
    public Task<IResult> DeletePatient(Guid id);
}