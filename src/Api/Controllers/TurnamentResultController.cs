using MediatR;
using Application.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.CSV.Commands.UploadCsv;
using Application.TurnamentResult.Commands.AddTurnamentResult;
using Application.TurnamentResult.Commands.EditTurnamentResult;
using Application.TurnamentResult.Queries.GetAllTurnamentResult;
using Application.TurnamentResult.Commands.DeleteAllTurnamentResult;
using Application.TurnamentResult.Commands.DeleteTurnamentResult;
using Application.TurnamentResult.Commands.AddListTurnamentResult;

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

    [HttpGet(nameof(DeleteAll))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.DeleteAll)]
    public async Task<IActionResult> DeleteAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteAllTurnamentResultCommand(), cancellationToken);

        return Ok(result);
    }

    [HttpPost(nameof(DeleteTurnamentById))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.DeleteTurnamentById)]
    public async Task<IActionResult> DeleteTurnamentById(DeleteTurnamentResultCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPost(nameof(AddList))]
    [Authorize(Policy = ProjectPolicys.TurnamentResultModule.AddList)]
    public async Task<IActionResult> AddList(AddListTurnamentResultCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}