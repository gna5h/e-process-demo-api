using System.ComponentModel.DataAnnotations;

namespace EProcessDemo.Api.Dtos;

public record class CreateOrderDto(
    [Required][StringLength(50)] string Name,
    int CustomerId,
    int? KitchenId
);
