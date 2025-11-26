using Infrastructure.Logging;
using Domain.Services;
using Application.UseCases;
using AppLogger = Domain.Interfaces.ILogger;

namespace WebApi.Configuration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("bad", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddSingleton<AppLogger, Logger>();
            services.AddSingleton<OrderService>();
            services.AddTransient<CreateOrderUseCase>();
        }
    }
}
