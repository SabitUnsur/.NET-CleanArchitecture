
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.WebApi.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValiationErrorResultDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Errors = ((ValidationException)ex).Errors.Select(x => x.ErrorMessage)
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
