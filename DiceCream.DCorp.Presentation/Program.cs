var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddServices(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configuration du pipeline de requêtes HTTP
app.ConfigureMiddleware();

await app.RunAsync();
