using System.Reflection;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGround;
using Microsoft.Extensions.DependencyInjection;

namespace BinaAz.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<AddGroundCommandHandler>());

        //services.AddHttpClient();
    }
}