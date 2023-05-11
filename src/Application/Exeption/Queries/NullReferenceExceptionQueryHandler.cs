using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Exeption.Queries;

public class NullReferenceExceptionQueryHandler : IRequestHandler<ExceptionNotification<System.NullReferenceException>, ValidationProblemDetails>
{
    public async Task<ValidationProblemDetails> Handle(ExceptionNotification<NullReferenceException> request, CancellationToken cancellationToken)
    {
        var error = new ValidationProblemDetails
        {
            Status = 400,
            Detail = request.Exception.Message,
            Title = "Data not exist on this key",
            Type = "https://www.rfc-editor.org/rfc/rfc5378.html"
        };

        return error;
    }
}