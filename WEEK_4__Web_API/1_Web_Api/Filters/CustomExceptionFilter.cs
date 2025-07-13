using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            File.AppendAllText("errors.txt", $"{DateTime.Now}: {exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
