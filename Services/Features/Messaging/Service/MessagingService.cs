using AutoMapper;
using Database;
using Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Services.Features.Messaging.Dtos.UserTasks;
using Services.State;
using Shared.Constants.Module;
using Shared.Helper;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public class MessagingService(ApplicationDbContext context, IMapper mapper)
    : IMessagingService
{
    #region User Tasks

    public async Task<List<UserTask>> GetUserTaskList(string view = UserTaskConstants.All)
    {
        var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        return view switch
        {
            UserTaskConstants.All => await context.UserTasks.Where(x => x.UserId == ApplicationState.CurrentUser.UserId)
                .ToListAsync(),
            UserTaskConstants.DayView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId)
                .Where(x => x.TaskDate.Date == DateTime.Today.Date)
                .ToListAsync(),

            UserTaskConstants.WeekView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.TaskDate.Date < startOfWeek.AddDays(7))
                .ToListAsync(),
            UserTaskConstants.MonthView => await context.UserTasks
                .Where(x => x.UserId == ApplicationState.CurrentUser.UserId &&
                            x.TaskDate.Date.Month == DateTime.Today.Date.Month)
                .ToListAsync(),

            _ => await context.UserTasks.Where(x => x.UserId == ApplicationState.CurrentUser.UserId).ToListAsync(),
        };
    }

    public async Task<IResult> SaveTask(Guid id, UserTaskDto dto)
    {
       // var hcps = dto.SelectedHealthCares.Select(x => x.Id).ToList();

        if (id == Guid.Empty)
        {
            var task = mapper.Map<UserTask>(dto);
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.Now;
            task.UserId = ApplicationState.CurrentUser.UserId;

            await context.UserTasks.AddAsync(task);
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
}