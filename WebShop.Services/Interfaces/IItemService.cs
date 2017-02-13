using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.Repository;
using WebShop.Services.Interfaces;

namespace WebShop.Services.Interfaces
{
    public interface IItemService : IBaseService
    {
        List<Item> GetItems();

        List<Item> GetItems(Expression<Func<Item, bool>> filter);

        void SaveItem(ItemViewModel itemViewModel);

        void DeleteItem(Item item);
    }
}
