using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WebShop.Repository
{
    public interface IDbContext
    {
        string ConnectionString { get; }
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
    }
}