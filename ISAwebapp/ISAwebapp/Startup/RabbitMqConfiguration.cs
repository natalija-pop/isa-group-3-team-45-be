using API.Controllers.Simulators;

namespace API.Startup
{
    public static class RabbitMqConfiguration
    {
        public static IServiceCollection ConfigureRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMqConnectionString>();
            return services;
        }
    }
}
