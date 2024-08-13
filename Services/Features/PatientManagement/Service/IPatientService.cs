using Domain.Entities.PatientManagement.Alert;
using Services.Features.PatientManagement.Dtos;
using Services.Features.PatientManagement.Dtos.Alerts;
using Services.Features.PatientManagement.Dtos.RelatedHcp;
using Services.Features.PatientManagement.Dtos.Upsert;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public interface IPatientService
{
    public Task<List<PatientListDto>> GetPatients();

    public Task<PatientDto> GetPatient(Guid id);
    public Task<IResult> QuickCreatePatient(QuickAddPatientDto dto, CancellationToken cancellationToken);
    public Task<IResult> CreatePatient(UpsertPatientDto request);
    public Task<IResult> UpdatePatient(Guid id, UpsertPatientDto request);
    public Task<IResult> SaveExtraDetails(PatientExtraDetailDto request);
    public Task<IResult> DeletePatient(Guid id);


    #region Contact

    public Task<List<PatientContactDto>> GetPatientContacts(Guid id);
    public Task<PatientContactDto> GetPatientContact(int id);
    public Task<IResult> DeletePatientContact(int id);
    public Task<IResult> AddPatientContact(PatientContactDto request);

    #endregion

    #region Occupation

    public Task<List<PatientOccupationDto>> GetPatientOccupations(Guid id);
    public Task<PatientOccupationDto> GetPatientOccupation(int id);
    public Task<IResult> DeletePatientOccupation(int id);
    public Task<IResult> AddPatientOccupation(PatientOccupationDto request);

    #endregion

    #region Alerts

    public Task<List<PatientAlertDto>> GetPatientAlerts(Guid patientId);
    Task<List<PatientAlertDto>> GetPatientAlertByModule(Guid patientId, string alertType);
    public Task<PatientAlertDto> GetPatientAlert(Guid id);
    public Task<IResult> SavePatientAlert(Guid id, PatientAlertCreateDto request);
    public Task<IResult> DeletePatientAlert(Guid id);
    public Task<IResult> ResolvePatientAlert(Guid id);
    
    #region Alert Category
    public Task<List<AlertCategory>> GetAlertCategories();
    public Task<IResult> AddAlertCategories(string name);
    public Task<IResult> DeleteAlertCategory(int id);
    #endregion

    #endregion
    #region Related HCPs
    public Task<List<RelatedHcpDto>> GetRealtedHcps(Guid patientId);
    public Task<RelatedHcpDto> GetRealtedHcp(int id);
    public Task<IResult> SaveRelatedHcp(RelatedHcpDto request);
    public Task<IResult> DeleteRelatedHcp(int id);

    #endregion
}