using FluentValidation;

namespace Application.Timer.Commands.SetCountdown;

public class SetCountdownCommandValidator : AbstractValidator<SetCountdownCommand>
{
    public SetCountdownCommandValidator()
    {
        RuleFor(o => o.TimeInMinutes).GreaterThan(0);
    }
}