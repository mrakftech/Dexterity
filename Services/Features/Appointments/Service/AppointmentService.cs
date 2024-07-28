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
    public async Task<List<GetAppointmentDto>> GetAppointments(string status = null)
    {
        if (string.IsNullOrWhiteSpace(status) || status == AppointmentConstants.Status.Active)
        {
            var appointments = await context.Appointments
                .Where(x => x.Status == AppointmentConstants.Status.Active && x.ClinicId==ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.Patient).ToListAsync();
            var list = mapper.Map<List<GetAppointmentDto>>(appointments);
            return list;
        }
        else
        {
            var appointments = await context.Appointments
                .Where(x => x.Status == AppointmentConstants.Status.Cancelled && x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.Patient).ToListAsync();
            var list = mapper.Map<List<GetAppointmentDto>>(appointments);
            return list;
        }

    }

    public async Task<List<GetAppointmentDto>> GetAppointmentsByHcp(Guid hcpId)
    {
        var appointments = await context.Appointments
            .Where(x => x.Status == AppointmentConstants.Status.Active && x.HcpId == hcpId && x.ClinicId == ApplicationState.CurrentUser.ClinicId)
            .Include(x => x.Patient).ToListAsync();
        var list = mapper.Map<List<GetAppointmentDto>>(appointments);
        return list;
    }

    public async Task<IResult<GetAppointmentDto>> GetAppointment(Guid id)
    {
        var appointment = await context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        if (appointment == null)
            return await Result<GetAppointmentDto>.FailAsync("Appointment not found");
        var data = mapper.Map<GetAppointmentDto>(appointment);
        return await Result<GetAppointmentDto>.SuccessAsync(data);

    }

    public async Task<IResult> SaveAppointment(Guid id, UpsertAppointmentDto request)
    {
        try
        {
            if (id == Guid.Empty)
            {
                var appointment = mapper.Map<Appointment>(request);
                appointment.Id = Guid.NewGuid();
                appointment.Id = request.Id;
                appointment.End = request.Start.AddMinutes(request.Duration);
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
                appointment.Start = request.Start;
                appointment.End = request.Start.AddMinutes(request.Duration); ;
                appointment.Color = request.Color;
                appointment.PatientId = request.PatientId;
                appointment.HcpId = request.HcpId;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                appointment.Duration = request.Duration;
                appointment.Status = request.Status;
                appointment.Title = request.Title;
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

    public async Task<IResult> CancelAppointment(Guid id, int cancelReasonId)
    {
        try
        {
            var appointment = await context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
            if (appointment == null)
                return await Result<GetAppointmentDto>.FailAsync("Appointment not found");
            appointment.Status = AppointmentConstants.Status.Cancelled;
            appointment.CancelReasonId = cancelReasonId;
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Appointment Cancelled");
        }
        catch (Exception e)
        {
            return await Result<GetAppointmentDto>.FailAsync(e.Message);
        }

    }
}