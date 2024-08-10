using AutoMapper;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.BasicDetails;
using Domain.Entities.PatientManagement.Extra;
using Services.Features.PatientManagement.Dtos.Get;
using Services.Features.PatientManagement.Dtos.Upsert;

namespace Services.Features.PatientManagement.Mapping;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        #region Patients
        CreateMap<Patient, PatientListDto>()
            .ForMember(x => x.AddressLine1, c => c.MapFrom(m => m.Address.AddressLine1))
            .ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Patient, UpsertPatientDto>().ReverseMap();
        CreateMap<Patient, QuickAddPatientDto>().ReverseMap();
        CreateMap<PatientDto, UpsertPatientDto>()
            .ForMember(x => x.AddressLine1, c => c.MapFrom(m => m.Address.AddressLine1))
            .ForMember(x => x.AddressLine2, c => c.MapFrom(m => m.Address.AddressLine2))
            .ForMember(x => x.City, c => c.MapFrom(m => m.Address.City))
            .ForMember(x => x.Country, c => c.MapFrom(m => m.Address.Country))
            .ForMember(x => x.County, c => c.MapFrom(m => m.Address.County))
            .ForMember(x => x.EriCode, c => c.MapFrom(m => m.Address.EriCode))
            .ForMember(x => x.IsGmsActive,
                c => c.MapFrom(m => m.MedicalCardDetails.GmsStatus == "Active"))
            .ForMember(x => x.GmsStatus, c => c.MapFrom(m => m.MedicalCardDetails.GmsStatus))
            .ForMember(x => x.GmsDoctor, c => c.MapFrom(m => m.MedicalCardDetails.GmsDoctor))
            .ForMember(x => x.GmsDoctorNumber, c => c.MapFrom(m => m.MedicalCardDetails.GmsDoctorNumber))
            .ForMember(x => x.GmsPatientNumber, c => c.MapFrom(m => m.MedicalCardDetails.GmsPatientNumber))
            .ForMember(x => x.GmsReviewDate, c => c.MapFrom(m => m.MedicalCardDetails.GmsReviewDate))
            .ForMember(x => x.GmsDistanceCode, c => c.MapFrom(m => m.MedicalCardDetails.GmsDistanceCode))
            .ReverseMap();
        

        #endregion

        #region Extra Details

        CreateMap<PatientExtraDetailDto, OtherDetail>().ReverseMap();;
        CreateMap<PatientExtraDetailDto, MaritalDetail>().ReverseMap();;

        #endregion

    }
}