using AspAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace AspAuth.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
