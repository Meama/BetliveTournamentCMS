using FluentValidation;

namespace Application.TurnamentResult.Commands.AddListTurnamentResult;

public class AddListTurnamentResultCommandValidator : AbstractValidator<AddListTurnamentResultCommand>
{
	public AddListTurnamentResultCommandValidator()
	{
		RuleFor(o => o.TurnamentItems).NotNull().NotEmpty();
        RuleForEach(x => x.TurnamentItems).ChildRules(turnament =>
        {
            turnament.RuleFor(o => o.FullName).NotNull().NotEmpty();
            turnament.RuleFor(o => o.PersonalNumber).NotNull().NotEmpty();
        });
	}
}