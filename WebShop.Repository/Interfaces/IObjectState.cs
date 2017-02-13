using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Repository
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState State { get; set; }
    }
}