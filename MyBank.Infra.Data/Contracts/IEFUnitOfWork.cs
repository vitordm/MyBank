using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;


namespace MyBank.Infra.Data.Contracts
{
    public interface IEFUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        DbConnection GetDbConnection();


        [Obsolete]
        DbQuery<TQuery> Query<TQuery>() where TQuery : class;
    }
}
