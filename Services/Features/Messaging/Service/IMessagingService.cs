﻿using Domain.Entities.Messaging;
using Services.Contracts.Repositroy;
using Shared.Requests.Messaging.UserTasks;
using Shared.Wrapper;

namespace Services.Features.Messaging.Service;

public interface IMessagingService
{
    #region User Task
    public Task<List<UserTask>> GetUserTaskList(string view = "All");
    public Task<IResult> SaveTask(Guid id, UserTaskDto dto);
    public Task<UserTaskDto> GetTask(Guid id);
    public Task<IResult> DeleteTask(Guid id);

    #endregion
}