using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDbContext context;
        protected bool disposed;
        protected Hashtable repositories;
        public string ConnectionString
        {
            get
            {
                return context.ConnectionString;
            }
        }
        public UnitOfWork(IDbContext contextPar)
        {
            context = contextPar;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            try{
                var id = context.SaveChanges();
            }
            catch (Exception){
                // Log Errors 
                throw;
            }
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed) if (disposing) context.Dispose();

            disposed = true;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();
            
            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }
    }
}
