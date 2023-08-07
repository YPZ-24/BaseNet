using FluentValidation;
using IntranetCorrespondencia.api.Controllers.Base;
using IntranetCorrespondencia.api.Middleware.Models;
using IntranetCorrespondencia.api.Middleware.Utils;
using System.Text.Json;

namespace IntranetCorrespondencia.api.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _Next;

        public ExceptionHandling(RequestDelegate next)
        {
            _Next = next ?? throw new ArgumentException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int apiResponseStatusCode; 
            string apiResponseStr;

            if(ex is ValidationException validation)
            {
                ApiResponse<ValidationDataModel> apiResponse = ExceptionGenerators.GenerateValidationException(validation);
                apiResponseStr = JsonSerializer.Serialize((ApiResponse<ValidationDataModel>)apiResponse);
                apiResponseStatusCode = apiResponse.StatusCode;
            }
            else
            {
                ApiResponse<int> apiResponse = ExceptionGenerators.GenerateInternalException();
                apiResponseStr = JsonSerializer.Serialize((ApiResponse<int>)apiResponse);
                apiResponseStatusCode = apiResponse.StatusCode;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = apiResponseStatusCode;
            var response = apiResponseStr;

            return context.Response.WriteAsync(response);
        }        

    }
}
