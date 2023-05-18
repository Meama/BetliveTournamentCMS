using MediatR;
using Infrastructure.Database;

namespace Application.TurnamentResult.Commands.AddListTurnamentResult;

public class AddListTurnamentResultCommandHandler : IRequestHandler<AddListTurnamentResultCommand>
{
    private readonly TournamentContext _context;

    public AddListTurnamentResultCommandHandler(TournamentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddListTurnamentResultCommand command, CancellationToken cancellationToken)
    {
        var turnamentResults = command.TurnamentItems.Select(turnament => new Infrastructure.Database.Entities.TurnamentResult
        {
            FullName = turnament.FullName,
            IsWinner = turnament.IsWinner,
            PrizeAmount = turnament.PrizeAmount,
            CurrentBalance = turnament.CurrentBalance,
            PersonalNumber = turnament.PersonalNumber
        });
        
        await _context.AddRangeAsync(turnamentResults, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}