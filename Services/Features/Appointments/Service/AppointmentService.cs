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
    public async Task<IResult<AppointmentDto>> GetAppointment(Guid id)
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
            .Where(x => x.ClinicId == ApplicationState.Auth.CurrentUser.ClinicId)
            .AsNoTracking()
            .ToListAsync();
        return mapper.Map<List<SearchAppointmentDto>>(data);
    }

    public async Task<List<AppointmentHistoryDto>> GetAppointmentHistory(Guid patientId)
    {
        var list = await context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.Hcp)
            .Include(x => x.AppointmentType)
            .Where(x => x.PatientId == patientId
                        && x.StartTime < DateTime.Now)
            .ToListAsync();
        var data = mapper.Map<List<AppointmentHistoryDto>>(list);
        return data;
    }

   

    public async Task<IResult> SaveAppointment(Guid id, AppointmentDto request)
    {
        try
        {
            if (id == Guid.Empty)
            {
                if (await IsSlotAvaiable(request.StartTime, request.HcpId))
                {
                    return await Result.FailAsync("Slot already booked.");
                }

                var appointment = new Appointment();
                appointment.Subject = $"{request.PatientName}, {request.Type}";
                appointment.CreatedBy = ApplicationState.Auth.CurrentUser.UserId;
                appointment.ClinicSiteId = request.ClinicSiteId;
                appointment.ClinicId = ApplicationState.Auth.CurrentUser.ClinicId;
                appointment.CreatedDate = DateTime.Now;
                appointment.StartTime = request.StartTime;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
                appointment.PatientId = request.PatientId;
                appointment.HcpId = request.HcpId;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                appointment.Duration = request.Duration;
                appointment.Description = request.Description;
                appointment.Status = request.Status;
                appointment.RecurrenceRule = request.RecurrenceRule;
                appointment.RecurrenceException = request.RecurrenceException;
                appointment.RecurrenceID = request.RecurrenceID;
                appointment.Location = request.Location;
                appointment.Status = AppointmentConstants.Status.Active;
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
                appointment.ModifiedBy = ApplicationState.Auth.CurrentUser.UserId;
                appointment.ModifiedDate = DateTime.Now;
                appointment.StartTime = request.StartTime;
                appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
                appointment.PatientId = request.PatientId;
                appointment.HcpId = request.HcpId;
                appointment.AppointmentTypeId = request.AppointmentTypeId;
                appointment.Duration = request.Duration;
                appointment.Description = request.Description;
                appointment.Status = AppointmentConstants.Status.Active;
                appointment.RecurrenceRule = request.RecurrenceRule;
                appointment.RecurrenceException = request.RecurrenceException;
                appointment.RecurrenceID = request.RecurrenceID;
                context.Appointments.Update(appointment);
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
            return await Result.SuccessAsync("Appointment Saved");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteAppointmentSeries(Guid id)
    {
        var appointments =
            await context.Appointments
                .Where(x => x.CustomRecurrenceId == id && x.IsSeries)
                .ToListAsync();
        
        context.Appointments.RemoveRange(appointments);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment series has been deleted");
    }

    public async Task<IResult> CancelAppointment(Guid appointmentId, int cancelReasonId)
    {
        try
        {
            var appointment = await context.Appointments.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == appointmentId);
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
                          || evt.RecurrenceRule != null && evt.ClinicId == ApplicationState.Auth.CurrentUser.ClinicId
            )
            .AsNoTracking()
            .ToListAsync();
        return mapper.Map<List<AppointmentDto>>(data);
    }


    public async Task<IResult> CreateAppointment(AppointmentDto request)
    {
        var appointment = mapper.Map<Appointment>(request);
        appointment.EndTime = request.StartTime.AddMinutes(request.Duration);
        appointment.ClinicId = ApplicationState.Auth.CurrentUser.ClinicId;
        appointment.CreatedBy = ApplicationState.Auth.CurrentUser.UserId;
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
            appointment.ModifiedBy = ApplicationState.Auth.CurrentUser.UserId;
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

    public async Task DeleteAppointment(Guid appointmentId)
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

    public async Task<List<AppointmentSlotDto>> GetAllFreeSlots()
    {
        var slots = await context.AppointmentSlots.OrderBy(x => x.StartTime)
            .Where(x => x.HcpId == ApplicationState.Auth.CurrentUser.UserId).ToListAsync();
        return mapper.Map<List<AppointmentSlotDto>>(slots);
    }

    public async Task<List<AppointmentSlotDto>> GetFreeSlots(DateTime startDate, DateTime endDate, Guid hcpId,
        int duration)
    {
        var hcp = await context.Users.FirstOrDefaultAsync(x => x.Id == hcpId);
        var startHour = hcp.StartHour;
        var endHour = hcp.EndHour;

        // Get working days and hours for the doctor
        var workingDays = GetWorkingDays(hcp.WorkingDays);

        var freeSlots = new List<AppointmentSlotDto>();

        // Get appointments for the doctor between start and end dates
        var appointments = GetAppointments(hcpId, startDate, endDate);

        // Loop through each day between start and end dates
        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            // Check if the day is a working day
            if (workingDays.Contains(date.DayOfWeek))
            {
                // Get the start and end time for the hour
                var startTime = date.AddHours(startHour.Hours);
                var endTime = date.AddHours(endHour.Hours);

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
                        {StartTime = date, EndTime = date.AddMinutes(duration), IsAvailable = true});
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

    public async Task<IResult> AddRecurrenceEventsSlot(List<DateTime> recurrencDates, DateTime startDate, Guid hcpId)
    {
        var slots = new List<AppointmentSlotDto>();
        foreach (var item in recurrencDates)
        {
            var time = startDate.TimeOfDay;
            var s = item.Date.Add(time);
            var available = !await IsSlotAvaiable(s, hcpId);
            var evnt = new AppointmentSlotDto()
            {
                StartTime = s,
                IsAvailable = available,
                HcpId = ApplicationState.Auth.CurrentUser.UserId,
            };
            slots.Add(evnt);
        }

        context.ChangeTracker.Clear();
        var slotList = mapper.Map<List<AppointmentSlot>>(slots);
        await context.AppointmentSlots.AddRangeAsync(slotList);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Slots Added.");
    }

    public async Task<IResult> ClearRecurrenceEventsSlots()
    {
        context.ChangeTracker.Clear();
        context.AppointmentSlots.RemoveRange(context.AppointmentSlots.AsNoTracking()
            .Where(x => x.HcpId == ApplicationState.Auth.CurrentUser.UserId));
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Slots Cleared");
    }

    public async Task<IResult> SelectFreeSlot(Guid id, DateTime startDate)
    {
        var slotInDb =
            await context.AppointmentSlots.FirstOrDefaultAsync(x =>
                x.Id == id && x.HcpId == ApplicationState.Auth.CurrentUser.UserId);
        if (slotInDb == null) return await Result.FailAsync("Slot not found");
        slotInDb.StartTime = startDate;
        slotInDb.IsAvailable = true;
        context.ChangeTracker.Clear();
        context.AppointmentSlots.Update(slotInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Appointment Slot Updated");
    }

    public async Task<IResult> AddRecurrenceEvents(List<AppointmentSlotDto> appointments, AppointmentDto appointment)
    {
        var recId = Guid.NewGuid();
        try
        {
            var isAllSlotSelected = await context.AppointmentSlots.AsNoTracking()
                .AnyAsync(x => x.IsAvailable == false && x.HcpId == ApplicationState.Auth.CurrentUser.UserId);

            if (isAllSlotSelected)
            {
                return await Result.FailAsync("Please select a slot");
            }

            foreach (var item in appointments)
            {
                var a = new Appointment()
                {
                    StartTime = item.StartTime,
                    EndTime = item.StartTime.AddMinutes(appointment.Duration),
                    PatientId = appointment.PatientId,
                    HcpId = appointment.HcpId,
                    ClinicSiteId = appointment.ClinicSiteId,
                    AppointmentTypeId = appointment.AppointmentTypeId,
                    ClinicId = ApplicationState.Auth.CurrentUser.ClinicId,
                    Status = AppointmentConstants.Status.Active,
                    Duration = appointment.Duration,
                    Location = appointment.Location,
                    Subject = $"{appointment.PatientName}, {appointment.Type}",
                    CreatedBy = ApplicationState.Auth.CurrentUser.UserId,
                    CreatedDate = DateTime.Now,
                    Description = appointment.Description,
                    IsSeries = true,
                    CustomRecurrenceId = recId
                };
                await context.Appointments.AddAsync(a);

                await context.SaveChangesAsync();
            }

            return await Result.SuccessAsync("Appointment has been scheduled");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }
}