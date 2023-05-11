using MediatR;

namespace Application.Identity.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest
{
    public string Email { get; set; }

    public string NewPassword { get; set; }
}