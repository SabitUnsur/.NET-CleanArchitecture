
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.WebApi.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly AppDbContext _dbContext;

        public ExceptionMiddleware(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionToDatabaseAsync(ex,context.Request);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json"; //bu tipte olma sebebi, json döneceğiz.
            context.Response.StatusCode = 500;

            if (ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorResultDetails
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


        private async Task LogExceptionToDatabaseAsync(Exception ex,HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,
                RequestPath = request.Path,
                RequestMethod = request.Method,
                TimeStamp = DateTime.Now
            };

            await _dbContext.Set<ErrorLog>().AddAsync(errorLog,default);
            await _dbContext.SaveChangesAsync(default);

        }
    }
}
