using Microsoft.Extensions.DependencyInjection;
using Dapper.FluentMap;
using Cybertron.Mappings.Maps;

namespace Cybertron.Mappings
{
    public static class FluentMapping
    {
        public static IServiceCollection AddFluentMapping(this IServiceCollection services)
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new DictMap());
            });

            return services;
        }
    }
}
