using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configuration du pipeline de requ�tes HTTP
app.ConfigureMiddleware();

app.UseProblemDetails(); //Un pti souci, j'ai pas capt�

await app.RunAsync();