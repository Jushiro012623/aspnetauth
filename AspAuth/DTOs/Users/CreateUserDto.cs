using System.ComponentModel.DataAnnotations;

namespace AspAuth.DTOs.Users;

public record CreateUserDto(
    [Required, StringLength(25)]
    string Username,
    
    [Required, StringLength(25)]
    string Password,
    
    [Required, StringLength(25)]
    string Email
);