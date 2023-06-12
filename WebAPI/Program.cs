using Application;
using Microsoft.OpenApi.Models;
using Persistence;
using Shared;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Referencia a ServiceExtensions de Application
builder.Services.AddApplicationLayer();
//Referencia a ServiceExtensions de Persistence
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
//Referencia a ServiceExtensions de Shared
builder.Services.AddShareInfraestructure(builder.Configuration);
//Referencia a ServiceExtensions de WebApi
builder.Services.AddApiVersioningExtension();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
        // la siguiente línea configura la ruta de la página swagger UI
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Agregar los exceptions hechos, a traves de este middleware
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
