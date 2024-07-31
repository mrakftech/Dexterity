using AutoMapper;
using Database;
using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Microsoft.EntityFrameworkCore;
using Services.Features.Appointments.Dtos;
using Services.State;
using Shared.Constants.Application;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public class AppointmentService(ApplicationDbContext context, IMapper mapper) : IAppointmentService
{
    public async Task<IResult<AppointmentDto>> GetAppointment(int id)
    {
        var appointment = await context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.AppointmentType)
            .Include(x => x.ClinicSite)
            .FirstOrDefaultAsync(x => x.Id == id);
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
                appointment.Subject = $"{request.PatientName}, {request.Type}";
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
                var appointment = await context.Appointments
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (appointment == null) return await Result.FailAsync("Appointment not found.");

                appointment.Subject = $"{request.PatientName}, {request.Type}";
                appointment.ModifiedBy = ApplicationState.CurrentUser.UserId;
                appointment.ModifiedDate = DateTime.Now;
                appointment.StartTime = request.StartTime;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration); ;
                appointment.PatientId = request.PatientId;
                appointment.HcpId = request.HcpId;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                appointment.Duration = request.Duration;
                appointment.Status = request.Status;
                appointment.RecurrenceRule = request.RecurrenceRule;
                appointment.RecurrenceException = request.RecurrenceException;
                appointment.RecurrenceID = request.RecurrenceID;
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

    public async Task<List<AppointmentDto>> GetAllAppointments(DateTime StartDate, DateTime EndDate)
    {
        var data = await context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.AppointmentType)
             .Where(evt => evt.StartTime >= StartDate
             && evt.EndTime <= EndDate
             || evt.RecurrenceRule != null
             )
             .AsNoTracking()
             .ToListAsync();
        return mapper.Map<List<AppointmentDto>>(data);
    }

    public async Task<IResult> CreateAppointment(AppointmentDto request)
    {
        var appointment = mapper.Map<Appointment>(request);
        appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
        appointment.ClinicId = ApplicationState.CurrentUser.ClinicId;
        appointment.CreatedBy = ApplicationState.CurrentUser.UserId;
        appointment.CreatedDate = DateTime.Now;
        appointment.Status = AppointmentConstants.Status.Active;
        context.ChangeTracker.Clear();
        await context.Appointments.AddAsync(appointment);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Created");

    }

    public async Task<IResult> UpdateAppointment(AppointmentDto request)
    {
        var appointmentInDb = await context.Appointments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

        if (appointmentInDb == null)
            return await Result<AppointmentDto>.FailAsync("Appointment not found");

        var appointment = mapper.Map<Appointment>(request);
        appointment.EndTime = request.StartTime.AddMinutes(request.Duration); ;
        appointment.ModifiedBy = ApplicationState.CurrentUser.UserId;
        appointment.ModifiedDate = DateTime.Now;
        context.ChangeTracker.Clear();
        context.Appointments?.Update(appointment);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Updated");

    }

    public async Task<IResult> DeleteAppointment(int appointmentId)
    {
        var appointmentInDb = await context.Appointments.FirstOrDefaultAsync(x => x.Id == appointmentId);

        if (appointmentInDb == null)
            return await Result<AppointmentDto>.FailAsync("Appointment not found");

        context.Appointments.Remove(appointmentInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Deleted");

    }
}