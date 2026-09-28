using System.ComponentModel.DataAnnotations;

namespace AspAuth.DTOs.Users;

public record UpdateUserDto(
    [property: StringLength(25)]
    string?  Username,
    [property: StringLength(25)]
    string? Password,
    [property: StringLength(25)]
    string? Email
);