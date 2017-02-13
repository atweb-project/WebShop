using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.Repository;

namespace WebShop.Services.Interfaces
{
    public interface IOrderService : IBaseService
    {
        List<Order> GetOrders();
        List<Order> GetOrders(Expression<Func<Order, bool>> filter);
        void SaveOrder(OrderViewModel orderViewModel);
        void DeleteOrder(Order order);
    }
}
