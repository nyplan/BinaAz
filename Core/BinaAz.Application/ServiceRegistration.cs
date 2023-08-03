using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BinaAz.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        //services.AddHttpClient();
    }
}