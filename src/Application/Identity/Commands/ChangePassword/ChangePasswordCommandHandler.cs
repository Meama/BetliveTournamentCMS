using MediatR;
using Application.Healper;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public ChangePasswordCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        user.ThrowIfNull($"User with email = {request.Email} not exist");

        await _userManager.ChangePasswordAsync(user, user.PasswordHash, request.NewPassword);

        return Unit.Value;
    }
}