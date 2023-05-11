using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.CSV.Commands.UploadCsv;
using Application.TurnamentResult.Commands.AddTurnamentResult;
using Application.TurnamentResult.Commands.EditTurnamentResult;
using Application.TurnamentResult.Queries.GetAllTurnamentResult;

namespace Api.Controllers;

public class TurnamentResultController : BaseController
{
    private readonly IMediator _mediator;

    public TurnamentResultController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpPost(nameof(ImportCsv))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.ImportCsv)]
    public async Task ImportCsv([FromForm] UploadCsvCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpPost(nameof(Add))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.Add)]
    public async Task Add(AddTurnamentResultCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpPost(nameof(Edit))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.Edit)]
    public async Task Edit(EditTurnamentResultCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTurnamentResultQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}