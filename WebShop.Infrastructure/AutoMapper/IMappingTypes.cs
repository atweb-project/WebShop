using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Repository;
using Type = System.Type;

namespace WebShop.Infrastructure.AutoMapper
{
    public interface IMappingTypes
    {
        IList<Type> MappingTypesCollection { get; set; }
    }
}
