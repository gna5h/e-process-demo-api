using System.ComponentModel.DataAnnotations;

namespace EProcessDemo.Api.Dtos;

public record class UpdateCustomerDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Email
);
