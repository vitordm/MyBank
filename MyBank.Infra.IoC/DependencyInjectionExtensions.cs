using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Application.Services.Contracts;
using MyBank.Infra.Data;
using MyBank.Infra.Data.Contracts;
using MyBank.Infra.Data.Contracts.Repositories;
using System;

namespace MyBank.Infra.IoC
{
    public static class DependencyInjectionExtensions
    {
        const string ConnectionStringName = "DefaultConnection";
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services
                .AddEntityFrameworkMySql()
                .AddDbContext<MyBankDbContext>(options =>
                {
                    options.UseMySql(
                        configuration.GetConnectionString(ConnectionStringName),
                        opts => opts.MigrationsAssembly(typeof(MyBankDbContext).Assembly.GetName().Name)
                    );
                }, ServiceLifetime.Transient);

            services.AddTransient<IEFUnitOfWork>(provider => provider.GetService<MyBankDbContext>());


            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(IRepository).Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });


            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(IService).Assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });

            services.AddAutoMapper(typeof(MyBankMapperProfile));

            return services;
        }

        public static IApplicationBuilder EnsureSeedData(this IApplicationBuilder app, IServiceProvider provider)
        {
            provider.GetRequiredService<MyBankDbContext>().Database.Migrate();

            return app;
        }
    }
}
