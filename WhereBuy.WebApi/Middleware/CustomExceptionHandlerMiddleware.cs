using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using WhereBuy.Common.Errors;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Auth.Common.Exceptions;
using WhereBuy.WebApi.Models;

namespace WhereBuy.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            switch(exception)
            {
                case ValidationException or BadRequestException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException:
                    code = HttpStatusCode.Unauthorized;
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            var appError = exception as AppError;

            context.Items["Error"] = new ApiResponseError
            {
                Code = appError is not null ? appError.Code : null,
                Message = GetExceptionDetails(exception)
            };

            context.Response.StatusCode = (int)code;
        }

        private string GetExceptionDetails(Exception exception, string before = "")
        {
            if(exception.InnerException != null)
            {
                return GetExceptionDetails(exception.InnerException, exception.Message + " ");
            }
            return before + exception.Message;
        } 
    }
}
