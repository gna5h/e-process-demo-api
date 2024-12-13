using System;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;

namespace EProcessDemo.Api.Mapping;

public static class OrderMapping
{
    public static Order ToEntity(this CreateOrderDto order)
    {
        return new Order()
        {
            Name = order.Name,
            CustomerId = order.CustomerId,
            KitchenId = order.KitchenId
        };
    }

    // public static Game ToEntity(this UpdateGameDTO game, int id){
    //     return new Game () {
    //         Id = id,
    //         Name = game.Name,
    //         GenreId = game.GenreId,
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     }; 
    // }

    public static OrderSummaryDto ToOrderSummaryDto(this Order order)
    {
        return new(
            order.Id,
            order.Name,
            order.Customer!.Name
        );
    }

    public static OrderDetailsDto ToOrderDetailsDto(this Order order)
    {
        return new(
            order.Id,
            order.Name,
            order.CustomerId,
            order.KitchenId
        );
    }
}
