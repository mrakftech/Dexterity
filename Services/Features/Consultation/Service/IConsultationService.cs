using Services.Features.Consultation.Dto;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public interface IConsultationService
{
    Task<IResult> BeginConsultation(int id, BeginConsultationDto request);
    Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId);
}