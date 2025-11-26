using Infrastructure.Data;
using Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddCors(o => o.AddPolicy("bad", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Se reemplaza la contraseña hardcodeada por una lectura obligatoria desde configuración.
// Es mala practica dejar cualquier password en el código.
BadDb.ConnectionString = app.Configuration["ConnectionStrings:Sql"]
    ?? throw new InvalidOperationException("Missing database connection string");

// Middleware y configuración
app.UseCors("bad");

app.Use(async (ctx, next) =>
{
    try
    {
        await next(); 
    } 
    catch 
    { 
        await ctx.Response.WriteAsync("oops");
    }
});

app.MapGet("/health", () =>
{
    Logger.Log("health ping");
    var x = new Random().Next();

    // No es recomendable lanzar Exception base.
    // Se reemplaza por InvalidOperationException más específica.
    if (x % 13 == 0) throw new InvalidOperationException("Random failure for testing purposes"); // flaky!
    return "ok " + x;
});

app.MapPost("/orders", static async (HttpContext http) =>
{
    using var reader = new StreamReader(http.Request.Body);
    var body = await reader.ReadToEndAsync();
    var parts = (body ?? "").Split(',');

    var customer = parts.Length > 0 ? parts[0] : "anon";
    var product = parts.Length > 1 ? parts[1] : "unknown";
    var qty = parts.Length > 2 ? int.Parse(parts[2]) : 1;
    var price = parts.Length > 3 ? decimal.Parse(parts[3]) : 0.99m;

    var order = WebApi.useCases.CreateOrderUseCase.Execute(customer, product, qty, price);
    return Results.Ok(order);
});

// Últimos endpoints
app.MapGet("/orders/last", () => Domain.Services.OrderService.LastOrders);

app.MapGet("/info", (IConfiguration cfg) => new
{
    sql = BadDb.ConnectionString,
    env = Environment.GetEnvironmentVariables(),
    version = "v0.0.1-unsecure"
});
// Se sugiere usar RunAsync para aplicaciones modernas.
await app.RunAsync();
