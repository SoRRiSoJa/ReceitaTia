using authentication.Infra.Mappers;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace authentication.Infra.Config
{
    public static class RegisterMapping
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMap());
                config.ForDommel();
            });
        }
    }
}
