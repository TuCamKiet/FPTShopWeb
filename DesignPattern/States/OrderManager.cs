using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.States
{
    public class OrderManager
    {
        private IOrderState _state;

        public Order Order { get; private set; }

        public OrderManager(Order order)
        {
            Order = order;
            _state = new PendingState(); // Default state
        }

        public void SetState(IOrderState state)
        {
            _state = state;
            _state.Handle(this);
        }
    }
}