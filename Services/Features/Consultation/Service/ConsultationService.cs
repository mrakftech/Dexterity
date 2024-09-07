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


    public async Task<List<BaselineDetailDto>> GetBaselineDetails(int consultationId)
    {
        var baselineDetails = await context.ConsultationDetails.Where(x => x.Id == consultationId).ToListAsync();
        var mapped = mapper.Map<List<BaselineDetailDto>>(baselineDetails);
        return mapped;
    }
}