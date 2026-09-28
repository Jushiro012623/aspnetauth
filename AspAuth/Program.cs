using AspAuth.Data;
using AspAuth.Services;
using AspAuth.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AspAuth"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
