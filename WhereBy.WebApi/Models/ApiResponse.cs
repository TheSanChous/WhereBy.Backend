using Microsoft.AspNetCore.Mvc;

namespace WhereBy.WebApi.Models
{
    public class ApiResponseError
    {
        public string Message { get; set; }
        public int? Code { get; set; }
    }

    public class ApiResponse : ActionResult
    {
        public bool Success { get; set; }
        public ApiResponseError Error { get; set; }
        public object Data { get; set; }
    }
}
