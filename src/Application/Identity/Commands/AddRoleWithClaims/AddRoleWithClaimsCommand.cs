using MediatR;

namespace Application.Identity.Commands.AddClaims;

public class AddRoleWithClaimsCommand : IRequest
{
    public string RoleName { get; set; }

    public string[] Policies { get; set; }
}