using Domain.Entities.UserAccounts;
using Services.Specifications;

namespace Services.Features.UserAccounts.Specifications;

public class UsersWithRolesSpecification : BaseSpecification<User>
{
    public UsersWithRolesSpecification(): base()
    {
       AddInclude(x=>x.Role); 
    }
    
    public UsersWithRolesSpecification(Guid id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Role);
    }
}