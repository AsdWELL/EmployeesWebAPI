using EmployeesWebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesWebAPI.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var httpContext = context.HttpContext;

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            httpContext.Response.WriteAsJsonAsync(new
            {
                ActionName = context.ActionDescriptor.DisplayName,
                exception.Message,
                exception.StackTrace
            });

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
