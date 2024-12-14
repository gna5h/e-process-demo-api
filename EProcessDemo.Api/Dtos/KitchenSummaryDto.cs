namespace EProcessDemo.Api.Dtos;

public record class KitchenSummaryDto(
    int Id,
    string Type,
    string Color,
    int Length,
    int Width
);
