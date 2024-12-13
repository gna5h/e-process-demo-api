using System;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;

namespace EProcessDemo.Api.Mapping;

public static class OrderMapping
{
    // public static Order ToEntity(this CreateGameDto game){
    //     return new Game () {
    //         Name = game.Name,
    //         GenreId = game.GenreId,
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     }; 
    // }

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

    // public static GameDetailsDto ToGameDetailsDto(this Game game) {
    //     return  new (
    //         game.Id,
    //         game.Name,
    //         game.GenreId,
    //         game.Price,
    //         game.ReleaseDate
    //     );
    // }
}
