using FluentValidation;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleFromUserCommandValidator : AbstractValidator<DeleteRoleFromUserCommand>
{
	public DeleteRoleFromUserCommandValidator()
	{
		RuleFor(o => o.Role).NotNull().NotEmpty();
        RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
    }
}