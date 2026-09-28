namespace AspAuth.Models;

public class User
{
    public long Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}