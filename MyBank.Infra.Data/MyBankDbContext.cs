using Microsoft.EntityFrameworkCore;
using MyBank.Infra.Data.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data
{
    public class MyBankDbContext : EFUnitOfWork
    {
        public MyBankDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyBankDbContext).Assembly);
        }
    }

    public class AppDbContextDesignFactory : DesignTimeDbContextBaseFactory<MyBankDbContext>
    {
        protected override MyBankDbContext CreateNewInstance(DbContextOptions<MyBankDbContext> options)
        {
            return new MyBankDbContext(options);
        }
    }
}
