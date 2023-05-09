using FluentValidation;

namespace Application.TurnamentResult.Commands.EditTurnamentResult;

public class EditTurnamentResultCommandValidator : AbstractValidator<EditTurnamentResultCommand>
{
	public EditTurnamentResultCommandValidator()
	{
		RuleFor(o => o.Id).GreaterThan(0);
	}
}