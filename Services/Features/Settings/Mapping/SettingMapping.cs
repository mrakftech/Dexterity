using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.Settings.Account;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.Settings.Consultation.Immunisation;
using Domain.Entities.Settings.Templates;
using Services.Features.Settings.Dtos;
using Services.Features.Settings.Dtos.Immunisations;

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

        CreateMap<NoteTemplate, NoteTemplateDto>().ReverseMap();

        CreateMap<Batch, UpsertBatchDto>()
            .ForMember(x => x.DrugName, c => c.MapFrom(m => m.Drug.GenericName))
            .ReverseMap();

        CreateMap<InvestigationTemplate, InvestigationTemplateDto>().ReverseMap();
        CreateMap<InvestigationTemplateDetail, InvestigationTDetailDto>().ReverseMap();
    }
}