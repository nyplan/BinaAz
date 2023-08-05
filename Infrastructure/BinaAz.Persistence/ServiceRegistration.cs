using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Repositories;
using BinaAz.Persistence.Contexts;
using BinaAz.Persistence.Repositories;
using BinaAz.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BinaAz.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BinaAzDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        //services.AddHttpContextAccessor();
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IItemService, ItemService>();
    }
}