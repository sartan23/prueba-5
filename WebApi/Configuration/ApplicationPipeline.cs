using Infrastructure.Data;

namespace WebApi.Configuration
{
    public static class ApplicationPipeline
    {
        public static void UseApplicationPipeline(this WebApplication app)
        {
            app.UseCors("bad");

            app.Use(async (ctx, next) =>
            {
                try { await next(); } catch { await ctx.Response.WriteAsync("oops"); }
            });

            app.MapGet("/health", (Domain.Interfaces.ILogger logger) =>
            {
                logger.Log("health ping");
                var x = new Random().Next();
                return "ok " + x;
            });

            app.MapGet("/orders/last", (Domain.Services.OrderService service) => service.LastOrders);

            app.MapPost("/orders", async (Application.UseCases.CreateOrderUseCase uc,
                                         HttpContext http) =>
            {
                using var reader = new StreamReader(http.Request.Body);
                var body = await reader.ReadToEndAsync();

                var parts = (body ?? "").Split(',');
                var customer = parts.Length > 0 ? parts[0] : "anon";
                var product = parts.Length > 1 ? parts[1] : "unknown";
                var qty = parts.Length > 2 ? int.Parse(parts[2]) : 1;
                var price = parts.Length > 3 ? decimal.Parse(parts[3]) : 0.99m;

                var order = uc.Execute(customer, product, qty, price);

                return Results.Ok(order);
            });
            app.MapGet("/info", (IConfiguration cfg) => new
            {
                sql = BadDb.ConnectionString,
                env = Environment.GetEnvironmentVariables(),
                version = "v0.0.1-unsecure"
            });
        }
    }
}
