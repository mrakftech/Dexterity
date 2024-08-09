using AutoMapper;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.BasicDetails;
using Services.Features.PatientManagement.Dtos.Get;
using Services.Features.PatientManagement.Dtos.Upsert;

namespace Services.Features.PatientManagement.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<Patient, PatientListDto>().ForMember(x => x.AddressLine1, c => c.MapFrom(m => m.Address.AddressLine1))
            .ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Patient, AddPatientDto>().ReverseMap();

        CreateMap<Patient, QuickAddPatientDto>().ReverseMap();
    }
}