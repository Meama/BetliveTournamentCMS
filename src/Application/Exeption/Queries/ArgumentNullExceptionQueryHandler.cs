using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Exeption.Queries;

public class ArgumentNullExceptionQueryHandler : IRequestHandler<ExceptionNotification<System.ArgumentNullException>, ValidationProblemDetails>
{
    public async Task<ValidationProblemDetails> Handle(ExceptionNotification<ArgumentNullException> request, CancellationToken cancellationToken)
    {
        var error = new ValidationProblemDetails
        {
            Status = 400,
            Title = "Not exist",
            Detail = request.Exception.Message,
            Type = "https://www.rfc-editor.org/rfc/rfc5378.html"
        };

        return error;
    }
}