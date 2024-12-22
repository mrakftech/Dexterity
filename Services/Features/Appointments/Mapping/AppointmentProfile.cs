using AutoMapper;
using Domain.Entities.Appointments;
using Services.Features.Appointments.Dtos;

namespace Services.Features.Appointments.Mapping;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>()
            .ForMember(x => x.PatientName, c => c.MapFrom(m => m.Patient.FullName))
            .ReverseMap();
        CreateMap<Appointment, SearchAppointmentDto>()
            .ForMember(x => x.PatientName, c => c.MapFrom(m => m.Patient.FullName))
            .ForMember(x => x.DateOfBirth, c => c.MapFrom(m => m.Patient.DateOfBirth))
            .ReverseMap();

        CreateMap<Appointment, AppointmentHistoryDto>()
            .ForMember(x => x.PatientName, c => c.MapFrom(m => m.Patient.FullName))
            .ForMember(x => x.Hcp, c => c.MapFrom(m => m.Hcp.FullName))
            .ForMember(x => x.Type, c => c.MapFrom(m => m.AppointmentType.Name))
            .ReverseMap();
    }
}