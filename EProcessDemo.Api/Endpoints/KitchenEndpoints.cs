using System;
using EProcessDemo.Api.Data;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;
using EProcessDemo.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Endpoints;

public static class KitchenEndpoints
{
    const string GetKitchenEndpointName = "GetKitchen";

    public static RouteGroupBuilder MapKitchensEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("kitchens")
                        .WithParameterValidation();

        // GET /kitchens
        group.MapGet("/", async (EProcessDemoContext dbContext) =>
            await dbContext.Kitchens
                .Select(kitchen => kitchen.ToKitchenSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // GET /kitchens/{id}
        group.MapGet("/{id}", async (int id, EProcessDemoContext dbContext) =>
        {
            var kitchen = await dbContext.Kitchens.FindAsync(id);

            return kitchen is not null
                ? Results.Ok(kitchen.ToKitchenDetailsDto())
                : Results.NotFound();
        }).WithName(GetKitchenEndpointName);

        // POST /kitchens
        group.MapPost("/", async (CreateKitchenDto newKitchen, EProcessDemoContext dbContext) =>
        {

            Kitchen kitchen = newKitchen.ToEntity();

            dbContext.Kitchens.Add(kitchen);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetKitchenEndpointName,
                new { id = kitchen.Id },
                kitchen.ToKitchenDetailsDto()
            );
        });

        // PUT /kitchens
        group.MapPut("/{id}", async (int id, UpdateKitchenDto updatedKitchen, EProcessDemoContext dbContext) =>
        {
            var existingKitchen = await dbContext.Kitchens.FindAsync(id);

            if (existingKitchen is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingKitchen)
                .CurrentValues
                .SetValues(updatedKitchen.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /kitchens/{id}
        group.MapDelete("/{id}", async (int id, EProcessDemoContext dbContext) =>
        {
            await dbContext.Kitchens
                .Where(kitchen => kitchen.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
