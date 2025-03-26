using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Doctors.Infrastructure;
public static class MassTransitExtensions
{ 
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(MassTransitExtensions).Assembly);
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
        
                cfg.ReceiveEndpoint("queue", e =>
                {
                    e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(0.2)));
                    e.ConfigureConsumers(context);
                });
            });
        });
        return services;
    }
}
