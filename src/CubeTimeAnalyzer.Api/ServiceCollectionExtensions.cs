using CubeTimeAnalyzer.Api.Core.Interfaces;
using CubeTimeAnalyzer.Api.Core.services;
using CubeTimeAnalyzer.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CubeTimeAnalyzer.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["SQL_Connection_String"];

        services.AddDbContext<CubeTimeAnalyzerContext>(o =>
            o.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration config)
    {
        if (config.GetValue<bool>("EnableMockData"))
        {
            services.AddSingleton<ITimeService, MockTimeService>();
        }
        else
        {
            services.AddScoped<ITimeService, TimeService>();
        }

        return services;
    }
}
