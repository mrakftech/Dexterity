using AutoMapper;
using Domain.Entities.PatientManagement;
using Services.Features.PatientManagement.Dtos;

namespace Services.Features.PatientManagement.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<Patient, PatientListDto>().ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();


        CreateMap<Patient, UpsertPatientDto>().ReverseMap();
    }
}