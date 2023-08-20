using System.Linq.Expressions;
using BinaAz.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> Table { get; }

    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);

    Task<bool> AddAsync(TEntity entity);
    bool Remove(TEntity entity);
    void Update(TEntity entity);
    Task<int> SaveAsync();
}