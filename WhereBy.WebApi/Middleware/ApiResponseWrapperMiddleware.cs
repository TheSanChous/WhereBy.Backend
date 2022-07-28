using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using WhereBy.WebApi.Models;

namespace WhereBy.WebApi.Middleware
{
    public class ApiResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseWrapperMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                var error = context.Items["Error"] as ApiResponseError;

                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = JsonConvert.DeserializeObject(readToEnd);

                ApiResponse result = null;

                if (error is null)
                {
                    result = new ApiResponse
                    {
                        Data = objResult,
                        Error = error,
                        Success = true
                    };
                }
                else
                {
                    result = new ApiResponse
                    {
                        Data = objResult,
                        Error = error,
                        Success = false
                    };
                }

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }
    }
}
