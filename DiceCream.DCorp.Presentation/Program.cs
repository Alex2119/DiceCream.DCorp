using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configuration du pipeline de requêtes HTTP
app.ConfigureMiddleware();

app.UseProblemDetails(); //Un pti souci, j'ai pas capté

await app.RunAsync();