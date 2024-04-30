using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaTecnica2.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("nuevaPolitica",
                      app =>
                      {
                          app
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApipruebatecnicaContext>(OptionsBuilder =>
                OptionsBuilder.UseMySql(builder.Configuration.GetConnectionString("conexion"),
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32 - mariadb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("nuevaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
