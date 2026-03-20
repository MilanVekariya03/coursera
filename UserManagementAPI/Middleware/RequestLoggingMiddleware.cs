namespace UserManagementAPI.Middleware
{
    /// <summary>
    /// Custom middleware for logging incoming HTTP requests
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            var method = context.Request.Method;
            var path = context.Request.Path;
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            _logger.LogInformation($"[{timestamp}] Incoming request: {method} {path}");

            // Call the next middleware
            await _next(context);

            // Log the response status
            var statusCode = context.Response.StatusCode;
            _logger.LogInformation($"[{timestamp}] Response: {statusCode} from {method} {path}");
        }
    }
}
