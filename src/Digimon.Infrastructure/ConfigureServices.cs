using Digimon.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Digimon.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Digimon.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DigimonDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Digimon"))
        );
        
        services.AddScoped<IDigimonDbContext>(provider => provider.GetRequiredService<DigimonDbContext>());
    }
}