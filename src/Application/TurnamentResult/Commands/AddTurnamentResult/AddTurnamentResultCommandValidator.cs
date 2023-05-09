using FluentValidation;

namespace Application.TurnamentResult.Commands.AddTurnamentResult;

public class AddTurnamentResultCommandValidator : AbstractValidator<AddTurnamentResultCommand>
{
	public AddTurnamentResultCommandValidator()
	{
		RuleFor(o => o.FullName);
        RuleFor(o => o.PersonalNumber);
    }
}