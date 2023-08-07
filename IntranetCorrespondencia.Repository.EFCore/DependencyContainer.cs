using IntranetCorrespondencia.Entities.Interfaces;
using IntranetCorrespondencia.Repository.EFCore.DBContext;
using IntranetCorrespondencia.Repository.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntranetCorrespondencia.Repository.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration, string migrationAssemblyName)
        {
            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<IntranetCorrespondenciaContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IntranetCorrespondenciaDb"), x => x.MigrationsAssembly(migrationAssemblyName));
            }, ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
