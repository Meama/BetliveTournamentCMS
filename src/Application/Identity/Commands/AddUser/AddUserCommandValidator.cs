using FluentValidation;

namespace Application.Identity.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
	public AddUserCommandValidator()
	{
		RuleFor(o => o.Password).NotNull().NotEmpty();
		RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
	}
}