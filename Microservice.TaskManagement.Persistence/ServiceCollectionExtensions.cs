using Microservice.TaskManagement.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddPostgres();
            return services;
        }

        #region Postgres

        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            var postgreSqlDbConnection = configuration.GetSection("DbConnection").Value;
            if (postgreSqlDbConnection is null) throw new ArgumentNullException(nameof(postgreSqlDbConnection));

            services.AddDbContext<TaskManagementContext>(builder =>
                builder.UseNpgsql(postgreSqlDbConnection, optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure();
                })
            );

            return services;
        }

        public static IApplicationBuilder UseAutoMigrateDatabase<TDbContext>(this IApplicationBuilder builder)
    where TDbContext : DbContext
        {
            using var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<TDbContext>()?.Database.Migrate();

            return builder;
        }

        #endregion
    }
}
