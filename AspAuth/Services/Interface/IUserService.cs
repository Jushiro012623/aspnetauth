using AspAuth.DTOs.Users;
using AspAuth.Models;

namespace AspAuth.Services.Interface;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<UserResponseDto> CreateAsync(CreateUserDto user);
    Task<bool> UpdateAsync(int id, UpdateUserDto user);
    Task<bool> DeleteAsync(int id);
}