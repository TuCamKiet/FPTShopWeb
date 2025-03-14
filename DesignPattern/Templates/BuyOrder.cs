using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DO_AN_FPT_SHOP.Models;
using System.Linq;
using DO_AN_FPT_SHOP.Controllers;

namespace DO_AN_FPT_SHOP.Templates
{
    public class BuyOrder : OrderTemplate
    {
        protected override object GetProductOrOrder(int id)
        {
            return ProductsController.GetDetails(id);
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
            var product = productOrOrder as ViewModelProduct;
            var cus = db.Customers.Where(r => r.UserName == user.UserName).FirstOrDefault();
            var CusOrders = cus.Orders.Where(r => r.OrderStatus == 0).ToList();

            if (CusOrders.Count == 0)
            {
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    TotalPrice = (decimal)product.PriceList[0],
                    TotalQuantity = 1,
                    OrderStatus = 0
                };
                order.Customers.Add(cus);

                OrderDetail item = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProDeID = product.ProDetail.ProDeID,
                    Quantity = 1,
                    Price = (decimal)product.PriceList[0]
                };

                db.Orders.Add(order);
                db.OrderDetails.Add(item);
                cus.Orders.Add(order);
                db.SaveChanges();
            }
            else
            {
                var ordering = CusOrders.FirstOrDefault();
                var unpaidItems = db.OrderDetails.Where(r => r.OrderID == ordering.OrderID).ToList();
                foreach (var item in unpaidItems)
                {
                    if (item.ProDeID == product.ProDetail.ProDeID)
                    {
                        item.Quantity += 1;
                        item.Price = (decimal)(product.PriceList[0] * item.Quantity);
                        db.SaveChanges();

                        var totalQuan1 = unpaidItems.Sum(r => r.Quantity);
                        var totalPrice1 = unpaidItems.Sum(r => r.Price);
                        ordering.TotalQuantity = totalQuan1;
                        ordering.TotalPrice = totalPrice1;
                        db.SaveChanges();
                        return;
                    }
                }

                OrderDetail newitem = new OrderDetail
                {
                    OrderID = ordering.OrderID,
                    ProDeID = product.ProDetail.ProDeID,
                    Quantity = 1,
                    Price = (decimal)product.PriceList[0]
                };
                db.OrderDetails.Add(newitem);
                db.SaveChanges();

                var totalQuan = unpaidItems.Sum(r => r.Quantity) + 1;
                var totalPrice = unpaidItems.Sum(r => r.Price) + (decimal)product.PriceList[0];
                ordering.TotalQuantity = totalQuan;
                ordering.TotalPrice = totalPrice;
                db.SaveChanges();
            }
        }
    }
}
