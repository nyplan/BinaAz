using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BinaAz.Persistence.BackgroundServices;

public class SubscriptionsBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scope;
    public SubscriptionsBackgroundService(IServiceScopeFactory scope)
    {
        _scope = scope;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scope.CreateScope();
            var itemRepository = scope.ServiceProvider.GetService<IRepository<Item>>();

            var items = await itemRepository
                .GetWhere(x => x.VipEnds < DateTime.UtcNow || x.PremiumEnds < DateTime.UtcNow)
                .ToListAsync(stoppingToken);
            items.ForEach(x =>
            {
                x.IsVip = false;
                x.IsPremium = false;
            });
            await itemRepository.SaveAsync();
            
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}