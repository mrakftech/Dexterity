using AutoMapper;
using Domain.Entities.Messaging;
using Shared.Requests.Messaging.UserTasks;

namespace Services.Features.Messaging.Mapping;

public class MessagingProfile : Profile
{
    public MessagingProfile()
    {
        CreateMap<UserTask, UserTaskDto>().ReverseMap();

    }
}