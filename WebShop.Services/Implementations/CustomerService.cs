using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Repository;
using WebShop.Services.Interfaces;

namespace WebShop.Services.Implementations
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IDbContext dbContext, UnitOfWork unitOfWork)
           : base(dbContext, unitOfWork)
        {

        }

        public List<Customer> GetCustomers()
        {
            return this._unitOfWork.Repository<Customer>().Query().Get().ToList();
        }

        public List<Customer> GetCustomers(Expression<Func<Customer, bool>> filter )
        {
            return this._unitOfWork.Repository<Customer>().FindBy(filter).ToList();
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.State == ObjectState.Added)
                this._unitOfWork.Repository<Customer>().Insert(customer);
            else if (customer.State == ObjectState.Modified)
                this._unitOfWork.Repository<Customer>().Update(customer);

            this._unitOfWork.Save();
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer.State == ObjectState.Deleted)
            {
                this._unitOfWork.Repository<Customer>().Delete(customer);
                this._unitOfWork.Save();
            }
        }
    }
}
