using Application.TurnamentResult.Commands.AddTurnamentResult;
using MediatR;

namespace Application.TurnamentResult.Commands.AddListTurnamentResult;

public class AddListTurnamentResultCommand : IRequest
{
    public List<AddTurnamentResultCommand> TurnamentItems { get; set; }
}