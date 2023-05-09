using MediatR;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleFromUserCommand : IRequest
{
    public string Email { get; set; }

    public string Role { get; set; }
}