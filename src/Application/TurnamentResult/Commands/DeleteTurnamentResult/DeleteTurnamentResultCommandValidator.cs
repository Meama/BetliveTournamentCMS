using FluentValidation;

namespace Application.TurnamentResult.Commands.DeleteTurnamentResult;

public class DeleteTurnamentResultCommandValidator : AbstractValidator<DeleteTurnamentResultCommand>
{
    public DeleteTurnamentResultCommandValidator()
    {
        RuleFor(o => o.Id).GreaterThan(0);
    }
}