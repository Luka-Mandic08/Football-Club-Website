using FootballClubBackend.Controllers;
using FootballClubBackend.Database;
using FootballClubBackend.Helper;
using FootballClubBackend.Repository;
using FootballClubBackend.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddDbContext<FootballClubDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var addScoped = new Helper(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<Middleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
