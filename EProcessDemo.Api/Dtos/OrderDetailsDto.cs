namespace EProcessDemo.Api.Dtos;

public record class OrderDetailsDto(
    int Id,
    string Name,
    int CustomerId,
    int? KitchenId
);
