using AutoMapper;
using Database;
using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Services.Features.PatientManagement.Dtos.Upsert;
using Services.State;
using Shared.Helper;
using Shared.Wrapper;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Extra;
using Services.Features.PatientManagement.Dtos;
using Services.Features.PatientManagement.Dtos.Alerts;

namespace Services.Features.PatientManagement.Service;

public class PatientService(ApplicationDbContext context, IMapper mapper)
    : IPatientService
{
    #region Patient

    public async Task<List<PatientListDto>> GetPatients()
    {
        var patients = await context.Patients.Where(x => x.IsDeleted == false).ToListAsync();
        return mapper.Map<List<PatientListDto>>(patients);
    }

    public async Task<PatientDto> GetPatient(Guid id)
    {
        var patientInDb = await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        var data = mapper.Map<PatientDto>(patientInDb);
        return data;
    }

    public async Task<IResult> QuickCreatePatient(QuickAddPatientDto request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = mapper.Map<Patient>(request);
            patient.MobilePhone = Method.GetMobileFormat(request.Mobile);
            patient.Address.AddressLine1 = request.AddressLine1;
            patient.CreatedBy = ApplicationState.CurrentUser.UserId;
            patient.ClinicId = ApplicationState.CurrentUser.ClinicId;
            patient.RegistrationDate = DateTime.Now;
            patient.Gender = request.Gender.ToString();
            await context.Patients.AddAsync(patient, cancellationToken);
            var rowsUpdated = await context.SaveChangesAsync(cancellationToken);
            if (rowsUpdated > 0)
            {
                return await Result.SuccessAsync("Patient has been saved.");
            }

            return await Result.FailAsync("Failed to save patient.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeletePatient(Guid id)
    {
        var patientInDb = await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        if (patientInDb is null)
        {
            return await Result.FailAsync("Patient not found");
        }

        patientInDb.IsDeleted = true;
        context.Patients.Update(patientInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Patient has been deleted");
    }

    public async Task<IResult> CreatePatient(UpsertPatientDto request)
    {
        try
        {
            var patient = mapper.Map<Patient>(request);
            patient.ClinicId = ApplicationState.CurrentUser.ClinicId;
            patient.CreatedBy = ApplicationState.CurrentUser.UserId;
            patient.CreatedDate = DateTime.Now;
            patient.RegistrationDate = DateTime.Now;
            patient.Gender = request.Gender.ToString();
            patient.PatientType = request.PatientType.ToString();
            //Address
            patient.Address.AddressLine1 = request.AddressLine1;
            patient.Address.AddressLine2 = request.AddressLine2;
            patient.Address.City = request.City;
            patient.Address.Country = request.Country;
            patient.Address.EriCode = request.EriCode;
            //Medical Details
            patient.MedicalCardDetails.GmsStatus = request.GmsStatus;
            patient.MedicalCardDetails.GmsDoctor = request.GmsDoctor;
            patient.MedicalCardDetails.GmsDoctorNumber = request.GmsDoctorNumber;
            patient.MedicalCardDetails.GmsPatientNumber =
                request.GmsPatientNumber == "A000000B" ? "" : request.GmsPatientNumber;
            patient.MedicalCardDetails.GmsReviewDate = request.GmsReviewDate;
            patient.MedicalCardDetails.GmsDoctorNumber = request.GmsDistanceCode;


            await context.Patients.AddAsync(patient);
            var rowsUpdated = await context.SaveChangesAsync();
            if (rowsUpdated > 0)
            {
                return await Result.SuccessAsync("Patient has been created.");
            }

            return await Result.FailAsync("Failed to save patient.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> UpdatePatient(Guid id, UpsertPatientDto request)
    {
        try
        {
            var patientInDb = await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patientInDb is null)
            {
                return await Result.FailAsync("Patient not found");
            }

            var patient = mapper.Map(request, patientInDb);
            patient.ClinicId = ApplicationState.CurrentUser.ClinicId;
            patient.CreatedBy = ApplicationState.CurrentUser.UserId;
            patient.CreatedDate = DateTime.Now;
            patient.RegistrationDate = DateTime.Now;
            patient.Gender = request.Gender.ToString();
            patient.PatientType = request.PatientType.ToString();
            //Address
            patient.Address.AddressLine1 = request.AddressLine1;
            patient.Address.AddressLine2 = request.AddressLine2;
            patient.Address.City = request.City;
            patient.Address.Country = request.Country;
            patient.Address.EriCode = request.EriCode;
            //Medical Details
            patient.MedicalCardDetails.GmsStatus = request.GmsStatus;
            patient.MedicalCardDetails.GmsDoctor = request.GmsDoctor;
            patient.MedicalCardDetails.GmsDoctorNumber = request.GmsDoctorNumber;
            patient.MedicalCardDetails.GmsPatientNumber =
                request.GmsPatientNumber == "A000000B" ? "" : request.GmsPatientNumber;
            patient.MedicalCardDetails.GmsReviewDate = request.GmsReviewDate;
            patient.MedicalCardDetails.GmsDoctorNumber = request.GmsDistanceCode;


            context.Patients.Update(patient);
            var rowsUpdated = await context.SaveChangesAsync();
            if (rowsUpdated > 0)
            {
                return await Result.SuccessAsync("Patient has been updated.");
            }

            return await Result.FailAsync("Failed to save patient.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> SaveExtraDetails(PatientExtraDetailDto request)
    {
        try
        {
            var extraDetail = await context.Patients
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.PatientId);
            if (extraDetail is null)
            {
                return await Result.FailAsync("Details not found");
            }

            var otehrDetails = mapper.Map<OtherDetail>(request);
            var maritalDetail = mapper.Map<MaritalDetail>(request);
            extraDetail.OtherDetails = otehrDetails;
            extraDetail.MaritalDetails = maritalDetail;
            context.Patients.Update(extraDetail);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Details updated.");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    #endregion

    #region Contact

    public async Task<List<PatientContactDto>> GetPatientContacts(Guid id)
    {
        var list = await context.PatientContacts.Where(x => x.PatientId == id).ToListAsync();
        var data = mapper.Map<List<PatientContactDto>>(list);
        return data;
    }

    public async Task<PatientContactDto> GetPatientContact(int id)
    {
        var contact = await context.PatientContacts.FirstOrDefaultAsync(x => x.Id == id);
        if (contact is null)
        {
            return new PatientContactDto();
        }

        return mapper.Map<PatientContactDto>(contact);
    }

    public async Task<IResult> DeletePatientContact(int id)
    {
        var contact = await context.PatientContacts.FirstOrDefaultAsync(x => x.Id == id);
        if (contact is null)
        {
            return await Result.FailAsync("Contact not found");
        }

        context.PatientContacts.Remove(contact);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Contact has been removed");
    }

    public async Task<IResult> AddPatientContact(PatientContactDto request)
    {
        var contact = mapper.Map<PatientContact>(request);
        await context.PatientContacts.AddAsync(contact);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Contact added.");
    }

    #endregion

    #region Patient Occupation

    public async Task<List<PatientOccupationDto>> GetPatientOccupations(Guid id)
    {
        var list = await context.PatientOccupations.Where(x => x.PatientId == id).ToListAsync();
        var data = mapper.Map<List<PatientOccupationDto>>(list);
        return data;
    }

    public async Task<PatientOccupationDto> GetPatientOccupation(int id)
    {
        var occupation = await context.PatientOccupations.FirstOrDefaultAsync(x => x.Id == id);
        if (occupation is null)
        {
            return new PatientOccupationDto();
        }

        return mapper.Map<PatientOccupationDto>(occupation);
    }

    public async Task<IResult> DeletePatientOccupation(int id)
    {
        var occupation = await context.PatientOccupations.FirstOrDefaultAsync(x => x.Id == id);
        if (occupation is null)
        {
            return await Result.FailAsync("Occupation not found");
        }

        context.PatientOccupations.Remove(occupation);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Occupation has been removed");
    }

    public async Task<IResult> AddPatientOccupation(PatientOccupationDto request)
    {
        var occupation = mapper.Map<PatientOccupation>(request);
        await context.PatientOccupations.AddAsync(occupation);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Occupation has been added.");
    }

    #endregion

    #region Patient Alerts

    public async Task<List<PatientAlertDto>> GetPatientAlerts(Guid patientId)
    {
        var list = await context.PatientAlerts
            .Include(x=>x.AlertCategory)
            .Where(x=>x.IsDeleted==false)
            .AsNoTracking().Where(x => x.PatientId == patientId)
            .ToListAsync();
        context.ChangeTracker.Clear();
        var mappedData = mapper.Map<List<PatientAlertDto>>(list);
        return mappedData;
    }

    public async Task<PatientAlertDto> GetPatientAlert(Guid id)
    {
        var alert = await context.PatientAlerts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        context.ChangeTracker.Clear();
        var mappedData = mapper.Map<PatientAlertDto>(alert);
        return mappedData;
    }

    public async Task<IResult> SavePatientAlert(Guid id, PatientAlertCreateDto request)
    {
        var alert = new PatientAlert
        {
            Details = request.Details,
            Type = request.AlertType.ToString(),
            Severity = request.Severity.ToString(),
            AlertCategoryId = request.AlertCategoryId,
            CreatedBy = ApplicationState.CurrentUser.UserId,
            CreatedDate = DateTime.Now,
            PatientId = request.PatientId
        };
        await context.PatientAlerts.AddAsync(alert);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Alert has been saved.");
    }

    public async Task<IResult> DeletePatientAlert(Guid id)
    {
        var alert = await context.PatientAlerts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (alert is null)
        {
            return await Result.FailAsync("Alert not found");
        }

        alert.IsDeleted = true;
        alert.ModifiedDate = DateTime.Now;
        alert.ModifiedBy = ApplicationState.CurrentUser.UserId;
        context.ChangeTracker.Clear();
        context.PatientAlerts.Update(alert);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Alert has been removed");
    }

    public async Task<IResult> ResolvePatientAlert(Guid id)
    {
        var alert = await context.PatientAlerts
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (alert is null)
        {
            return await Result.FailAsync("Alert not found");
        }

        alert.IsResolved = true;
        alert.ModifiedDate = DateTime.Now;
        alert.ModifiedBy = ApplicationState.CurrentUser.UserId;
        context.ChangeTracker.Clear();
        context.PatientAlerts.Update(alert);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Alert has been resolved.");
    }

    #region Alert Categories

    public async Task<List<AlertCategory>> GetAlertCategories()
    {
        return await context.AlertCategories.ToListAsync();
    }

    public async Task<IResult> AddAlertCategories(string name)
    {
        var alertCategory = new AlertCategory()
        {
            Name = name
        };
        await context.AlertCategories.AddAsync(alertCategory);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Category has been added");
    }

    public async Task<IResult> DeleteAlertCategory(int id)
    {
        var category = await context.AlertCategories.FirstOrDefaultAsync(x => x.Id == id);
        if (category is null)
        {
            return await Result.FailAsync("Alert Category not found");
        }

        context.AlertCategories.Remove(category);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Alert Category has been removed");
    }

    #endregion

    #endregion
}