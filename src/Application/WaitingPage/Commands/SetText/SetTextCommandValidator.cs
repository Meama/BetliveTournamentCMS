using FluentValidation;

namespace Application.WaitingPage.Commands.SetText;

public class SetTextCommandValidator : AbstractValidator<SetTextCommand>
{
	public SetTextCommandValidator()
	{
		RuleFor(o => o.Text).NotNull().NotNull();
	}
}
