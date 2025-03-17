using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.States
{
    public interface IOrderState
    {
        void Handle(OrderManager orderManager);
    }

    public class PendingState : IOrderState
    {
        public void Handle(OrderManager orderManager)
        {
            // Handle pending state
            orderManager.Order.OrderStatus = 0;
        }
    }

    public class ConfirmedState : IOrderState
    {
        public void Handle(OrderManager orderManager)
        {
            // Handle confirmed state
            orderManager.Order.OrderStatus = 2;
        }
    }

    public class CanceledState : IOrderState
    {
        public void Handle(OrderManager orderManager)
        {
            // Handle canceled state
            orderManager.Order.OrderStatus = 1;
        }
    }
}