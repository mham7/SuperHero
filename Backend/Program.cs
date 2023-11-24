global using Backend.Models;
global using Backend.Data;
using Backend.Services.SuperHeroServices;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Backend.Services.UserServices;




// Add services to the container.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IUserService, UserService>();
//var configuration = builder.Configuration.GetConnectionString("SuperHeroDbConnection");
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<UserDataContext>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
