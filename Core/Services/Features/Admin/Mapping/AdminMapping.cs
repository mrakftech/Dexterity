using AutoMapper;
using Domain.Entities.Common;
using Services.Features.Admin.Dtos.FlagRecords;

namespace Services.Features.Admin.Mapping;

public class AdminMapping : Profile
{
    public AdminMapping()
    {
        CreateMap<FlagRecord, GetFlagRecordDto>()
            .ForMember(x => x.FlaggedBy, c => c.MapFrom(m => m.FlaggedBy.FullName))
            .ForMember(x => x.ResolvedBy, c => c.MapFrom(m => m.ResolvedBy.FullName))
            .ReverseMap();
    }
}