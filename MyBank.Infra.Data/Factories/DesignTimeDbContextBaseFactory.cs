using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MyBank.Infra.Data.Factories
{
    public abstract class DesignTimeDbContextBaseFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        public const string ConnectionStringName = "DefaultConnection";
        //$env:ASPNETCORE_ENVIRONMENT='Development'

        public TContext CreateDbContext(string[] args)
        {
            string environmentVariable = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);
            if (string.IsNullOrEmpty(environmentVariable))
            {
                Environment.SetEnvironmentVariable(AspNetCoreEnvironment, "Development");
            }

            //return Create(Directory.GetCurrentDirectory(), Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
            return Create(AppContext.BaseDirectory, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }


        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext Create()
        {
            string basePath = AppContext.BaseDirectory;
            string environmentName = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            return Create(basePath, environmentName);
        }

        private TContext Create(string basePath, string environmentName)
        {
            Console.WriteLine($"DbContextFactoryBase.Create(string, string): Base Path: {basePath}");
            Console.WriteLine($"DbContextFactoryBase.Create(string, string): Environment Name: {environmentName}");

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString(ConnectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Could not find a connection string named '{ConnectionStringName}'.");
            }

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));
            }

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseMySql(connectionString);

            Console.WriteLine("DbContextFactoryBase.Create(string): Connection string: {0}", connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
