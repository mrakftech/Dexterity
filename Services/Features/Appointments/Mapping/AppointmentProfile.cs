using AutoMapper;
using Domain.Entities.Appointments;
using Services.Features.Appointments.Dtos;

namespace Services.Features.Appointments.Mapping;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, UpsertAppointmentDto>().ReverseMap();
        CreateMap<Appointment, GetAppointmentDto>()
            .ForMember(
        dest => dest.Type,
        opt => opt.MapFrom(src => src.AppointmentType.Name)

    ).ForMember(
        dest => dest.Title,
        opt => opt.MapFrom(src => src.Patient.FullName)
    )
            .ReverseMap();
        CreateMap<GetAppointmentDto, UpsertAppointmentDto>().ReverseMap();
    }
}