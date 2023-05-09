using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Timer.Queries.GetCountdown;
using Application.Timer.Commands.SetCountdown;

namespace Api.Controllers;

public class TimerController : BaseController
{
    private readonly IMediator _mediator;

    public TimerController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpPost(nameof(SetCountdown))]
    [Authorize(Policy = ProjectPolicys.TimerModule.SetCountdown)]
    public async Task SetCountdown(SetCountdownCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpGet(nameof(GetCountdown))]
    public async Task<IActionResult> GetCountdown(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCountdownQuery(), cancellationToken);

        return Ok(result);
    }
}