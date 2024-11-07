using DiceCream.DCorp.Application.Handlers;
using DiceCream.DCorp.Infrastructure;
using DiceCream.DCorp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiceCream.DCorp.Presentation.Extensions;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // On pourrait avoir trois methodes d'extension pour dire Swagger, MediatR et DbContext
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DCorpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"))); // D'ailleurs faut update le appsettings.json ;-)
        services.AddScoped<IRepository, Repository>();
        services.AddMediatR(m => {
            m.RegisterServicesFromAssembly(typeof(GetPlayersQueryHandler).Assembly);
        });
    }
}
