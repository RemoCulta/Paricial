using data;
using data.repositorio;
using Microsoft.Extensions.DependencyInjection;
using seguros.data.repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysql(builder.Configuration.GetConnectionString("mysqlConnection"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClienteRepository, clienteRepository>();
builder.Services.AddScoped<iEmpleadosRepository, empleadosRepository>();
builder.Services.AddScoped<iVentasRepository, ventasRepository>();
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
