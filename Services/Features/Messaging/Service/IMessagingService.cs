using Domain.Entities.Messaging;
using Services.Contracts.Repositroy;
using Shared.Requests.Messaging.UserTasks;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public interface IMessagingService
{
    #region User Task
    public IQueryable<UserTask> GetUserTaskList();
    public Task<IResult> SaveTask(Guid id, UpsertUserTaskRequest request);
    public Task<IResult> DeleteTask(Guid id);

    #endregion
}