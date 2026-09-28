namespace AspAuth.DTOs.Users;

public record UserResponseDto(
    long Id,
    string Username,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
);