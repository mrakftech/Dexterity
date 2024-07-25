using AutoMapper;
using Domain.Entities.Messaging;
using Domain.Entities.Messaging.UserTasks;
using Services.Features.Messaging.Dtos.UserTasks;

namespace Services.Features.Messaging.Mapping;

public class MessagingProfile : Profile
{
    public MessagingProfile()
    {
        CreateMap<UserTask, UserTaskDto>().ReverseMap();

    }
}