using System.Text;
using Application.Options;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Application.Healper.Abstraction;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Healper.Implementation;

public class TokenService : ITokenService
{
    private readonly IOptions<JwtSettingsOptions> _jwtSettingsOptions;
    private readonly UserManager<IdentityUser> _userManager;

    public TokenService(IOptions<JwtSettingsOptions> jwtSettingsOptions, UserManager<IdentityUser> userManager)
    {
        _jwtSettingsOptions = jwtSettingsOptions;
        _userManager = userManager;
    }

    public async Task<string> GenerateTokenAsync(IdentityUser newUser)
    {

        var claims = new ClaimsIdentity(new[]
                {
                                new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                                new Claim(ClaimTypes.Email, newUser.Email)
                            });


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingsOptions.Value.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = creds,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        //await GenerateOnlyOneValidToken(newUser, tokenString);

        return tokenString;
    }

    private async Task GenerateOnlyOneValidToken(IdentityUser newUser, string tokenString)
    {
        await CheckIfWorkingTokenOlreadyExists(newUser);
        await _userManager.SetAuthenticationTokenAsync(newUser, "MyApp", "AccessToken", tokenString);
    }

    private async Task CheckIfWorkingTokenOlreadyExists(IdentityUser newUser)
    {
        var accessToken = await _userManager.GetAuthenticationTokenAsync(newUser, "MyApp", "AccessToken");
        if (IsTokenValid(accessToken))
        {
            throw new Exception("Working token olready exist and can't login again");
        }
    }

    private bool IsTokenValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        // Set the validation parameters
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettingsOptions.Value.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        try
        {
            // Validate the token and return the result
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}