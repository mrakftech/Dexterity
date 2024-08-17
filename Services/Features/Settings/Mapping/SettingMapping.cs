using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Hospital;
using Services.Features.Settings.Dtos;

namespace Services.Features.Settings.Mapping;

public class SettingMapping : Profile
{
    public SettingMapping()
    {
        CreateMap<ClinicSite, ClinicSiteDto>().ReverseMap();
        CreateMap<Clinic, ClinicDto>().ReverseMap();
        CreateMap<AppointmentType, AppointmentTypeDto>().ReverseMap();

    }
}