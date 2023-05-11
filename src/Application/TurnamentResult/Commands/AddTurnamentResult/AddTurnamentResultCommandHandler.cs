using MediatR;
using AutoMapper;
using Infrastructure.Database;

namespace Application.TurnamentResult.Commands.AddTurnamentResult;

using Infrastructure.Database.Entities;

public class AddTurnamentResultCommandHandler : IRequestHandler<AddTurnamentResultCommand>
{
    private readonly TournamentContext _context;

    public AddTurnamentResultCommandHandler(TournamentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddTurnamentResultCommand request, CancellationToken cancellationToken)
    {
        var turnamentResult = new TurnamentResult
        {
            FullName = request.FullName,
            IsWinner = request.IsWinner,
            PrizeAmount = request.PrizeAmount,
            CurrentBalance = request.CurrentBalance,
            PersonalNumber = request.PersonalNumber
        };

        await _context.AddAsync(turnamentResult, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}