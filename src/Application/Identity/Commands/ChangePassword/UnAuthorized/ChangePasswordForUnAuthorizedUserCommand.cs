using MediatR;

namespace Application.Identity.Commands.ChangePassword.UnAuthorized;

public class ChangePasswordForUnAuthorizedUserCommand : IRequest
{
    public string Email { get; set; }
}