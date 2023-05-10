using FluentValidation;

namespace Application.Identity.Commands.EditUserName;

public class EditUserNameCommandValidator : AbstractValidator<EditUserNameCommand>
{
	public EditUserNameCommandValidator()
	{
        RuleFor(o => o.LastName).NotNull().NotEmpty();
        RuleFor(o => o.FirstName).NotNull().NotEmpty();
        RuleFor(o => o.Email).NotNull().NotEmpty().EmailAddress();
    }
}