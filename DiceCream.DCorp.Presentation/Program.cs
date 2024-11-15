using DiceCream.DCorp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration des services
ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

// Configuration du pipeline de requêtes HTTP
ConfigureMiddleware(app);

await app.RunAsync();

void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
{
    // Configuration de la base de données
    services.AddDbContext<DCorpDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

    // Configuration des contrôleurs
    services.AddControllers();

    // Configuration de Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Configuration des services personnalisés
    services.AddServices(configuration);

    // Configuration de ProblemDetails
    services.AddProblemDetails(options =>
    {
        options.IncludeExceptionDetails = (context, exception) =>
        {
            return environment.IsDevelopment();
        };

        options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
        options.MapToStatusCode<InvalidOperationException>(StatusCodes.Status404NotFound);
        options.MapToStatusCode<ArgumentException>(StatusCodes.Status400BadRequest);
        options.MapToStatusCode<InvalidOperationException>(StatusCodes.Status500InternalServerError);
    });
}

void ConfigureMiddleware(WebApplication app)
{
    // Utilisation de ProblemDetails
    app.UseProblemDetails();

    // Configuration du pipeline de requêtes HTTP
    if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // Ajout des points de terminaison
    app.AddEndPoints();
}