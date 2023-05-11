using MediatR;
using AutoMapper;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.TurnamentResult.Queries.GetAllTurnamentResult;

using Infrastructure.Database.Entities;

public class GetAllTurnamentResultQueryHandler : IRequestHandler<GetAllTurnamentResultQuery, List<TurnamentResultDto>>
{
    private readonly TournamentContext _context;
    private readonly IMapper _mapper;

    public GetAllTurnamentResultQueryHandler(TournamentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TurnamentResultDto>> Handle(GetAllTurnamentResultQuery request, CancellationToken cancellationToken)
    {
        var turnaments = await _context
                .TurnamentResults
                .Skip(request.FromIndex)
                .Take(request.Count)
                .ToListAsync(cancellationToken);

        var result = _mapper.Map<List<TurnamentResult>, List<TurnamentResultDto>>(turnaments);

        return result;
    }
}