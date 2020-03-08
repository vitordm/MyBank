using MyBank.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Contracts.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> ListAsync();
        Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> FindAsync(TKey key);
    }

    public interface IGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }

    public interface IGenericRepository<TEntity, TKey> : IGenericRepository<TEntity>,
        IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
    }
}
