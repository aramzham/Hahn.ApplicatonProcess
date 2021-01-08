using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Web.Models;
using Microsoft.AspNetCore.Http;

namespace Hahn.ApplicatonProcess.December2020.Web.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new ErrorModel() { Error = ex.Message });
            context.Response.ContentType = Constants.ContentType;
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}