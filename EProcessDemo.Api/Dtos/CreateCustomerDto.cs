using System.ComponentModel.DataAnnotations;

namespace EProcessDemo.Api.Dtos;

public record class CreateCustomerDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Email
);
