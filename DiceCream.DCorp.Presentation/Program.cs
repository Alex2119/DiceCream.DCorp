using DiceCream.DCorp.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddProblemDetails();
builder.Services.AddServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseProblemDetails();
// Configuration du pipeline de requêtes HTTP
app.ConfigureMiddleware();

await app.RunAsync();
