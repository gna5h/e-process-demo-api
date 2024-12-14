using System;
using EProcessDemo.Api.Data;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;
using EProcessDemo.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Endpoints;

public static class OrdersEndpoints
{
    const string GetOrderEndpointName = "GetOrder";

    public static RouteGroupBuilder MapOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("orders")
                        .WithParameterValidation();

        // GET /orders
        group.MapGet("/", (EProcessDemoContext dbContext) =>
            dbContext.Orders
                .Include(order => order.Customer)
                .Select(order => order.ToOrderSummaryDto())
                .AsNoTracking()
        );

        // GET /orders/{id}
        group.MapGet("/{id}", async (int id, EProcessDemoContext dbContext) =>
        {
            Order? order = await dbContext.Orders.FindAsync(id);

            return order is null ? Results.NotFound() : Results.Ok(order.ToOrderDetailsDto());
        })
        .WithName(GetOrderEndpointName);

        // POST /orders
        group.MapPost("/", async (CreateOrderDto newOrder, EProcessDemoContext dbContext) =>
        {
            var customerExists = await dbContext.Customers.AnyAsync(c => c.Id == newOrder.CustomerId);
            if (!customerExists)
            {
                return Results.BadRequest("Invalid CustomerId. Customer does not exist.");
            }

            Order order = newOrder.ToEntity();

            if (newOrder.KitchenId == -1)
            {
                var kitchen = await dbContext.Kitchens.FindAsync(newOrder.KitchenId);
                if (kitchen == null)
                {
                    return Results.BadRequest("Kitchen not found.");
                }
                order.Kitchen = kitchen; // Associate kitchen if it exists
            }

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetOrderEndpointName,
                new { id = order.Id },
                order.ToOrderDetailsDto()
            );
        });

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
