using System;
using EProcessDemo.Api.Data;
using EProcessDemo.Api.Entities;
using EProcessDemo.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Endpoints;

public static class OrdersEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("orders")
                        .WithParameterValidation();

        // GET /orders
        group.MapGet("/", (OrderContext dbContext) =>
            dbContext.Orders
                .Include(order => order.Customer)
                .Select(order => order.ToOrderSummaryDto())
                .AsNoTracking()
        );

        // GET /games/1
        // group.MapGet("/{id}", async (int id, OrderContext dbContext) =>
        // {
        //     Order? game = await dbContext.Orders.FindAsync(id);

        //     return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        // })
        // .WithName(GetGameEndpointName);

        // POST /games
        // group.MapPost("/", async (CreateGameDto newGame, OrderContext dbContext) =>
        // {

        //     Game game = newGame.ToEntity();

        //     dbContext.Games.Add(game);
        //     await dbContext.SaveChangesAsync();

        //     return Results.CreatedAtRoute(
        //         GetGameEndpointName,
        //         new { id = game.Id },
        //         game.ToGameDetailsDto()
        //     );
        // });

        // PUT /games
        // group.MapPut("/{id}", async (int id, UpdateGameDTO updatedGame, OrderContext dbContext) =>
        // {
        //     var existingGame = await dbContext.Games.FindAsync(id);

        //     if (existingGame is null)
        //     {
        //         return Results.NotFound();
        //     }

        //     dbContext.Entry(existingGame)
        //         .CurrentValues
        //         .SetValues(updatedGame.ToEntity(id));

        //     await dbContext.SaveChangesAsync();

        //     return Results.NoContent();
        // });

        // DELETE /games/1
        // group.MapDelete("/{id}", async (int id, OrderContext dbContext) =>
        // {
        //     await dbContext.Games
        //         .Where(game => game.Id == id)
        //         .ExecuteDeleteAsync();

        //     return Results.NoContent();
        // });

        return group;
    }
}
