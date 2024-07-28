using AutoMapper;
using Domain.Entities.Appointments;
using Services.Features.Appointments.Dtos;

namespace Services.Features.Appointments.Mapping;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, UpsertAppointmentDto>().ReverseMap();
        CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
        CreateMap<GetAppointmentDto, UpsertAppointmentDto>().ReverseMap();
    }
}