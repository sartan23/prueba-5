using Application.UseCases;
using Domain.Abstractions;
using Infrastructure.Data;
using Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// Registra el ingreso que se implemento en la interfaz del dominio
builder.Services.AddSingleton<Domain.Abstractions.ILogger, Logger>();

// Reagistra el repositorio de SQL validando la conexión
builder.Services.AddSingleton<IOrderRepository>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("Sql")
        ?? throw new InvalidOperationException("Missing connection string 'Sql'");
    return new SqlOrderRepository(connectionString);
});
    
// Registrar caso de uso
builder.Services.AddTransient<CreateOrderUseCase>();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
await app.RunAsync();