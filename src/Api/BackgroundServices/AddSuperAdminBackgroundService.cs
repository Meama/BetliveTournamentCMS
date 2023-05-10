using MediatR;
using Application.Policy;
using Application.Identity.Commands.AddUser;
using Application.Identity.Commands.AddClaims;

namespace Api.BackgroundServices;

public class AddSuperAdminBackgroundService : BackgroundService
{
    private readonly IServiceProvider _services;

    public AddSuperAdminBackgroundService(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var serviceScope = _services.CreateScope();
        const string rolename = "SuperAdmin";

        var mediator = serviceScope.ServiceProvider.GetService<IMediator>();
        try
        {
            await mediator.Send(new AddRoleWithClaimsCommand
            {
                RoleName = rolename,
                Policies = ProjectPolicys.GetProjectPermissions().ToArray()
            }, cancellationToken);

            await mediator.Send(new AddUserCommand
            {
                Email = "admin@admin.com",
                FirstName = "Nika",
                LastName = "Mamniashvili",
                Password = "ae7b55c81Sli)(vI",
                Roles = new List<string> { rolename },
            }, cancellationToken);
        }
        catch (Exception)
        {
        }
    }
}