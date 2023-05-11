using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CSV.Commands.UploadCsv;

public class UploadCsvCommand : IRequest
{
    public IFormFile File { get; set; }
}