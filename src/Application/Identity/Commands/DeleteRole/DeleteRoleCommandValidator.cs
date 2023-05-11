using FluentValidation;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
	public DeleteRoleCommandValidator()
	{
		RuleFor(o => o.Role).NotNull().NotEmpty();
	}
}