using FluentValidation;

namespace Application.TurnamentResult.Commands.AddTurnamentResult;

public class AddTurnamentResultCommandValidator : AbstractValidator<AddTurnamentResultCommand>
{
	public AddTurnamentResultCommandValidator()
	{
		RuleFor(o => o.FullName).NotNull().NotEmpty();
        RuleFor(o => o.PersonalNumber).NotNull().NotEmpty();
    }
}