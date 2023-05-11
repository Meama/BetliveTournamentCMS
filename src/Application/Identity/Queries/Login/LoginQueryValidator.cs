using FluentValidation;
using Application.Identity.Commands.AddUser;

namespace Application.Identity.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
    {
        RuleFor(o => o.Password).NotNull().NotEmpty();
        RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
    }
}