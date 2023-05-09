using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(userId))
        {
            var user = await userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);
            if (user != null)
            {
                await SetClaimsToRequestAsync(httpContext, userManager, roleManager, user);
            }
        }

        await _next.Invoke(httpContext);
    }

    private static async Task SetClaimsToRequestAsync(HttpContext httpContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IdentityUser user)
    {
        var claims = await GetClaimsAsync(userManager, roleManager, user);

        var identity = new ClaimsIdentity();
        claims.ForEach(claim =>
            identity.AddClaim(new Claim(claim.Type, claim.Value))
        );

        var principal = new ClaimsPrincipal(identity);

        httpContext.User = principal;
    }

    private static async Task<List<Claim>> GetClaimsAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IdentityUser user)
    {
        var result = new List<Claim>();

        var userRolesNames = await userManager.GetRolesAsync(user);
        var userRoles = roleManager.Roles.Where(o => userRolesNames.Contains(o.Name));
        foreach (var userRole in userRoles)
        {
            var claims = await roleManager.GetClaimsAsync(userRole);
            result.AddRange(claims);
        }

        return result;
    }
}