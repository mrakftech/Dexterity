using AutoMapper;
using Database;
using Domain.Entities.WaitingRoom;
using Microsoft.EntityFrameworkCore;
using Services.Features.WaitingRoom.Dtos;
using Services.State;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.WaitingRoom.Service;

public class WaitingRoomService(ApplicationDbContext context, IMapper mapper) : IWaitingRoomService
{
    public async Task<List<WaitingPatientDto>> GetExpectedPatients(string status)
    {
        var todayDate = DateTime.Now.Date;
        await AddExpectedPatients();
        var appointments = await context.WaitingAppointments
            .Include(x => x.Appointment)
            .Include(x => x.Patient)
            .Include(x => x.Patient.PatientAccount)
            .Where(x => x.Appointment.StartTime.Date == todayDate && x.Status == status)
            .ToListAsync();


        var data = mapper.Map<List<WaitingPatientDto>>(appointments);
        return data;
    }
    public async Task<List<WaitingPatientDto>> GetWaitingPatients(string status)
    {
        var todayDate = DateTime.Now.Date;
        var appointments = await context.WaitingAppointments
            .Include(x => x.Appointment)
            .Include(x => x.Patient)
            .Include(x => x.Patient.PatientAccount)
            .Where(x => x.Appointment.StartTime.Date == todayDate
            && x.Status == status
            && x.ClinicId == ApplicationState.CurrentUser.ClinicId)
            .ToListAsync();


        var data = mapper.Map<List<WaitingPatientDto>>(appointments);
        return data;
    }
    public async Task<List<WaitingPatientDto>> GetAllWaitingPatients()
    {
        var todayDate = DateTime.Now.Date;
        var appointments = await context.WaitingAppointments
            .Include(x => x.Appointment)
            .Include(x => x.Patient)
            .Include(x => x.Patient.PatientAccount)
            .Where(x => x.ClinicId == ApplicationState.CurrentUser.ClinicId 
            && x.Appointment.StartTime.Date == todayDate)
            .ToListAsync();


        var data = mapper.Map<List<WaitingPatientDto>>(appointments);
        return data;
    }
    public async Task<IResult> UpdateWaitingAppointment(int appointmentId, string status)
    {
        var appointment = await context.WaitingAppointments
            .FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
        if (appointment is null)
        {
            return await Result.FailAsync("Appointment is not found.");
        }

        appointment.Status = status;
        context.ChangeTracker.Clear();
        context.WaitingAppointments.Update(appointment);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment has been updated.");
    }

    private async Task AddExpectedPatients()
    {
        var list = new List<WaitingAppointment>();
        var todayDate = DateTime.Now.Date;
        var appointments = await context.Appointments
            .Where(x => x.StartTime.Date == todayDate && x.Status == AppointmentConstants.Status.Active)
            .ToListAsync();
        foreach (var item in appointments)
        {
            var waitingAppointment =
                await context.WaitingAppointments
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.AppointmentId == item.Id);
            if (waitingAppointment is null)
            {
                var waitAppt = new WaitingAppointment()
                {
                    PatientId = item.PatientId,
                    AppointmentId = item.Id,
                    ClinicId = ApplicationState.CurrentUser.ClinicId,
                    Status = AppointmentConstants.WaitingStatus.Expected
                };
                list.Add(waitAppt);
            }

        }

        await context.WaitingAppointments.AddRangeAsync(list);
        await context.SaveChangesAsync();
    }


}