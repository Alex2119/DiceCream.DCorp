namespace DiceCream.DCorp.Presentation.Extensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // On pourrait avoir trois méthodes d'extension pour dire Swagger, MediatR et DbContext
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(); // On peut encore ajouter une méthode privée pour la configuration de Swagger et autre
        services.AddDbContext<DCorpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
        services.AddScoped<IRepository, Repository>();
        services.AddMediatR(m => {
            m.RegisterServicesFromAssembly(typeof(GetPlayersQueryHandler).Assembly);
        });
        // Configuration de ProblemDetails
        services.AddProblemDetails();

        return services;
    }
}