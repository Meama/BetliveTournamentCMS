using FluentValidation;

namespace Application.Identity.Commands.AddRoleToUser;

public class AddRoleToUserCommandValidator : AbstractValidator<AddRoleToUserCommand>
{
	public AddRoleToUserCommandValidator()
	{
        RuleFor(o => o.Role).NotNull().NotEmpty();
        RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
    }
}