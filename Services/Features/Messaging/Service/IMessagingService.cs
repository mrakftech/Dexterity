using Domain.Entities.Messaging;
using Domain.Entities.Messaging.UserTasks;
using Services.Features.Messaging.Dtos.UserTasks;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public interface IMessagingService
{
    #region User Task
    public Task<List<UserTask>> GetUserTaskList(string view = "All");
    public Task<IResult> SaveTask(Guid id, UserTaskDto dto);
    public Task<IResult> UpdateTaskStatus(Guid id, string status);
    public Task<UserTaskDto> GetTask(Guid id);
    public Task<IResult> DeleteTask(Guid id);

    #endregion
}