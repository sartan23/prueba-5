using Infrastructure.Data;
using WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
BadDb.ConnectionString = builder.Configuration["ConnectionStrings:Sql"]
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión.");


builder.Logging.ClearProviders();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseApplicationPipeline();

await app.RunAsync();
