using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Exeption;

public class ExceptionNotification<TException> : IRequest<ValidationProblemDetails>
{
    public TException Exception { get; }

    public ExceptionNotification(TException exception)
    {
        Exception = exception;
    }
}