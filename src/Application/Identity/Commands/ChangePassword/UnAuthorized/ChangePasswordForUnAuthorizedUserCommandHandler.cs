using MediatR;
using Infrastructure.Email.Abstraction;

namespace Application.Identity.Commands.ChangePassword.UnAuthorized;

public class ChangePasswordForUnAuthorizedUserCommandHandler : IRequestHandler<ChangePasswordForUnAuthorizedUserCommand>
{
    private readonly IMailService _emailSender;
    private readonly IMediator _mediator;

    public ChangePasswordForUnAuthorizedUserCommandHandler(IMailService emailSender, IMediator mediator)
    {
        _mediator = mediator;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(ChangePasswordForUnAuthorizedUserCommand request, CancellationToken cancellationToken)
    {
        var password = Guid.NewGuid().ToString();
        await _mediator.Send(new ChangePasswordCommand
        {
            Email = request.Email,
            NewPassword = password
        }, cancellationToken);

        await _emailSender.SendEmailAsync($"Password was changed new Password is {password}", request.Email, "Password change", cancellationToken);

        return Unit.Value;
    }
}