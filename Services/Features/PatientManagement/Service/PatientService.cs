using AutoMapper;
using Database;
using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Services.Features.PatientManagement.Dtos.Get;
using Services.Features.PatientManagement.Dtos.Upsert;
using Services.State;
using Shared.Helper;
using Shared.Wrapper;
using System.Threading;
using Domain.Entities.PatientManagement.Extra;

namespace Services.Features.PatientManagement.Service;

public class PatientService(ApplicationDbContext context, IMapper mapper)
    : IPatientService
{
    private IPatientService _patientServiceImplementation;

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
}