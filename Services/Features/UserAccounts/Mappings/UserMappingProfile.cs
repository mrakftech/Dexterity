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
            .ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<CreateUserDto, UserResponseDto>().ReverseMap();
        CreateMap<Role, RoleResponseDto>().ReverseMap();
        CreateMap<PermissionClaim, PermissionResponseDto>().ReverseMap();
    }
}