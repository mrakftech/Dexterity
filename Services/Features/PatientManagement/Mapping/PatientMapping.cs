using AutoMapper;
using Domain.Entities.PatientManagement;
using Domain.Entities.PatientManagement.Alert;
using Domain.Entities.PatientManagement.Billing;
using Domain.Entities.PatientManagement.Details;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Family;
using Domain.Entities.PatientManagement.Group;
using Services.Features.PatientManagement.Dtos;
using Services.Features.PatientManagement.Dtos.Account;
using Services.Features.PatientManagement.Dtos.Alerts;
using Services.Features.PatientManagement.Dtos.Details;
using Services.Features.PatientManagement.Dtos.Family;
using Services.Features.PatientManagement.Dtos.Grouping;
using Services.Features.PatientManagement.Dtos.RelatedHcp;
using Shared.Constants.Module;

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

        CreateMap<PatientExtraDetailDto, OtherDetail>().ReverseMap();
        CreateMap<PatientExtraDetailDto, MaritalDetail>().ReverseMap();
        CreateMap<PatientContact, PatientContactDto>().ReverseMap();
        CreateMap<PatientOccupation, PatientOccupationDto>().ReverseMap();
        CreateMap<RelatedHcp, RelatedHcpDto>().ReverseMap();
        CreateMap<PatientHospital, PatientHospitalDto>().ReverseMap();

        #endregion

        #region Alert

        CreateMap<PatientAlert, PatientAlertDto>()
            .ForMember(x => x.Category, c => c.MapFrom(m => m.AlertCategory.Name))
            .ForMember(x => x.Status, c => c.MapFrom(m => m.IsResolved == true ? "Resolved" : "Pending"))
            .ReverseMap();

        #endregion

        #region Group

        CreateMap<Group, GroupDto>()
            .ForMember(x => x.RegisteredPatientsCount, c => c.MapFrom(m => m.RegisteredPatients.Count))
            .ReverseMap();
        CreateMap<Group, UpsertGroupDto>().ReverseMap();
        CreateMap<GroupPatient, GroupPatientDto>().ReverseMap();

        #endregion

        #region Patient Family

        CreateMap<FamilyMember, FamilyMemberDto>().ReverseMap();

        #endregion

        #region Account

        CreateMap<PatientAccount, GetPatientAccountDto>()
            .ForMember(x => x.Age, c => c.MapFrom(m => PatientConstants.CalculateAge(m.Patient.DateOfBirth)))
            .ReverseMap();
        CreateMap<PatientTransaction, GetTransactionDto>()
            .ReverseMap();

        #endregion
    }
}