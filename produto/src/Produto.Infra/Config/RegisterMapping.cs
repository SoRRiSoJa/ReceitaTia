using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Produtos.Infra.Mappers;

namespace Produtos.Infra.Config
{
    public static class RegisterMapping
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new MarcaMap());
                config.ForDommel();
            });
        }
    }
}
