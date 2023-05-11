using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Application.Healper.Abstraction;

public interface ITokenService
{
    public Task<string> GenerateTokenAsync(IdentityUser newUser);
}