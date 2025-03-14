using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Templates
{
    public class CancelOrder : OrderTemplate
    {
        protected override object GetProductOrOrder(int id)
        {
            return db.OrderDetails.Where(r => r.OrderDetailID == id).FirstOrDefault();
        }

        protected override User GetUser()
        {
            return System.Web.HttpContext.Current.Session["Account"] as User;
        }

        protected override bool ValidateUser(User user)
        {
            var cus = db.Customers.Where(r => r.UserName == user.UserName).FirstOrDefault();
            return cus != null;
        }

        protected override void ExecuteOrder(User user, object productOrOrder)
        {
            var orDe = productOrOrder as OrderDetail;
            var order = db.Orders.Where(r => r.OrderID == orDe.OrderID && r.OrderStatus == 0).FirstOrDefault();
            if (orDe != null && order != null)
            {
                order.TotalQuantity -= orDe.Quantity;
                order.TotalPrice -= orDe.Price;
                db.OrderDetails.Remove(orDe);

                if (order.TotalQuantity == 0)
                {
                    order.Customers.Clear();
                    db.Orders.Remove(order);
                }

                db.SaveChanges();
            }
        }
    }
}
