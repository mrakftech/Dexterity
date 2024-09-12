using AutoMapper;
using Database;
using Domain.Entities.Consultation;
using Microsoft.EntityFrameworkCore;
using Services.Features.Consultation.Dto;
using Services.Features.Consultation.Dto.BaselineDetails;
using Services.State;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public class ConsultationService(ApplicationDbContext context, IMapper mapper) : IConsultationService
{
    public async Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId)
    {
        var consultations = await context.ConsultationDetails
            .Include(x => x.Hcp)
            .Where(x => x.PatientId == patientId)
            .ToListAsync();

        var mappedData = mapper.Map<List<GetConsultationDetailDto>>(consultations);
        return mappedData;
    }

    public async Task<IResult> BeginConsultation(int id, BeginConsultationDto request)
    {
        try
        {
            if (id == 0)
            {
                var consultation = new ConsultationDetail()
                {
                    ConsultationDate = request.ConsultationDate,
                    ClinicSiteId = request.ClinicSiteId,
                    ConsultationClass = request.ConsultationClass,
                    PatientId = ApplicationState.SelectedPatientId,
                    HcpId = ApplicationState.CurrentUser.UserId,
                    ConsultationType = request.ConsultationType
                };
                context.ConsultationDetails.Add(consultation);
                await context.SaveChangesAsync();
                return await Result.SuccessAsync("Consultation has been added.");
            }

            return await Result.SuccessAsync("");
        }
        catch (Exception e)
        {
            return await Result<Guid>.FailAsync(e.Message);
        }
    }


    public async Task<List<BaselineDetailDto>> GetBaselineDetails()
    {
        var baselineDetails = await context.BaselineDetails
            .Include(x => x.Hcp)
            .Where(x => x.PatientId == ApplicationState.SelectedPatientId)
            .ToListAsync();
        var mapped = mapper.Map<List<BaselineDetailDto>>(baselineDetails);
        return mapped;
    }

    public async Task<IResult<Guid>> SaveBaselineDetail(Guid id, CreateBaselineDetailDto request)
    {
        try
        {
            var baselineDetail = mapper.Map<BaselineDetail>(request);
            if (id == Guid.Empty)
            {
                try
                {
                    context.BaselineDetails.Add(baselineDetail);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return await Result<Guid>.FailAsync(e.Message);
                }
            }
            else
            {
                var baselineDetailInDb =
                    await context.BaselineDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (baselineDetailInDb is null)
                {
                    return await Result<Guid>.FailAsync("detail not found.");
                }

                context.ChangeTracker.Clear();

                baselineDetailInDb = mapper.Map(request, baselineDetailInDb);
                context.BaselineDetails.Update(baselineDetailInDb);
                await context.SaveChangesAsync();
            }

            return await Result<Guid>.SuccessAsync(request.Id, "Details are saved.");
        }
        catch (Exception e)
        {
            return await Result<Guid>.FailAsync(e.Message);
        }
    }

    public async Task<IResult<Guid>> DeleteBaselineDetail(Guid id)
    {
        var baselineDetailInDb = await context.BaselineDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (baselineDetailInDb is null)
        {
            return await Result<Guid>.FailAsync("detail not found.");
        }
        context.BaselineDetails.Remove(baselineDetailInDb);
        await context.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync("Details are deleted.");

    }
}