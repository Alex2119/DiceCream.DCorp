namespace DiceCream.DCorp.Presentation.Middlewares;
public static class ConfigureMiddlewareExtensions
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<GlobalExceptionHandling>();
        app.UseHttpsRedirection();

        // Ajout des points de terminaison
        app.AddEndPoints();
    }
}