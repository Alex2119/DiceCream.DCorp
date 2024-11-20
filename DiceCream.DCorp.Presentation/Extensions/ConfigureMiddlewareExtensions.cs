namespace DiceCream.DCorp.Presentation.Extensions;
public static class ConfigureMiddlewareExtensions
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        // Vérifiez si ProblemDetails est déjà configuré dans le pipeline
        if(!app.Services.GetRequiredService<IServiceCollection>().Any(x => x.ServiceType.Name.Contains("ProblemDetails")))
        {
            throw new InvalidOperationException("ProblemDetails must be added before calling UseProblemDetails.");
        }
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
}
