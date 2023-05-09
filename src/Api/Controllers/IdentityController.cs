using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Application.Identity.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Application.Identity.Commands.AddUser;
using Application.Identity.Commands.AddClaims;
using Application.Identity.Commands.DeleteRole;
using Application.Identity.Commands.ChangePassword;
using Application.Identity.Queries.GetAllRolesWithClames;
using Application.Identity.Commands.ChangePassword.UnAuthorized;

namespace Api.Controllers;

public class IdentityController : BaseController
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(nameof(Registration))]
    [Authorize(Policy = ProjectPolicys.IdentityModule.Registration)]
    public async Task<IActionResult> Registration(AddUserCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginQuery command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet(nameof(GetClaims))]
    [Authorize(Policy = ProjectPolicys.IdentityModule.GetClaims)]
    public async Task<IActionResult> GetClaims()
    {
        var policies = ProjectPolicys.GetProjectPermissions();
        return Ok(policies);
    }

    [HttpGet(nameof(GeetAllRoles))]
    [Authorize(Policy = ProjectPolicys.IdentityModule.GeetAllRoles)]
    public async Task<IActionResult> GeetAllRoles()
    {
        var roles = await _mediator.Send(new GetAllRolesWithClamesQuery());

        return Ok(roles);
    }

    [HttpPost(nameof(AddRoleWithClaims))]
    [Authorize(Policy = ProjectPolicys.IdentityModule.AddRoleWithClaims)]
    public async Task AddRoleWithClaims(AddRoleWithClaimsCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost(nameof(DeleteRoleFromUser))]
    //[Authorize(Policy = ProjectPolicys.IdentityModule.DeleteRoleFromUser)]
    public async Task DeleteRoleFromUser(DeleteRoleFromUserCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost(nameof(ChangePassword))]
    [Authorize(Policy = ProjectPolicys.IdentityModule.ChangePassword)]
    public async Task ChangePassword(ChangePasswordCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost(nameof(ChangePasswordWithMail))]
    public async Task ChangePasswordWithMail(ChangePasswordForUnAuthorizedUserCommand command)
    {
        await _mediator.Send(command);
    }
}