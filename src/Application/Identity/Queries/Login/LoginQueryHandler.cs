using MediatR;
using Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Healper.Abstraction;

namespace Application.Identity.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginDto>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;

    public LoginQueryHandler(UserManager<IdentityUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
 
    public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Email.ToLower() == request.Email.ToLower(), cancellationToken);
        var roles = await _userManager.GetRolesAsync(user);
        var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        return new LoginDto
        {
            Token = await _tokenService.GenerateTokenAsync(user)
        };
    }
}