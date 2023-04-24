using ApiDomino.Data;
using ApiDomino.Models;
using ApiDomino.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion de Entity Framework para la conexion con SQL Server
builder.Services.AddSqlServer<DominoContext>(builder.Configuration.GetConnectionString("CadenaSql"));

//dependencias del Servicio CadenasDomino
//builder.Services.AddScoped<ICadenaDominoServices, CadenaDominoServices>();
//builder.Services.AddScoped<Ficha>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
