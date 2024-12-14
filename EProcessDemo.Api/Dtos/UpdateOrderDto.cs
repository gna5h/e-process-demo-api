using System.ComponentModel.DataAnnotations;

namespace EProcessDemo.Api.Dtos;

public record class UpdateOrderDto(
    [Required][StringLength(50)] string Name,
    int CustomerId,
    int? KitchenId
);
