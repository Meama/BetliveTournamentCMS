using MediatR;

namespace Application.TurnamentResult.Commands.AddTurnamentResult;

public class AddTurnamentResultCommand : IRequest
{
    public bool IsWinner { get; set; }

    public string FullName { get; set; }

    public decimal PrizeAmount { get; set; }

    public string PersonalNumber { get; set; }

    public decimal CurrentBalance { get; set; }
}