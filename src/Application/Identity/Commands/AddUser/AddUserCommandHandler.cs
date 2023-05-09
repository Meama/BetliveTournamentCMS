using Application.Exeption.CustomeExeption;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public AddUserCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault().Description);
        }

        var addToRoles = await _userManager.AddToRolesAsync(user, request.Roles);
        if (!addToRoles.Succeeded)
        {
            await _userManager.DeleteAsync(user);         
            var errors = addToRoles.Errors.Select(error => error?.Description).ToArray();
            throw new PermitionException(errors, string.Join(Environment.NewLine, request.Roles ?? new List<string>()));
        }

        return Unit.Value;
    }
}