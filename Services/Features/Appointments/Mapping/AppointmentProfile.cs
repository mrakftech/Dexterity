using AutoMapper;
using Domain.Entities.Appointments;

namespace Services.Features.Appointments.Mapping;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
    }
}