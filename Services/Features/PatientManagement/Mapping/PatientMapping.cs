using AutoMapper;
using Domain.Entities.PatientManagement;
using Shared.Dtos.Patient;
using Shared.Responses.Patient;

namespace Services.Features.PatientManagement.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<Patient, PatientListResponse>().ReverseMap();
        CreateMap<Patient, PatientResponse>().ReverseMap();


        CreateMap<Patient, PatientRequest>().ReverseMap();
    }
}