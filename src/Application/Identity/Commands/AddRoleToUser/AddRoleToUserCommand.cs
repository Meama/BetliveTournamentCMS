using MediatR;

namespace Application.Identity.Commands.AddRoleToUser;

public class AddRoleToUserCommand : IRequest
{
    public string Role { get; set; }

    public string Email { get; set; }
}