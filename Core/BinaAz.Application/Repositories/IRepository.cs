using System.Linq.Expressions;
using BinaAz.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> Table { get; }

    IQueryable<TEntity> GetAll(bool tracking = true);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    Task<TEntity?> GetByIdAsync(string id, bool tracking = true);

    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(List<TEntity> entities);
    bool Remove(TEntity entity);
    bool RemoveRange(List<TEntity> entities);
    Task<bool> RemoveAsync(string id);
    void Update(TEntity entity);
    Task<int> SaveAsync();
}