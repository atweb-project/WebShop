﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebShopEntities : DbContext , IDbContext
    {
        public WebShopEntities()
            : base("name=WebShopEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }


        public WebShopEntities(string connectionString)
            : base(connectionString)
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 120; // value in seconds
            ConnectionString = Database.Connection.ConnectionString;
        }
        public string ConnectionString { get; }
        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TrOrder> TrOrders { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<SaleType> SaleTypes { get; set; }
    }
}
