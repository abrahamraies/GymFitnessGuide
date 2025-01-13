using Newtonsoft.Json;
using System.Net;

namespace GymFitnessGuide.API
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            HttpStatusCode status;
            string errorMessage;

            // Aca puedo agregar distintos tipos de excepciones.
            if (exception is KeyNotFoundException)
            {
                status = HttpStatusCode.NotFound;
                errorMessage = "The specified resource was not found.";
            }
            else if (exception is InvalidOperationException)
            {
                status = HttpStatusCode.BadRequest;
                errorMessage = exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                errorMessage = "An unexpected error occurred.";
            }

            response.StatusCode = (int)status;
            var result = JsonConvert.SerializeObject(new { error = errorMessage });
            return response.WriteAsync(result);
        }
    }
}