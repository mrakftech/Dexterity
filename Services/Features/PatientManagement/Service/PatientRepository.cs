using System.Collections.ObjectModel;
using AutoMapper;
using Database;
using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using Services.Respository;
using Shared.Constants.Application;
using Shared.Dtos.Patient;
using Shared.Helper;
using Shared.Responses.Patient;
using Shared.State;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public class PatientRepository(ApplicationDbContext context, IMapper mapper)
    : RepositoryBase<Patient>(context), IPatientRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<PatientListResponse>> GetPatients()
    {
        var patients = await _context.Patients.Where(x => x.IsDeleted == false).ToListAsync();
        return mapper.Map<List<PatientListResponse>>(patients);
    }

    public async Task<PatientResponse> GetPatient(Guid id)
    {
        var patientInDb = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        var data = mapper.Map<PatientResponse>(patientInDb);
        return data;
    }

    public async Task<IResult> CreatePatient(PatientRequest request, CancellationToken cancellationToken)
    {
        try
        {
            request.Mobile = Method.GetMobileFormat(request.Mobile);
            request.CreatedBy = ApplicationState.CurrentUser.UserId;
            var patient = mapper.Map<Patient>(request);
            await _context.Patients.AddAsync(patient, cancellationToken);
            var rowsUpdated = await _context.SaveChangesAsync(cancellationToken);
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
        var patientInDb = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        if (patientInDb is not null)
        {
            patientInDb.IsDeleted = true;
        }

        return await Result.SuccessAsync("Patient has been deleted");
    }
}