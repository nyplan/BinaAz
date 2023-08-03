using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Abstractions.Token;
using BinaAz.Infrastructure.Enums;
using BinaAz.Infrastructure.Services.Storages;
using BinaAz.Infrastructure.Services.Storages.Azure;
using BinaAz.Infrastructure.Services.Storages.Local;
using BinaAz.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BinaAz.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }

    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.Local:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure:
                serviceCollection.AddScoped<IStorage, AzureStorage>();
                break;
            default:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}