using MediatR;
using Infrastructure.Database;

namespace Application.TurnamentResult.Commands.DeleteAllTurnamentResult;

public class DeleteAllTurnamentResultCommandHandler : IRequestHandler<DeleteAllTurnamentResultCommand>
{
    private readonly TournamentContext _context;

    public DeleteAllTurnamentResultCommandHandler(TournamentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteAllTurnamentResultCommand request, CancellationToken cancellationToken)
    {
        var all = _context.TurnamentResults;
        _context.RemoveRange(all);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}