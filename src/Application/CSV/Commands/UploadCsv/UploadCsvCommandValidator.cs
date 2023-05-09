using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.CSV.Commands.UploadCsv;

public class UploadCsvCommandValidator : AbstractValidator<UploadCsvCommand>
{
    public UploadCsvCommandValidator()
    {
        RuleFor(o => o.File).NotNull();
        RuleFor(o => o.File)
            .Must(IsCsvFile);
    }

    private bool IsCsvFile(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file?.FileName);

        return string.Equals(fileExtension, ".csv", StringComparison.OrdinalIgnoreCase);
    }
}