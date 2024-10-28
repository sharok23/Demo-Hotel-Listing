//using Newtonsoft.Json;
//using System.Net;


//namespace Demo_Hotel_Listing.exception
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<ExceptionMiddleware> _logger;

//        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"Something went wrong while processing {context.Request.Path}");
//                await HandleExceptionAsync(context, ex);
//            }
//        }

//        private Task HandleExceptionAsync(HttpContext context, Exception exception)
//        {
//            context.Response.ContentType = "application/json";
//            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
//            var errorDetails = new ErrorDetails
//            {
//                ErrorType = "Failure",
//                ErrorMessage = exception.Message,
//            };

//            switch (exception)
//            {
//                case EntityNotFoundException:
//                    statusCode = HttpStatusCode.NotFound;
//                    errorDetails.ErrorType = "Not Found";
//                    break;
//                case BadRequestException:
//                    statusCode = HttpStatusCode.BadRequest;
//                    errorDetails.ErrorType = "Bad Request";
//                    break;
//                default:
//                    errorDetails.ErrorMessage = "Internal Server Error. Please try again later.";
//                    break;
//            }

//            string response = JsonConvert.SerializeObject(errorDetails);
//            context.Response.StatusCode = (int)statusCode;
//            return context.Response.WriteAsync(response);
//        }
//    }

//    public class ErrorDetails
//    {
//        public string ErrorType { get; set; }
//        public string ErrorMessage { get; set; }
//    }

//    public class EntityNotFoundException : Exception
//    {
//        public EntityNotFoundException(string name, object key)
//            : base($"No entity '{name}' found with id {key}.")
//        {
//        }
//    }

//    public class BadRequestException : Exception
//    {
//        public BadRequestException(string message) : base(message)
//        {
//        }
//    }

//    // Extension method to register the middleware
//    public static class ExceptionMiddlewareExtensions
//    {
//        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
//        {
//            app.UseMiddleware<ExceptionMiddleware>();
//        }
//    }
//}
