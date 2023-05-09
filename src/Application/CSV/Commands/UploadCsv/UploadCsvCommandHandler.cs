using MediatR;
using AutoMapper;
using Application.Healper;
using Application.CSV.Models;
using Infrastructure.Database;

namespace Application.CSV.Commands.UploadCsv;

using Infrastructure.Database.Entities;

public class UploadCsvCommandHandler : IRequestHandler<UploadCsvCommand>
{
    private readonly TournamentContext _context;
    private readonly IMapper _mapper;

    public UploadCsvCommandHandler(TournamentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UploadCsvCommand request, CancellationToken cancellationToken)
    {
        using var csv = request.File.GetCsvReader();

        var records = csv.GetRecords<TurnamentResultCsvModel>().ToList();
        var importedDatas = _mapper.Map<List<TurnamentResultCsvModel>, List<TurnamentResult>>(records);

        await _context.AddRangeAsync(importedDatas, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}