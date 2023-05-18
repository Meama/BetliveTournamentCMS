using MediatR;
using Infrastructure.Database;

namespace Application.TurnamentResult.Commands.DeleteTurnamentResult;

public class DeleteTurnamentResultCommandHandler : IRequestHandler<DeleteTurnamentResultCommand>
{
    private readonly TournamentContext _context;

    public DeleteTurnamentResultCommandHandler(TournamentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTurnamentResultCommand request, CancellationToken cancellationToken)
    {
        var tournament = await _context.TurnamentResults.FindAsync(request.Id, cancellationToken);
        if (tournament != null)
        {
            _context.Remove(tournament);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}