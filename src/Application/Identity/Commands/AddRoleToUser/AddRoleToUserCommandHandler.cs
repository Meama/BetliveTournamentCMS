using MediatR;
using Application.Healper;
using Microsoft.AspNetCore.Identity;
using Application.Exeption.CustomeExeption;

namespace Application.Identity.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public AddRoleToUserCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        user.ThrowIfNull();

        var addToRoles = await _userManager.AddToRolesAsync(user, new string[] { request.Role });
        //var deletedToRoles = await _userManager.RemoveFromRoleAsync(user, request.Role);
        if (!addToRoles.Succeeded)
        {
            var errors = addToRoles.Errors.Select(error => error?.Description).ToArray();
            throw new PermitionException(errors, request.Role);
        }
        return Unit.Value;
    }
}