using MediatR;
using Application.Healper;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Commands.EditUserName;

public class EditUserNameCommandHandler : IRequestHandler<EditUserNameCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public EditUserNameCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(EditUserNameCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        user.ThrowIfNull();

        user.UserName = $"{request.FirstName}-{request.LastName}";
        await _userManager.UpdateAsync(user);

        return Unit.Value;
    }
}