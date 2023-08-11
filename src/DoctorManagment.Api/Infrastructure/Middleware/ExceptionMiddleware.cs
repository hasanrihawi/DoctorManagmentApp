using System.Net;
using DoctorManagmentApp.Infrastructure.Exceptions;
using DoctorManagmentApp.Model;
using Newtonsoft.Json;

namespace DoctorManagmentApp.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Set the response status code based on the exception type.
            int statusCode;

            switch (exception)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var response = ApiResponse.FailResponse(exception.Message);

            string jsonResponse = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = statusCode;

            // Write the JSON response to the client.
            await context.Response.WriteAsync(jsonResponse);
        }
    }

}
