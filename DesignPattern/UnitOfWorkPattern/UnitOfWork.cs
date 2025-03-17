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
            Customers = new Repository<Customer>(_db.Customers);
            Orders = new Repository<Order>(_db.Orders);
            OrderDetails = new Repository<OrderDetail>(_db.OrderDetails);
            OrderVouchers = new Repository<OrderVoucher>(_db.OrderVouchers);
        }

        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderDetail> OrderDetails { get; private set; }
        public IRepository<OrderVoucher> OrderVouchers { get; private set; }

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