﻿using DO_AN_FPT_SHOP.DesignPattern.RepositoryPattern;
using DO_AN_FPT_SHOP.Models;
using System;

namespace DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        IRepository<OrderVoucher> OrderVouchers { get; }
        void Commit();
    }
}
