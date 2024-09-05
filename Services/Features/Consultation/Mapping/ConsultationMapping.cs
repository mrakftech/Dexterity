using AutoMapper;
using Domain.Entities.Consultation;
using Services.Features.Consultation.Dto;

namespace Services.Features.Consultation.Mapping;

public class ConsultationMapping : Profile
{
    public ConsultationMapping()
    {
        CreateMap<ConsultationDetail, GetConsultationDetailDto>()
            .ForMember(x => x.Date, c => c.MapFrom(m => m.ConsultationDate.ToString("g")))
            .ForMember(x => x.Hcp, c => c.MapFrom(m => m.Hcp.FullName))
            .ForMember(x => x.Type, c => c.MapFrom(m => m.ConsultationType))
            .ReverseMap();
    }
}