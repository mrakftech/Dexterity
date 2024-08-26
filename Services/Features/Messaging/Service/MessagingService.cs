using AutoMapper;
using ClickATell.Requests;
using ClickATell.Services;
using Database;
using Domain.Entities.Messaging.UserTasks;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Options;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using Services.Features.Messaging.Dtos.Sms;
using Services.Features.Messaging.Dtos.UserTasks;
using Services.State;
using Shared.Constants.Application;
using Shared.Constants.Module;
using Shared.Helper;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public class MessagingService(ApplicationDbContext context, IMapper mapper, SmsEndpoints smsEndpoints)
    : IMessagingService
{
    #region User Tasks

    public async Task<List<UserTask>> GetUserTasksByPatient(Guid patientId)
    {
        return await context.UserTasks
            .Where(x => x.PatientId == patientId)
            .OrderByDescending(x => x.TaskDate)
            .ToListAsync();
    }

    public async Task<List<UserTask>> GetUserTaskList(string view = UserTaskConstants.All)
    {
        var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        return view switch
        {
            UserTaskConstants.All => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.AssignedBy)
                .ToListAsync(),
            UserTaskConstants.DayView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Where(x => x.TaskDate.Date == DateTime.Today.Date)
                .Include(x => x.AssignedBy)
                .ToListAsync(),

            UserTaskConstants.WeekView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.TaskDate.Date < startOfWeek.AddDays(7) &&
                            x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.AssignedBy)
                .ToListAsync(),
            UserTaskConstants.MonthView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.TaskDate.Date.Month == DateTime.Today.Date.Month &&
                            x.ClinicId == ApplicationState.CurrentUser.ClinicId)
                .Include(x => x.AssignedBy)
                .ToListAsync(),

            _ => await context.UserTasks.Where(x => x.UserId == ApplicationState.CurrentUser.UserId)
                .Include(x => x.AssignedBy).ToListAsync(),
        };
    }

    public async Task<IResult> SaveTask(Guid id, UserTaskDto dto)
    {
        if (id == Guid.Empty)
        {
            var healthCares = dto.SelectedHealthCares.ToList();

            var task = mapper.Map<UserTask>(dto);
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.Now;
            task.ClinicId = ApplicationState.CurrentUser.ClinicId;

            if (healthCares.Count == 0)
            {
                //Personal Tasks
                task.UserId = ApplicationState.CurrentUser.UserId;
                await context.UserTasks.AddAsync(task);
            }
            else
            {
                //Assigning Task to others
                foreach (var item in healthCares)
                {
                    task.UserId = item.Id;
                    task.AssignedById = ApplicationState.CurrentUser.UserId;
                    await context.UserTasks.AddAsync(task);
                }
            }

            await context.SaveChangesAsync();
        }
        else
        {
            var taskInDb = await context.UserTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (taskInDb == null)
                return await Result.FailAsync("Task not found.");

            taskInDb = mapper.Map(dto, taskInDb);
            context.UserTasks.Update(taskInDb);
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Task has been saved.");
    }

    public async Task<IResult> UpdateTaskStatus(Guid id, string status)
    {
        var taskInDb = await context.UserTasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (taskInDb == null)
            return await Result.FailAsync("Task not found.");
        taskInDb.Status = status;
        context.UserTasks.Update(taskInDb);
        await context.SaveChangesAsync();
        context.Entry(taskInDb).State = EntityState.Detached;
        return await Result.SuccessAsync("Task has been updated.");
    }

    public async Task<UserTaskDto> GetTask(Guid id)
    {
        var taskInDb = await context.UserTasks.Include(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        var s = mapper.Map<UserTaskDto>(taskInDb);
        return s;
    }

    public async Task<IResult> DeleteTask(Guid id)
    {
        var taskInDb = await context.UserTasks.FirstOrDefaultAsync(x => x.Id == id);
        if (taskInDb == null)
            return await Result.FailAsync("Task not found.");
        context.UserTasks.Remove(taskInDb);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync("Task has been deleted.");
    }

    #endregion

    #region Messaging

    public async Task<IResult> SendBulkSms(BulkSmsDto request)
    {
        try
        {
            var sendRequest = new SmsRequest()
            {
                Content = request.Content,
                To = request.Patients.Select(x => x.MobilePhone).ToList()
            };
            var res = await smsEndpoints.SendMessage(sendRequest);
            if (res.ResponseCode == 202)
            {
                foreach (var item in request.Patients)
                {
                    var smsHistory = new SmsHistory()
                    {
                        Date = DateTime.Now,
                        PatientId = item.Id,
                        Mobile = item.MobilePhone,
                        Content = request.Content
                    };
                    await context.PatientSmsHistories.AddAsync(smsHistory);
                }

                await context.SaveChangesAsync();
                await Result.SuccessAsync();
            }
            else
            {
                return await Result.FailAsync(res.Messages.First().ErrorDescription.ToString());
            }
        }
        catch (Exception e)
        {
            await Result.FailAsync(e.Message);
        }

        return await Result.FailAsync();
    }

    public async Task<IResult> SendSms(SendMessageDto request)
    {
        try
        {
            var util = PhoneNumberUtil.GetInstance();
            var s = util.Parse(request.Mobile, ApplicationConstants.AppRegion);
            var n = util.Format(s, PhoneNumberFormat.E164);
            var sendRequest = new SmsRequest()
            {
                Content = request.Content,
                To = [n]
            };
            var res = await smsEndpoints.SendMessage(sendRequest);
            if (res.ResponseCode == 202)
            {
                var smsHistory = new SmsHistory()
                {
                    Date = DateTime.Now,
                    Mobile = request.Mobile,
                    PatientId = request.PatientId,
                    Content = request.Content
                };
                await AddMessageInPatietnHistory(smsHistory);
                await Result.SuccessAsync();
            }
            else
            {
                return await Result.FailAsync(res.Messages.First().ErrorDescription.ToString());
            }
        }
        catch (Exception e)
        {
            await Result.FailAsync(e.Message);
        }

        return await Result.FailAsync("Something went wrong.");
    }

    public async Task<List<SmsHistory>> GetSmsHistory(Guid patientId)
    {
        return await context.PatientSmsHistories.Where(x => x.PatientId == patientId)
            .ToListAsync();
    }

    public async Task<List<SmsHistory>> GetSmsHistory(Guid patientId, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SmsHistory>> FilterSmsHistory(Guid patientId, DateTime from, DateTime to)
    {
        return await context.PatientSmsHistories
            .Where(x => x.PatientId == patientId && x.Date >= from && x.Date <= to)
            // .Where(m => m.Content.Contains(message, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<IResult> AddMessageInPatietnHistory(SmsHistory smsHistory)
    {
        await context.PatientSmsHistories.AddAsync(smsHistory);
        await context.SaveChangesAsync();
        return await Result.SuccessAsync();
    }

    #endregion
}