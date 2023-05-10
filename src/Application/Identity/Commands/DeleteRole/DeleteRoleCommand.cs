using MediatR;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public string Role { get; set; }
}