namespace EProcessDemo.Api.Dtos;

public record class KitchenDetailsDto(
    int Id,
    string Type,
    string Color,
    int Length,
    int Width
);
