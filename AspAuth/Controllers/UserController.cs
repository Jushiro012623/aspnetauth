using AspAuth.DTOs.Users;
using AspAuth.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AspAuth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userService.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await userService.GetByIdAsync(id);
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        var user = await userService.CreateAsync(userDto);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
    {
        var updated = await userService.UpdateAsync(id, userDto);
        if(!updated) return NotFound();
        
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await userService.DeleteAsync(id);
        if(!deleted) return NotFound();
        
        return NoContent();
    }
}