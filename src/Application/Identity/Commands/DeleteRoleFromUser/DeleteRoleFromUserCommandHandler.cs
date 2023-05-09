using MediatR;
using Application.Healper;
using Microsoft.AspNetCore.Identity;
using Application.Exeption.CustomeExeption;

namespace Application.Identity.Commands.DeleteRole;

public class DeleteRoleFromUserCommandHandler : IRequestHandler<DeleteRoleFromUserCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public DeleteRoleFromUserCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(DeleteRoleFromUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        user.ThrowIfNull($"User with email = {request.Email} not exist");

        var result = await _userManager.RemoveFromRoleAsync(user, request.Role);
        if (!result.Succeeded)
        {
            throw new PermitionException(result.Errors.Select(error => error.Description).ToArray(), request.Role);
        }

        return Unit.Value;
    }
}
