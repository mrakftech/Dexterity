using Services.Features.Consultation.Dto;
using Services.Features.Consultation.Dto.BaselineDetails;
using Shared.Wrapper;

namespace Services.Features.Consultation.Service;

public interface IConsultationService
{
    Task<IResult> BeginConsultation(int id, BeginConsultationDto request);
    Task<List<GetConsultationDetailDto>> GetConsultationDetails(Guid patientId);


    #region Baseline Details

    Task<List<BaselineDetailDto>> GetBaselineDetails();
    Task<IResult<Guid>> SaveBaselineDetail(Guid id, CreateBaselineDetailDto request);
    Task<IResult<Guid>> DeleteBaselineDetail(Guid id);

    #endregion
}