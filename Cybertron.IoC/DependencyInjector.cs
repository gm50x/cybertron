using Microsoft.Extensions.DependencyInjection;
using Cybertron.Core.Interfaces.Commands;
using Cybertron.Core.Commands;
using Cybertron.Infrastructure.UoW;
using Cybertron.Infrastructure.Interfaces;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace Cybertron.IoC
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddDatabaseConnections(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(x => {
                var connectionString = x.GetService<IConfiguration>().GetConnectionString("Main");
                return new NpgsqlConnection(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IGetRandomWord, GetRandomWord>();
            services.AddScoped<IGetAllWords, GetAllWords>();
            services.AddScoped<IGetWordByName, GetWordByName>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services;
        }
    }
}
