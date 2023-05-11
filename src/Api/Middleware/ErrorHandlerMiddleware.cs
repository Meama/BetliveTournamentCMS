using MediatR;
using Application.Exeption;

namespace Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IMediator mediator)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            var instance = ErrorInstanceForMediator(ex);
            var errorMessage = await mediator.Send(instance);

            await httpContext.Response.WriteAsJsonAsync(errorMessage);
        }
    }

    public object ErrorInstanceForMediator(Exception exception)
    {
        var exceptionType = exception.GetType();
        var exceptionNotificationType = typeof(ExceptionNotification<>);
        var specificType = exceptionNotificationType.MakeGenericType(exceptionType);

        //var instance = Activator.CreateInstance(specificType, exception);

        // create instance 100ns~150ns faster
        var constructor = specificType.GetConstructors()[0];
        var instance = constructor.Invoke(new object[] { exception });

        return instance;
    }
}