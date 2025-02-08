using AutoMapper;
using Domain.Entities.UserAccounts;
using Services.Features.UserAccounts.Dtos.User;

namespace Services.Features.UserAccounts.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, HealthcareDto>()
            .ForMember(d => d.Name, s => s.MapFrom(x => x.FullName))
            .ForMember(d => d.StartHour, s => s.MapFrom(x => x.StartHour.ToString("hh\\:mm")))
            .ForMember(d => d.EndHour, s => s.MapFrom(x => x.EndHour.ToString("hh\\:mm")))
            .ForMember(d => d.WorkingDays, s => s.MapFrom(x => x.WorkingDays.ToArray()))
            .ReverseMap();

        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UserResponseDto>()
            .ForMember(d => d.UserType, s => s.MapFrom(x => x.UserType.Name))
            .ReverseMap();
        CreateMap<CreateUserDto, UserResponseDto>().ReverseMap();
        CreateMap<Role, RoleResponseDto>().ReverseMap();
        CreateMap<PermissionClaim, PermissionResponseDto>().ReverseMap();
    }
}