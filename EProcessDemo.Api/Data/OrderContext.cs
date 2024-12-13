using System;
using EProcessDemo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Data;

public class OrderContext(DbContextOptions<OrderContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Kitchen> Kitchens => Set<Kitchen>();
}
