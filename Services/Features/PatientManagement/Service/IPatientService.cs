using Domain.Entities.PatientManagement.Alert;
using Services.Features.PatientManagement.Dtos.Account;
using Services.Features.PatientManagement.Dtos.Alerts;
using Services.Features.PatientManagement.Dtos.Allergies;
using Services.Features.PatientManagement.Dtos.Details;
using Services.Features.PatientManagement.Dtos.Family;
using Services.Features.PatientManagement.Dtos.Grouping;
using Services.Features.PatientManagement.Dtos.Options;
using Services.Features.PatientManagement.Dtos.RelatedHcp;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public interface IPatientService
{
    #region Patient

    public Task<List<PatientListDto>> GetPatients();

    public Task<PatientDto> GetPatient(Guid id);
    public Task<DateTime> GetPatientDob(Guid id);
    public Task<IResult> QuickCreatePatient(QuickAddPatientDto dto, CancellationToken cancellationToken);
    public Task<IResult> CreatePatient(UpsertPatientDto request);
    public Task<IResult> UpdatePatient(Guid id, UpsertPatientDto request);
    public Task<IResult> SaveExtraDetails(PatientExtraDetailDto request);
    public Task<IResult> DeletePatient(Guid id);
    public Task<PatientSummaryDto> GetPatientSummary(Guid patientId);

    #endregion

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

    #region Select Hospital

    public Task<List<PatientHospitalDto>> GetSelectedHospitals(Guid patientId);
    public Task<IResult> SelectHospital(PatientHospitalDto request);
    public Task<IResult> DeleteSelectedHospital(int id);

    #endregion

    #region Group

    public Task<List<GroupDto>> GetGroups();
    public Task<GroupDto> GetGroup(int id);
    public Task<IResult> SaveGroup(int id, UpsertGroupDto request);
    public Task<IResult> DeleteGroup(int id);

    #region Group Patients

    public Task<List<GroupPatientDto>> GetPatientsByGroup(int groupId);
    public Task<GroupDto> GetSelectedGroup(Guid patientId);
    public Task<IResult> RegisterPatientToGroup(GroupPatientDto request);

    #endregion

    #endregion

    #region Family

    public Task<List<FamilyMemberDto>> GetFamilyMembers(Guid patientId);
    public Task<FamilyMemberDto> GetFamilyMember(int id);
    public Task<IResult> SaveFamilyMember(int id, FamilyMemberDto request);
    public Task<IResult> DeleteFamilyMember(int id);

    #endregion

    #region Account

    public Task<GetPatientAccountDto> GetPatientAccount(Guid patientId);
    public Task<List<GetTransactionDto>> GetOutstanding(int accountId);
    public Task<List<AccountStatementDto>> GetStatement(int accountId);
    public Task<List<GetTransactionDto>> GetPrintLog(int accountId);
    public Task<List<GetTransactionDto>> GetAudit(int accountId);
    public Task<List<GetTransactionDto>> GetHistory(int accountId);
    public Task<IResult> Charge(ChargeDto request);
    public Task<IResult> PaymentForAllocatedItems(PaymentAllocatedDto request);
    public Task<IResult> StrikeOff(StrikeOffDto request);
    public Task<IResult> DeleteTransaction(int transactionId);
    public decimal GetBroughtForwardBalance(int accountId);

    #endregion

    #region Options

    public Task<List<HospitalDto>> GetHospitals();
    public Task<HospitalDto> GetHospital(int id);
    public Task<IResult> SaveHospital(int id, HospitalDto request);
    public Task<IResult> DeleteHospital(int id);
    
    public Task<IResult> CreateGroupAlerts(CreatePatientGroupAlertDto request);
    public Task<IResult> DeleteGroupAlerts(List<GetGroupAlertDto> groupAlerts);
    public Task<IResult> ResolveGroupAlerts(List<GetGroupAlertDto> groupAlerts);
    public Task<List<GetGroupAlertDto>> GetAllPatientAlerts();

    #endregion

    #region Allergies
    public Task<List<PatientAllergyDto>> GetPatientAllergies();
    public Task<PatientAllergyDto> GetPatientAllergy(int id);
    public Task<IResult> UpsertPatientAllergy(int id, UpsertAllergyDto allergy);
    public Task<IResult> RemovePatientAllergy(int id);
    
    
    public Task<DrugAllergyDto> GetPatientDrugAllergy(int id);

    public Task<List<DrugAllergyDto>> GetPatientDrugAllergies();
    public Task<IResult> UpsertPatientDrugAllergy(int id, UpsertDrugAllergyDto allergy);

    public Task<IResult> RemovePatientDrugAllergy(int id);

    #endregion
}