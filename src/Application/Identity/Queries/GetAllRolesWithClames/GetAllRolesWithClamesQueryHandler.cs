using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Queries.GetAllRolesWithClames;

public class GetAllRolesWithClamesQueryHandler : IRequestHandler<GetAllRolesWithClamesQuery, Dictionary<string, string[]>>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public GetAllRolesWithClamesQueryHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<Dictionary<string, string[]>> Handle(GetAllRolesWithClamesQuery request, CancellationToken cancellationToken)
    {
        var result = new Dictionary<string, string[]>();
        
        var roles = _roleManager.Roles.ToList();

        foreach (var role in roles)
        {
            var claims = await _roleManager.GetClaimsAsync(role);
            result.Add(role?.Name, claims?.Select(o => o?.Value).ToArray());
        }

        return result;
    }
}