using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Exeption.CustomeExeption;

namespace Application.Exeption.Queries;

public class RoleExceptionQueryHandler : IRequestHandler<ExceptionNotification<PermitionException>, ValidationProblemDetails>
{
    public async Task<ValidationProblemDetails> Handle(ExceptionNotification<PermitionException> request, CancellationToken cancellationToken)
    {
        var error = new ValidationProblemDetails
        {
            Status = 400,
            Title = request.Exception?.PermitionName,
            Detail = string.Join(Environment.NewLine, request.Exception.Messages ?? Array.Empty<string>())
        };

        return error;
    }
}