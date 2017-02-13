using System.Collections.Generic;
using WebShop.Infrastructure.AutoMapper;

namespace WebShop.Services.Mapping
{
    public class MappingTypes : IMappingTypes
    {
        public MappingTypes()
        {
            MappingTypesCollection = new List<System.Type>()
            {
                typeof(RegisterMapping)
            };
        }
        public IList<System.Type> MappingTypesCollection { get; set; }

    }
}