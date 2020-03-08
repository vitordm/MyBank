using Microsoft.EntityFrameworkCore;
using MyBank.Domain.Contracts;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repositories
{

    public abstract class BaseRepository : IRepository
    {
        protected IEFUnitOfWork UnitOfWork { get; private set; }

        protected BaseRepository(IEFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IEFUnitOfWork UnitOfWork { get; private set; }

        protected BaseRepository(IEFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await UnitOfWork.Set<TEntity>()
                .Where(predicate)
                .FirstOrDefaultAsync();

        public async Task<IList<TEntity>> ListAsync()
            => await UnitOfWork.Set<TEntity>()
                .ToListAsync();

        public async Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public IQueryable<TEntity> Query()
            => UnitOfWork.Set<TEntity>().AsNoTracking().AsQueryable();

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .AsQueryable();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await UnitOfWork.Set<TEntity>().AddAsync(entity);
        }

    }

    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected IEFUnitOfWork UnitOfWork { get; private set; }

        protected BaseRepository(IEFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> FindAsync(TKey id)
            => await UnitOfWork.Set<TEntity>()
                .Where(e => e.Id.Equals(id))
                .FirstOrDefaultAsync();

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await UnitOfWork.Set<TEntity>()
                .Where(predicate)
                .FirstOrDefaultAsync();

        public virtual async Task<IList<TEntity>> ListAsync()
        {
            return await UnitOfWork.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public IQueryable<TEntity> Query()
            => UnitOfWork.Set<TEntity>().AsNoTracking().AsQueryable();

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .AsQueryable();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await UnitOfWork.Set<TEntity>().AddAsync(entity);
        }
    }


}
