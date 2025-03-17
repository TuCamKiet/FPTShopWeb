using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBFPTSHOPEntities _db;

        public UnitOfWork()
        {
            _db = DBContextSingleton.Instance;
            Customers = new Repository<Customer>(_db);
            Orders = new Repository<Order>(_db);
            OrderDetails = new Repository<OrderDetail>(_db);
            OrderVouchers = new Repository<OrderVoucher>(_db);
            Products = new Repository<Product>(_db); // Add Product repository
            Users = new Repository<User>(_db); // Add User repository
        }

        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderDetail> OrderDetails { get; private set; }
        public IRepository<OrderVoucher> OrderVouchers { get; private set; }
        public IRepository<Product> Products { get; private set; } // Add Product repository
        public IRepository<User> Users { get; private set; } // Add User repository

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}