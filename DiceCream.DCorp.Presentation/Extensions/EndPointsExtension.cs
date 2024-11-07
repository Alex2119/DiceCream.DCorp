using DiceCream.DCorp.Application.Lib.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiceCream.DCorp.Presentation.Extensions;

public static class EndPointsExtension
{
    public static void AddEndPoints(this WebApplication app)
    {
        app.MapGet("/getPlayers", ([FromServices] ISender sender) =>
        {
            return sender.Send(new GetPlayersQuery());
        });
        app.MapGet("/players/{id}", async (int id, ISender sender) =>
        {
            var playerDto = await sender.Send(new GetPlayerQuery(id));
            return playerDto is null ? Results.Ok(playerDto) : Results.NotFound(); // Très bien utilisé le Result Pattern
        });
    }
}