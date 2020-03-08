using Microsoft.EntityFrameworkCore;
using MyBank.Infra.Data.Contracts;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace MyBank.Infra.Data
{
    public abstract class EFUnitOfWork : DbContext, IEFUnitOfWork
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected EFUnitOfWork(
            DbContextOptions options)
            : base(options)
        {
        }

        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }

        public void Rollback()
        {
            Database.RollbackTransaction();
        }

        public DbConnection GetDbConnection() => Database.GetDbConnection();

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //return Database.ExecuteSqlCommand(sqlCommand, parameters);
            return Database.ExecuteSqlRaw(sqlCommand, parameters);
        }

        public Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlRawAsync(sqlCommand, parameters);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            if (environment != null && environment.Equals("Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
