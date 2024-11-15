using DiceCream.DCorp.Presentation.Extensions;
using Hellang.Middleware.ProblemDetails;

// using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configuration du pipeline de requêtes HTTP
ConfigureMiddleware(app);

app.UseProblemDetails(); // Un pti souci, j'ai pas capté

await app.RunAsync();

void ConfigureMiddleware(WebApplication app) //TODO:; Pareil, en méthode d'extension
{
    // Utilisation de ProblemDetails
    
    // Configuration du pipeline de requêtes HTTP
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // Ajout des points de terminaison
    app.AddEndPoints();
}
