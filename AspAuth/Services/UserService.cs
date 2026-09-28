using AspAuth.Data;
using AspAuth.DTOs.Users;
using AspAuth.Models;
using AspAuth.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspAuth.Services;

public class UserService(AppDbContext db) : IUserService
{

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        return await  db.Users
            .AsNoTracking()
            .Select(user => new UserResponseDto(user.Id, user.Username, user.Email, user.CreatedAt, user.UpdatedAt))
            .ToListAsync();
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        return await db.Users
            .AsNoTracking()
            .Where(user => user.Id == id)
            .Select(user => new UserResponseDto(user.Id, user.Username, user.Email, user.CreatedAt, user.UpdatedAt))
            .FirstOrDefaultAsync();
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username,
            Password = userDto.Password,
            Email = userDto.Email
        };
        
        db.Users.Add(user);

        await db.SaveChangesAsync();
        
        return new UserResponseDto(user.Id, user.Username, user.Email, user.CreatedAt, user.UpdatedAt);
    }

    public async Task<bool> UpdateAsync(int id, UpdateUserDto userDto)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return false;
        
        if(userDto.Username is not null) user.Username = userDto.Username;
        if(userDto.Email is not null) user.Email = userDto.Email;
        if(userDto.Password is not null) user.Password = userDto.Password;
        user.UpdatedAt = DateTime.UtcNow;
        
        await db.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return false;

        db.Users.Remove(user);
        return true;
    }
}