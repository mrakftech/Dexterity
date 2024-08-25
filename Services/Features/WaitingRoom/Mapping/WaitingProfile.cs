using AutoMapper;
using Domain.Entities.Appointments;
using Domain.Entities.WaitingRoom;
using Services.Features.WaitingRoom.Dtos;

namespace Services.Features.WaitingRoom.Mapping;

public class WaitingProfile : Profile
{
    public WaitingProfile()
    {
        CreateMap<WaitingAppointment, WaitingPatientDto>()
            .ForMember(x => x.PersonalBalance, c => c.MapFrom(m => m.Patient.PatientAccount.Balance))
            .ForMember(x => x.PatientName, c => c.MapFrom(m => m.Patient.FullName))
            .ForMember(x => x.Hcp, c => c.MapFrom(m => m.Appointment.Hcp.FullName))
            .ForMember(x => x.PatientType, c => c.MapFrom(m => m.Patient.PatientType))
            .ForMember(x => x.AppointmentType, c => c.MapFrom(m => m.Appointment.AppointmentType.Name))
            .ForMember(x => x.Time, c => c.MapFrom(m => m.Appointment.StartTime.TimeOfDay))
            .ReverseMap();
    }
}