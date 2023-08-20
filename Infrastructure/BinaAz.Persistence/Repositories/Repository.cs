using System.Linq.Expressions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.Common;
using BinaAz.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BinaAz.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{ 
    private readonly BinaAzDbContext _context;
    public Repository(BinaAzDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();
   
    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        => tracking ? Table.Where(expression) : Table.Where(expression).AsNoTracking();

    public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        =>  tracking ? 
            await Table.FirstOrDefaultAsync(expression) : 
            await Table.AsNoTracking().FirstOrDefaultAsync(expression);
    
    public async Task<bool> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry =  Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public void Update(TEntity entity)
    {
        Table.Update(entity);
    }

    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
   
}