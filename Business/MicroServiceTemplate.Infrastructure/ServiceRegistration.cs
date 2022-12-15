using MicroServiceTemplate.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceTemplate.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddAInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MicroServiceContext>(opt =>
        {
            opt.UseSqlServer(configuration["MicroServiceConnectionString"]);
            opt.EnableSensitiveDataLogging();
        });

       // services.AddScoped<IOrderRepository, OrderRepository>();

        var optionsBuilder = new DbContextOptionsBuilder<MicroServiceContext>()
            .UseSqlServer(configuration["MicroServiceConnectionString"]);

        using var dbContext = new MicroServiceContext(optionsBuilder.Options, null);
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();

        return services;
    }
}