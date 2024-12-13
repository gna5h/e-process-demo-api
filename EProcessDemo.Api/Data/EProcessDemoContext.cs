using System;
using EProcessDemo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EProcessDemo.Api.Data;

public class EProcessDemoContext(DbContextOptions<EProcessDemoContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Kitchen> Kitchens => Set<Kitchen>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Kitchen)
            .WithOne(k => k.Order)
            .HasForeignKey<Order>(o => o.KitchenId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
