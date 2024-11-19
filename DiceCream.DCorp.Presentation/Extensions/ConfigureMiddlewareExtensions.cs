namespace DiceCream.DCorp.Presentation.Extensions;
public static class ConfigureMiddlewareExtensions
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
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
