using GlobalErrorApp.Excepetions;
using System.Net;
using System.Text.Json;

using NotImplementesException = GlobalErrorApp.Excepetions.NotImplementesException;
using KeyNotNotFoundException = GlobalErrorApp.Excepetions.KeyNotFoundException;
using unAuthorizedExpetion = GlobalErrorApp.Excepetions.unAuthorizedExpetion;
namespace GlobalErrorApp.Configurations
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
              await  _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }
        private  static Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            HttpStatusCode statusCode;
            var stackTrace=string.Empty;
            string msg="";
            var exceptionType=ex.GetType();
            if(exceptionType == typeof(NotFoundException)) 
            {
                msg = ex.Message;    
                statusCode = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }
            else if(exceptionType == typeof(NotImplementesException))
            {
                msg = ex.Message;
                statusCode = HttpStatusCode.NotImplemented;
                stackTrace = ex.StackTrace;

            }
            else if (exceptionType == typeof(Excepetions.BadRequestExpetion))
            {
                msg = ex.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;

            }
            else if (exceptionType == typeof(KeyNotNotFoundException))
            {
                msg = ex.Message;
                statusCode = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;

            }
            else if (exceptionType == typeof(unAuthorizedExpetion))
            {
                msg = ex.Message;
                statusCode = HttpStatusCode.Unauthorized;
                stackTrace = ex.StackTrace;

            }
            else
            {
                msg = ex.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
            }
            var exceptionresult = JsonSerializer.Serialize(new { error = msg ,stackTrace});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(exceptionresult); 
        }
    }
}
