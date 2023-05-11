using FluentValidation;

namespace Application.Identity.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
	public ChangePasswordCommandValidator()
	{
        RuleFor(o => o.NewPassword).NotNull().NotEmpty();
        RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
    }
}