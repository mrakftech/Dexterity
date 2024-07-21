using AutoMapper;
using Domain.Entities.Messaging;
using Services.Features.Messaging.Dtos.UserTasks;

namespace Services.Features.Messaging.Mapping;

public class MessagingProfile : Profile
{
    public MessagingProfile()
    {
        CreateMap<UserTask, UserTaskDto>().ReverseMap();

    }
}