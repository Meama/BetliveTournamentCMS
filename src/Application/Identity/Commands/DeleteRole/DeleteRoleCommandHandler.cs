using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByNameAsync(request.Role);
        await _roleManager.DeleteAsync(role);

        return Unit.Value;
    }
}