using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Produto.Application.Commands.Marca;
using Produto.Application.Commands.ProdutoCommands;
using Produto.Application.Queries.MarcaQueries;
using Produto.Application.Queries.ProdutosQueries;
using Produto.Application.Validations;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Repositories;
using Produtos.Infra.Data;
using Produtos.Infra.Repositories;
using System.Data.Common;
using System.Globalization;

namespace Produtos.Infra.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDapperSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(provider =>
            {
                return new NpgsqlConnection(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddUoW(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IPrePreparoRepository, PrePreparoRepository>();
        }
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AdcionarMarcaCommand));
            services.AddMediatR(typeof(AdcionarProdutoCommand));

            services.AddMediatR(typeof(ObterMarcaPorIdQuery));
            services.AddMediatR(typeof(ObterTodasAsMarcasQuery));
            services.AddMediatR(typeof(ObterProdutoPorIdQuery));
            services.AddMediatR(typeof(ObterProdutosPorMarcaQuery));
            services.AddMediatR(typeof(ObterTodosOsProdutosQuery));
        }

        [Obsolete]
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(typeof(AdcionarMarcaCommandValidator));
            services.AddFluentValidation(typeof(AdcionarProdutoCommandValidator));
        }
        [Obsolete]
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
        {
            _ = services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
                conf.AutomaticValidationEnabled = false;
                conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });

            return services;
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
