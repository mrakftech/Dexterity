using Database;
using Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Messaging.UserTasks;
using Shared.State;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public class MessagingService(ApplicationDbContext context)
    : IMessagingService
{
    
    
    #region User Tasks

    public IQueryable<UserTask> GetUserTaskList()
    {
        return context.UserTasks.AsQueryable();
    }

    public async Task<IResult> SaveTask(Guid id, UpsertUserTaskRequest request)
    {
        if (id == Guid.Empty)
        {
            var task = new UserTask()
            {
                Id = Guid.NewGuid(),
                Subject = request.Subject,
                TaskDate = DateOnly.FromDateTime(DateTime.Today),
                Description = request.Description,
                IsActive = request.IsActive,
                UserId = ApplicationState.CurrentUser.UserId,
            };
            await context.UserTasks.AddAsync(task);
            await context.SaveChangesAsync();
        }
        else
        {
            var taskInDb = await context.UserTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (taskInDb == null)
                return await Result.FailAsync("Task not found.");

            taskInDb.TaskDate = request.TaskDate;
            taskInDb.Subject = request.Subject;
            taskInDb.Description = request.Description;
            taskInDb.IsActive = request.IsActive;
            context.UserTasks.Update(taskInDb);
            await context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Task has been saved.");
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