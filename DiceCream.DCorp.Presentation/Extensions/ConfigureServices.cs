namespace DiceCream.DCorp.Presentation.Extensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // API Explorer et Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(); // Optionnel : méthode privée pour configurer Swagger

        // Configuration du DbContext
        services.AddDbContext<DCorpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

        // Injections de dépendances
        services.AddScoped<IRepository, Repository>();

        // Configuration MediatR
        services.AddMediatR(m =>
        {
            m.RegisterServicesFromAssembly(typeof(GetPlayersQueryHandler).Assembly);
        });

        // Configuration de ProblemDetails
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = ctx =>
            {
                if(ctx.Exception is ArgumentException)
                {
                    ctx.ProblemDetails.Status = StatusCodes.Status400BadRequest;
                    ctx.ProblemDetails.Title = "Invalid input";
                    ctx.ProblemDetails.Detail = ctx.Exception.Message;
                }
                else if(ctx.Exception is UnauthorizedAccessException)
                {
                    ctx.ProblemDetails.Status = StatusCodes.Status401Unauthorized;
                    ctx.ProblemDetails.Title = "Access denied";
                }
                else if(ctx.Exception is NotImplementedException)
                {
                    ctx.ProblemDetails.Status = StatusCodes.Status501NotImplemented;
                    ctx.ProblemDetails.Title = "Feature not implemented";
                }
                else if(ctx.Exception != null)
                {
                    // Exception non gérée
                    ctx.ProblemDetails.Status = StatusCodes.Status500InternalServerError;
                    ctx.ProblemDetails.Title = "An unexpected error occurred";
                    ctx.ProblemDetails.Detail = environment.IsDevelopment() ? ctx.Exception.ToString() : "Contact support.";
                }
            };
        });

        return services;
    }
}