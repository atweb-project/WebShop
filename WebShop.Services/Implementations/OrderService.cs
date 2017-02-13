using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class OrderService : BaseService , IOrderService
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="unitOfWork"></param>
        public OrderService(IDbContext dbContext, UnitOfWork unitOfWork) 
            : base(dbContext, unitOfWork)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            return this._unitOfWork.Repository<Order>().Query().Get().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Order> GetOrders(Expression<Func<Order, bool>> filter)
        {
            return this._unitOfWork.Repository<Order>().FindBy(filter).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderViewModel"></param>
        public void SaveOrder(OrderViewModel orderViewModel)
        {
            var order = Mapper.Map<OrderViewModel, Order>(orderViewModel);
            order.State = ObjectState.Added;
            order.Customer = Mapper.Map<CustomerViewModel,Customer>(orderViewModel.Customer);
            order.Customer.State = ObjectState.Added;
            order.TrOrders = Mapper.Map<List<ItemViewModel>, List<TrOrder>>(orderViewModel.ListOfItemViewModels);
            foreach (var trOrder in order.TrOrders)
                trOrder.State = ObjectState.Added;
            
            this._unitOfWork.Repository<Order>().InsertGraph(order);
            this._unitOfWork.Save();
        }

        public void DeleteOrder(Order order)
        {
            if (order.State == ObjectState.Deleted)
            {
                this._unitOfWork.Repository<Order>().Delete(order);
                this._unitOfWork.Save();
            }
        }
    }
}
//if (order.State == ObjectState.Added)
//     this._unitOfWork.Repository<Order>().Insert(order);
//else if (order.State == ObjectState.Modified)
//    this._unitOfWork.Repository<Order>().Update(order);