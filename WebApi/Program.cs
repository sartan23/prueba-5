using Application.UseCases;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar dependencias básicas en el contenedor de DI.
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddTransient<CreateOrderUseCase>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok("BadCleanArch API is running")); 

app.MapPost("/orders", (CreateOrderUseCase useCase, OrderRequest request) =>
{
    var order = useCase.Execute(request.CustomerName, request.ProductName, request.Quantity, request.UnitPrice);
    return Results.Created($"/orders/{order.Id}", order);
});

app.Run();

/// <summary>
/// DTO utilizado por el endpoint para recibir datos de la orden.
/// Se define dentro de Program.cs solo para simplificar el ejemplo.
/// </summary>
public record OrderRequest(string CustomerName, string ProductName, int Quantity, decimal UnitPrice);
