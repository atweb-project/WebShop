using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Model;
using WebShop.Repository;
using WebShop.Services.Interfaces;

namespace WebShop.Services.Implementations
{
    public class ItemService : BaseService, IItemService
    {
        public ItemService(IDbContext dbContext, UnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public List<Item> GetItems()
        {
            return this._dbContext.Set<Item>().ToList();
        }

        public List<Item> GetItems(Expression<Func<Item, bool>> filter)
        {
            return this._unitOfWork.Repository<Item>().FindBy(filter).ToList();
        }

        public void SaveItem(ItemViewModel itemViewModel)
        {
            var item = Mapper.Map<ItemViewModel, Item>(itemViewModel);
            item.State = ObjectState.Added;
            this._unitOfWork.Repository<Item>().Insert(item);
            this._unitOfWork.Save();
        }

        public void DeleteItem(Item item)
        {
            if (item.State == ObjectState.Deleted)
            {
                this._unitOfWork.Repository<Item>().Delete(item);
                this._unitOfWork.Save();
            }
        }
    }
}
