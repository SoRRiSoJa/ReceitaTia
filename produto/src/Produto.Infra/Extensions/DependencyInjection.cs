using Microsoft.Extensions.DependencyInjection;
using Produtos.Infra.Abstractions;
using Produtos.Infra.Data;

namespace Produtos.Infra.Extensions
{
    public static class DependencyInjection
    {
        public static void AddUoW(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
