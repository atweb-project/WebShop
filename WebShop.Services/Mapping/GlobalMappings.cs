using AutoMapper;
using AutoMapper.Configuration;
using WebShop.Infrastructure.AutoMapper;

namespace WebShop.Services.Mapping
{
    public class GlobalMappings
    {
        private readonly IMappingTypes _mappingTypes;

        public GlobalMappings(IMappingTypes mappingTypes)
        {
            _mappingTypes = mappingTypes;
        }

        public void Initialize()
        {
            var config = new MapperConfigurationExpression();

            // BASE MODEL MAPPINGS.

            // INJECTED MAPPINGS.
            foreach (var type in _mappingTypes.MappingTypesCollection)
                config.AddProfile(type);

            // INIT.
            Mapper.Initialize(config);
        }
    }
}