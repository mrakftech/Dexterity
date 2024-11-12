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
    public async Task<IResult<AppointmentDto>> GetAppointment(int id)
    {
        var appointment = await context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.AppointmentType)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (appointment == null)
            return await Result<AppointmentDto>.FailAsync("Appointment not found");
        var data = mapper.Map<AppointmentDto>(appointment);
        return await Result<AppointmentDto>.SuccessAsync(data);
    }

    public async Task<List<SearchAppointmentDto>> FindAppointments()
    {
        var data = await context.Appointments
            .Include(x => x.Patient)
            .Where(x => x.ClinicId == ApplicationState.CurrentUser.ClinicId)
            .AsNoTracking()
            .ToListAsync();
        return mapper.Map<List<SearchAppointmentDto>>(data);
    }

    public async Task<List<AppointmentHistoryDto>> GetAppointmentHistory(Guid patientId)
    {
        var list = await context.Appointments
            .Include(x=>x.Patient)
            .Include(x=>x.Hcp)
            .Include(x=>x.AppointmentType)
            .Where(x => x.PatientId == patientId
                        && x.StartTime < DateTime.Now)
            .ToListAsync();
        var data = mapper.Map<List<AppointmentHistoryDto>>(list);
        return data;
    }

    public async Task<IResult> SaveAppointment(int id, AppointmentDto request)
    {
        try
        {
            if (id == 0)
            {
                if (await IsSlotAvaiable(request.StartTime, request.HcpId))
                {
                    return await Result.FailAsync("Slot already booked.");
                }

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
                if (context.Appointments.Any(x =>
                        x.StartTime == request.StartTime && x.HcpId == request.HcpId && x.Id != appointment.Id))
                {
                    return await Result.FailAsync("Slot already booked.");
                }

                if (appointment == null) return await Result.FailAsync("Appointment not found.");

                appointment.Subject = $"{request.PatientName}, {request.Type}";
                appointment.ModifiedBy = ApplicationState.CurrentUser.UserId;
                appointment.ModifiedDate = DateTime.Now;
                appointment.StartTime = request.StartTime;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
                ;
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
                          || evt.RecurrenceRule != null && evt.ClinicId == ApplicationState.CurrentUser.ClinicId
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

    public async Task UpdateAppointment(AppointmentDto request)
    {
        var appointment = await context.Appointments
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (appointment != null)
        {
            appointment.ModifiedBy = ApplicationState.CurrentUser.UserId;
            appointment.ModifiedDate = DateTime.Now;
            appointment.StartTime = request.StartTime;
            appointment.EndTime = request.EndTime;
            appointment.HcpId = request.HcpId;
            appointment.Duration = request.Duration;
            appointment.RecurrenceRule = request.RecurrenceRule;
            appointment.RecurrenceException = request.RecurrenceException;
            appointment.RecurrenceID = request.RecurrenceID;
            context.ChangeTracker.Clear();
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        var appointmentInDb = await context.Appointments
            .FirstOrDefaultAsync(x => x.Id == appointmentId);

        if (appointmentInDb != null)
        {
            context.ChangeTracker.Clear();
            context.Appointments.Remove(appointmentInDb);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> IsSlotAvaiable(DateTime date, Guid hcpId)
    {
        return await context.Appointments.AnyAsync(x => x.StartTime == date && x.HcpId == hcpId);
    }

    public async Task<List<AppointmentSlotDto>> GetFreeSlots(DateTime startDate, DateTime endDate, Guid hcpId)
    {
        var hcp = await context.Users.FirstOrDefaultAsync(x => x.Id == hcpId);
        // Get working days and hours for the doctor
        var workingDays = GetWorkingDays(hcp.WorkingDays);

        List<AppointmentSlotDto> freeSlots = new List<AppointmentSlotDto>();


        // Get appointments for the doctor between start and end dates
        var appointments = GetAppointments(hcpId, startDate, endDate);

        // Loop through each day between start and end dates
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            // Check if the day is a working day
            if (workingDays.Contains(date.DayOfWeek))
            {
                // Get the start and end time for the hour
                var startTime = date.AddHours(hcp.StartHour.Hours);
                var endTime = date.AddHours(hcp.EndHour.Hours);

                // Check if there are any appointments during this hour
                var isFree = true;
                foreach (var appointment in appointments)
                {
                    if (appointment.StartTime < endTime && appointment.EndTime > startTime)
                    {
                        isFree = false;
                        break;
                    }
                }

                // If the hour is free, add it to the list of free slots
                if (isFree)
                {
                    freeSlots.Add(new AppointmentSlotDto()
                        {StartTime = startDate, EndTime = endDate, IsAvailable = true});
                }
            }
        }

        return freeSlots;
    }

    private List<Appointment> GetAppointments(Guid hcpId, DateTime startDate, DateTime endDate)
    {
        var appts = context.Appointments
            .Where(a => a.HcpId == hcpId
                        && a.StartTime >= startDate
                        && a.EndTime <= endDate).ToList();
        return appts;
    }

    private List<DayOfWeek> GetWorkingDays(List<int> days)
    {
        List<DayOfWeek> workingDays = new List<DayOfWeek>();

        foreach (var day in days)
        {
            var workingDay = (DayOfWeek) day;
            workingDays.Add(workingDay);
        }

        return workingDays;
    }

    public async Task<IResult> SaveAppointmentList(Appointment appointment)
    {
        try
        {
            context.ChangeTracker.Clear();
            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Appointment has been scheduled");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }
}