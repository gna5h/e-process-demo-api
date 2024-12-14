using System;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;

namespace EProcessDemo.Api.Mapping;

public static class KitchenMapping
{
    public static Kitchen ToEntity(this CreateKitchenDto kitchen)
    {
        return new Kitchen()
        {
            Type = kitchen.Type,
            Color = kitchen.Color,
            Length = kitchen.Length,
            Width = kitchen.Width
        };
    }

    public static Kitchen ToEntity(this UpdateKitchenDto kitchen, int id)
    {
        return new Kitchen()
        {
            Id = id,
            Type = kitchen.Type,
            Color = kitchen.Color,
            Length = kitchen.Length,
            Width = kitchen.Width
        };
    }
    public static KitchenSummaryDto ToKitchenSummaryDto(this Kitchen kitchen)
    {
        return new(
            kitchen.Id,
            kitchen.Type,
            kitchen.Color,
            kitchen.Length,
            kitchen.Width
        );
    }

    public static KitchenDetailsDto ToKitchenDetailsDto(this Kitchen kitchen)
    {
        return new(
            kitchen.Id,
            kitchen.Type,
            kitchen.Color,
            kitchen.Length,
            kitchen.Width
        );
    }
}
