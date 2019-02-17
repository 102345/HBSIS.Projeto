using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using HBSIS.Data.Mappers;

namespace HBSIS.Data
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new LivroMap());
                config.ForDommel();
            });
        }
    }

}
