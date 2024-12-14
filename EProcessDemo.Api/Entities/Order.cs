using System;

namespace EProcessDemo.Api.Entities;

public class Order
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int? KitchenId { get; set; }
    public Kitchen? Kitchen { get; set; }

}
