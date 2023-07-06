using ApiEjemplo.Data;
using Microsoft.EntityFrameworkCore;

/*En esta clase agregamos la configuracion para que  inyec la dep. del Context donde se necesite*/


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//configuro mi app para que inyecte mi conexion donde se necesite
builder.Services.AddEntityFrameworkNpgsql().
    AddDbContext<Context>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("ConexionDatabase")));



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
