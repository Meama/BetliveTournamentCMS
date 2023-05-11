using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.WaitingPage.Commands.SetText;
using Application.WaitingPage.Queries.GetText;

namespace Api.Controllers;

public class WaitingPageController : BaseController
{
    private readonly IMediator _mediator;

    public WaitingPageController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpPost(nameof(SetText))]
    [Authorize(Policy = ProjectPolicys.WaitingModule.SetText)]
    public async Task SetText(SetTextCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpGet(nameof(GetText))]
    public async Task<IActionResult> GetText(CancellationToken cancellation)
    {
        var result = await _mediator.Send(new GetTextQuery(), cancellation);

        return Ok(result);
    }
}