using ApiDbFirst.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyectamos el context:
builder.Services.AddDbContext<DbFirstContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDatabase")));

// le agregamos Cors para que lleguen las peticiones (sirve para restringuir las peticiones tambien)
builder.Services.AddCors();



var app = builder.Build();

//por tema de fechas en la base de datos:
AppContext.SetSwitch("Npgsql.EnableLegacyTimesTampBehavior",true);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//declaramos las politicas de los Cors
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();