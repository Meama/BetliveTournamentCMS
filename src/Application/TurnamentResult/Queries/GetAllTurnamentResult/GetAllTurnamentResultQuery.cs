using MediatR;

namespace Application.TurnamentResult.Queries.GetAllTurnamentResult;

public class GetAllTurnamentResultQuery : IRequest<List<TurnamentResultDto>>
{
    public int FromIndex { get; set; } = 0;

    public int Count { get; set; } = 50;
}