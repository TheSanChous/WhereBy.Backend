using Microsoft.AspNetCore.Builder;

namespace WhereBy.WebApi.Middleware
{
    public static class CustomMiddlewaresExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseResponseWrapper(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseWrapperMiddleware>();
        }
    }
}
