using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Application.Exeption.CustomeExeption;

namespace Application.Identity.Commands.AddClaims;

public class AddRoleWithClaimsCommandHandler : IRequestHandler<AddRoleWithClaimsCommand>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public AddRoleWithClaimsCommandHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<Unit> Handle(AddRoleWithClaimsCommand request, CancellationToken cancellationToken)
    {
        var role = new IdentityRole(request.RoleName);

        var admin = await _roleManager.CreateAsync(role);
        if (!admin.Succeeded)
        {
            var errorDescriptions = admin.Errors.Select(error => error.Description).ToArray();
            throw new PermitionException(errorDescriptions, role.Name);
        }

        var claims = request.Policies.Select(policy => new Claim("Permission", policy));

        foreach (var claim in claims)
        {
            var result = await _roleManager.AddClaimAsync(role, claim);
            if (!result.Succeeded)
            {
                throw new PermitionException(result.Errors.Select(error => error.Description).ToArray(), claim.Value);
            }
        }

        return Unit.Value;
    }
}