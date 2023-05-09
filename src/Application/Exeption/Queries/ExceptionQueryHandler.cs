using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Exeption.Queries;

public class ExceptionQueryHandler : IRequestHandler<ExceptionNotification<Exception>, ValidationProblemDetails>
{
    public async Task<ValidationProblemDetails> Handle(ExceptionNotification<Exception> request, CancellationToken cancellationToken)
    {
        var error = new ValidationProblemDetails
        {
            Status = 400,
            Detail = request.Exception.Message,
            Title = "SomethingWentWrong",
            Type = "https://www.rfc-editor.org/rfc/rfc5378.html"
        };

        return error;
    }
}