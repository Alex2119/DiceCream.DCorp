using System.Net;

namespace DiceCream.DCorp.Presentation.Middlewares;

public class GlobalExceptionHandling : IMiddleware
{
    private readonly ILogger<DCorpDbContext> _logger;

    public GlobalExceptionHandling(ILogger<DCorpDbContext> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var problem = new ProblemDetails
            {
                Title = ex.Message,
                Detail = ex.InnerException?.Message,
                Status = (int)HttpStatusCode.InternalServerError
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}