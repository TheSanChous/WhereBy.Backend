using System;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using WhereBuy.Application.Common.Exceptions;

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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
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
                    result = JsonSerializer.Serialize(
                    new
                    {
                        code = code,
                        detail = exception.Message ?? "UNAUTHORIZED"
                    });
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(
                new
                { 
                    code = code,
                    detail = exception.Message
                });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
