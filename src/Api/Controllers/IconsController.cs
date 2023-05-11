using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Application.Icons.Queries.GetIcons;
using Microsoft.AspNetCore.Authorization;
using Application.Icons.Commands.SetIcons;

namespace Api.Controllers;

public class IconsController : BaseController
{
    private readonly IMediator _mediator;

    public IconsController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpPost(nameof(SetIcons))]
    [Authorize(Policy = ProjectPolicys.IconsModule.SetIcons)]
    public async Task SetIcons([FromForm] SetIconsCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpGet(nameof(GetIcons))]
    public async Task<IActionResult> GetIcons(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetIconsQuery() ,cancellationToken);

        return Ok(result);
    }
}