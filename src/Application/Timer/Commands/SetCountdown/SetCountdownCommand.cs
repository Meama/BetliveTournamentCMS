using MediatR;

namespace Application.Timer.Commands.SetCountdown;

public class SetCountdownCommand : IRequest
{
    public int TimeInMinutes { get; set; }
}