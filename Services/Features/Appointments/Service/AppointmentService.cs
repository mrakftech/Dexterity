using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore;
using Services.Features.Appointments.Dtos;

namespace Services.Features.Appointments.Service;

public class AppointmentService(ApplicationDbContext context, IMapper mapper) : IAppointmentService
{
    public async Task<List<AppointmentDto>> GetAppoinments()
    {
        var appointments = await context.Appointments.ToListAsync();
        var list = mapper.Map<List<AppointmentDto>>(appointments);
        return list;
    }
}