using System;
using EProcessDemo.Api.Dtos;
using EProcessDemo.Api.Entities;

namespace EProcessDemo.Api.Mapping;

public static class CustomerMapping
{

    public static Customer ToEntity(this CreateCustomerDto customer)
    {
        return new Customer()
        {
            Name = customer.Name,
            Email = customer.Email,
        };
    }

    public static Customer ToEntity(this UpdateCustomerDto customer, int id)
    {
        return new Customer()
        {
            Id = id,
            Name = customer.Name,
            Email = customer.Email,
        };
    }

    public static CustomerSummaryDto ToCustomerSummaryDto(this Customer customer)
    {
        return new(
            customer.Id,
            customer.Name,
            customer.Email
        );
    }

    public static CustomerDetailsDto ToOrderDetailsDto(this Customer customer)
    {
        return new(
            customer.Id,
            customer.Name,
            customer.Email
        );
    }
}
