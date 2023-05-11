using MediatR;
using Application.Healper;
using Infrastructure.Database;

namespace Application.TurnamentResult.Commands.EditTurnamentResult;

public class EditTurnamentResultCommandHandler : IRequestHandler<EditTurnamentResultCommand>
{
    private readonly TournamentContext _context;

    public EditTurnamentResultCommandHandler(TournamentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EditTurnamentResultCommand request, CancellationToken cancellationToken)
    {
        var turnamentResult = await _context.TurnamentResults.FindAsync(request.Id, cancellationToken);
        turnamentResult.ThrowIfNull();

        turnamentResult.FullName = request.FullName;
        turnamentResult.IsWinner = request.IsWinner;
        turnamentResult.PrizeAmount = request.PrizeAmount;
        turnamentResult.PersonalNumber = request.PersonalNumber;
        turnamentResult.CurrentBalance = request.CurrentBalance;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}