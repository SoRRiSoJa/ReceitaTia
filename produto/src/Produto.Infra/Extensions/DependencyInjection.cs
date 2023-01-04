﻿using Microsoft.Extensions.DependencyInjection;
using Produto.Application.Commands.Marca.AdicionarMarca;
using Produtos.Domain.Repositories;
using Produtos.Infra.Abstractions;
using Produtos.Infra.Data;
using Produtos.Infra.Repositories;
using MediatR;

namespace Produtos.Infra.Extensions
{
    public static class DependencyInjection
    {
        public static void AddUoW(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
        }
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AdicionarMarcaCommand));
        }
    }
}
