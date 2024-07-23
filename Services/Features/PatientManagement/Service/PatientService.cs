using AutoMapper;
using Database;
using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Services.Features.PatientManagement.Dtos;
using Services.State;
using Shared.Helper;
using Shared.Wrapper;

namespace Services.Features.PatientManagement.Service;

public class PatientService(ApplicationDbContext context, IMapper mapper)
    : IPatientService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<PatientListDto>> GetPatients()
    {
        var patients = await _context.Patients.Where(x => x.IsDeleted == false).ToListAsync();
        return mapper.Map<List<PatientListDto>>(patients);
    }

    public async Task<PatientDto> GetPatient(Guid id)
    {
        var patientInDb = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        var data = mapper.Map<PatientDto>(patientInDb);
        return data;
    }

    public async Task<IResult> CreatePatient(UpsertPatientDto dto, CancellationToken cancellationToken)
    {
        try
        {
            dto.Mobile = Method.GetMobileFormat(dto.Mobile);
            dto.CreatedBy = ApplicationState.CurrentUser.UserId;
            var patient = mapper.Map<Patient>(dto);
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