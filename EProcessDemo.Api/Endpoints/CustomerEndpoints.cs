using System;
using EProcessDemo.Api.Data;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;
using EProcessDemo.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Endpoints;

public static class CustomerEndpoints
{
    const string GetCustomerEndpointName = "GetCustomer";

    public static RouteGroupBuilder MapCustomersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("customers")
                        .WithParameterValidation();

        // GET /customers
        group.MapGet("/", async (EProcessDemoContext dbContext) =>
            await dbContext.Customers
                .Select(customer => customer.ToCustomerSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // GET /customers/{id}
        group.MapGet("/{id}", async (int id, EProcessDemoContext dbContext) =>
        {
            var customer = await dbContext.Customers.FindAsync(id);

            return customer is not null
                ? Results.Ok(customer.ToCustomerDetailsDto())
                : Results.NotFound();
        }).WithName(GetCustomerEndpointName);

        // POST /customers
        group.MapPost("/", async (CreateCustomerDto newCustomer, EProcessDemoContext dbContext) =>
        {

            Customer customer = newCustomer.ToEntity();

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetCustomerEndpointName,
                new { id = customer.Id },
                customer.ToCustomerDetailsDto()
            );
        });

        // PUT /customers
        group.MapPut("/{id}", async (int id, UpdateCustomerDto updatedCustomer, EProcessDemoContext dbContext) =>
        {
            var existingCustomer = await dbContext.Customers.FindAsync(id);

            if (existingCustomer is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCustomer)
                .CurrentValues
                .SetValues(updatedCustomer.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /customers/{id}
        group.MapDelete("/{id}", async (int id, EProcessDemoContext dbContext) =>
        {
            await dbContext.Customers
                .Where(customer => customer.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
