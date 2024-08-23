using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Account;
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

        CreateMap<AccountType, AccountTypeDto>()
            .ForMember(x => x.TransactionType, c => c.MapFrom(m => m.Type.ToString()))
            .ReverseMap();
    }
}