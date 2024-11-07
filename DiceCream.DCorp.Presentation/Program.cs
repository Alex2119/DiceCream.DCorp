using DiceCream.DCorp.Application.Lib.Handlers;
using DiceCream.DCorp.Application.Lib.Queries;
using DiceCream.DCorp.Infrastructure;
using DiceCream.DCorp.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DCorpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddMediatR(m => { 
    m.RegisterServicesFromAssembly(typeof(GetPlayersQueryHandler).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/getPlayers", ([FromServices] ISender sender) =>
{
    return sender.Send(new GetPlayersQuery());
});
app.MapGet("/players/{id}", async (int id, ISender sender) =>
{
    var playerDto = await sender.Send(new GetPlayerQuery(id));
    return playerDto != null ? Results.Ok(playerDto) : Results.NotFound();
});

await app.RunAsync();