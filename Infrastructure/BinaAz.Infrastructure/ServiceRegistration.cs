using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Abstractions.Token;
using BinaAz.Infrastructure.Services.Storages;
using BinaAz.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BinaAz.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}