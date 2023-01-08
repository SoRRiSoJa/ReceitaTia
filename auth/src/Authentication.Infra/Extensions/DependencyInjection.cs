using authentication.Application.Commands;
using authentication.Application.Mappers;
using authentication.Application.Queries;
using authentication.Application.Util;
using authentication.Domain.Repositories;
using authentication.Infra.Data;
using authentication.Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;
using System.Security.Cryptography;

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
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddNewUserCommand));
            //services.AddMediatR(typeof(LoginCommand));
            //services.AddMediatR(typeof(GetUserByLoginQuery));

        }
        
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapperApi(typeof(UserMapper));
        }
        public static IServiceCollection AddAutoMapperApi(this IServiceCollection services, Type assemblyContainingMappers)
        {
            services.AddAutoMapper(expression =>
            {
                expression.AllowNullCollections = true;
            }, assemblyContainingMappers);

            return services;
        }
    }
}
