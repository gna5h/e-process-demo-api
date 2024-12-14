using System.ComponentModel.DataAnnotations;

namespace EProcessDemo.Api.Dtos;

public record class CreateKitchenDto(
    [Required][StringLength(50)] string Type,
    [Required][StringLength(50)] string Color,
    [Required] int Length,
    [Required] int Width
);
