using AutoMapper;
using Domain.Entities.Settings;
using Services.Features.Settings.Dtos;

namespace Services.Features.Settings.Mapping;

public class SettingMapping : Profile
{
    public SettingMapping()
    {
        CreateMap<Clinic, ClinicDto>().ReverseMap();

    }
}