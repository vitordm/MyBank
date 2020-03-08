using MyBank.Domain.Contracts;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System.Threading.Tasks;
namespace MyBank.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task InsertAsync(TEntity entity)
        {
            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>()
                .Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }

    public class GenericRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>, IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public GenericRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task InsertAsync(TEntity entity)
        {
            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>()
                .Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
