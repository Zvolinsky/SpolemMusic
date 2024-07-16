global using Microsoft.EntityFrameworkCore;
global using SpolemMusic.Data.Models;
global using SpolemMusic.Data;
using Microsoft.AspNetCore.Identity;
using SpolemMusic.Auth.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<EmailSender>();

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:5173")
.AllowAnyMethod()
.AllowAnyHeader());

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
