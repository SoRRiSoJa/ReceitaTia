using authentication.Domain.Repositories;
using authentication.Infra.Data;
using authentication.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;

namespace authentication.Infra.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDapperSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(provider =>
            {
                return new NpgsqlConnection(connectionString);
            });
        }
        public static void AddDbSession(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
             services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
