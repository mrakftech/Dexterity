using FluentValidation;
using Shared.Requests.UserAccounts;

namespace Dexterity.Validators.UserManager;

public class UserValidator : AbstractValidator<CreateUserRequest>
{
    public UserValidator()
    {
        
    }
}