using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BinaAz.Persistence.BackgroundServices;

public class ItemPublishBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ItemPublishBackgroundService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetService<IRepository<Item>>();

        var items = db?.GetWhere(x => x.Status == ItemStatus.Waiting);
        
        
        
        
        
        
        
        
        await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
    }
}