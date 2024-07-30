using AutoMapper;
using Database;
using Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Services.Features.Appointments.Dtos;
using Services.State;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public class AppointmentService(ApplicationDbContext context, IMapper mapper) : IAppointmentService
{
    public async Task<List<AppointmentDto>> GetAppointments(string status = null)
    {
        if (string.IsNullOrWhiteSpace(status) || status == AppointmentConstants.Status.Active)
        {
            var appointments = await context.Appointments
                .Where(x => x.Status == AppointmentConstants.Status.Active && x.ClinicId==ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.Patient)
                .Include(x => x.AppointmentType)
                .ToListAsync();
            var list = mapper.Map<List<AppointmentDto>>(appointments);
            return list;
        }
        else
        {
            var appointments = await context.Appointments
                .Where(x => x.Status == AppointmentConstants.Status.Cancelled && x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.Patient).ToListAsync();
            var list = mapper.Map<List<AppointmentDto>>(appointments);
            return list;
        }

    }

    public async Task<List<AppointmentDto>> GetAppointmentsByHcp(Guid hcpId)
    {
        var appointments = await context.Appointments
            .Where(x => x.Status == AppointmentConstants.Status.Active && x.HcpId == hcpId && x.ClinicId == ApplicationState.CurrentUser.ClinicId)
            .Include(x => x.Patient).ToListAsync();
        var list = mapper.Map<List<AppointmentDto>>(appointments);
        return list;
    }

    public async Task<IResult<AppointmentDto>> GetAppointment(int id)
    {
        var appointment = await context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        if (appointment == null)
            return await Result<AppointmentDto>.FailAsync("Appointment not found");
        var data = mapper.Map<AppointmentDto>(appointment);
        return await Result<AppointmentDto>.SuccessAsync(data);

    }

    public async Task<IResult> SaveAppointment(int id, AppointmentDto request)
    {
        try
        {
            if (id == 0)
            {
                var appointment = mapper.Map<Appointment>(request);
                appointment.Id = request.Id;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
                appointment.ClinicId = ApplicationState.CurrentUser.ClinicId;
                appointment.CreatedDate = DateTime.Now;
                appointment.CreatedBy = ApplicationState.CurrentUser.UserId;
                appointment.Status = AppointmentConstants.Status.Active;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                await context.Appointments.AddAsync(appointment);
            }
            else
            {
                var appointment = await context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
                if (appointment == null) return await Result.FailAsync("Appointment not found.");
                appointment.ModifiedBy = ApplicationState.CurrentUser.UserId;
                appointment.ModifiedDate = DateTime.Now;
                appointment.StartTime = request.StartTime;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration); ;
                appointment.PatientId = request.PatientId;
                appointment.HcpId = request.HcpId;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                appointment.Duration = request.Duration;
                appointment.Status = request.Status;
                context.Appointments.Update(appointment);
            }
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Appointment Saved");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }

    }

    public async Task<IResult> CancelAppointment(int id, int cancelReasonId)
    {
        try
        {
            var appointment = await context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
            if (appointment == null)
                return await Result<AppointmentDto>.FailAsync("Appointment not found");
            appointment.Status = AppointmentConstants.Status.Cancelled;
            appointment.CancelReasonId = cancelReasonId;
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Appointment Cancelled");
        }
        catch (Exception e)
        {
            return await Result<AppointmentDto>.FailAsync(e.Message);
        }

    }
}