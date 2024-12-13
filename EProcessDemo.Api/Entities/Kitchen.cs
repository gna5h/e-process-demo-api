using System;

namespace EProcessDemo.Api.Entities;

public class Kitchen
{
    public int Id { get; set; }

    public required int Length { get; set; }

    public required int Width { get; set; }

    public required string Type { get; set; }

    public required string Color { get; set; }

    public Order? Order { get; set; }
}
