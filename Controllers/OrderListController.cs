using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.Models;
using DO_AN_FPT_SHOP.Templates;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class OrderListController : Controller
    {
        private static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        private OrderTemplate _orderTemplate;

        // GET: OrderList
        public ActionResult Cart()
        {
            if (Session["Account"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = Session["Account"] as User;
            if (user == null || user.Role == true) { return RedirectToAction("Category", "Categories"); }
            var cus = db.Customers.FirstOrDefault(r => r.UserName == user.UserName);
            if (cus == null) { return RedirectToAction("Category", "Categories"); }
            var order = cus.Orders.FirstOrDefault(r => r.OrderStatus == 0);
            if (order == null) { return RedirectToAction("Category", "Categories"); }
            var orderDetails = order.OrderDetails.ToList();
            return View(orderDetails);
        }

        public ActionResult Huy(int? orDeID)
        {
            _orderTemplate = new CancelOrder();
            return _orderTemplate.ProcessOrder(orDeID);
        }

        public ActionResult Buy(int? ProID)
        {
            _orderTemplate = new BuyOrder();
            return _orderTemplate.ProcessOrder(ProID);
        }

        [HttpPost]
        public ActionResult HasOrdered(List<int> OrderID, List<int> OrderDetailID, List<int> ProDeID, List<int> Quantity, List<decimal> Price,
            List<int> VoucherID, List<decimal?> Discount)
        {
            var orderId = OrderID[0]; //Dat bien tranh loi Linq ko doc duoc get item cua List
            var order = db.Orders.Where(r => r.OrderID == orderId).FirstOrDefault();
            if (order == null) { return RedirectToAction("Cart"); }
            order.OrderStatus = 2;
            order.OrderDate = DateTime.Now;

            var orDeList = db.OrderDetails;
            for (var id = 0; id < OrderDetailID.Count; id++)
            {
                var orDeId = OrderDetailID[id];
                var orDe = orDeList.Where(r => r.OrderDetailID == orDeId).FirstOrDefault();
                orDe.Quantity = Quantity[id];
                orDe.Price = Price[id];
                orDe.ProDetail.Product.RemainQuantity = orDe.ProDetail.Product.RemainQuantity - Quantity[id];
            }
            db.SaveChanges();

            order.TotalQuantity = orDeList.Where(r => r.OrderID == order.OrderID).Sum(r => r.Quantity);
            var sum = 0.0;
            if (Discount != null) { sum = (double)Discount.Sum(); }
            order.TotalPrice = orDeList.Where(r => r.OrderID == order.OrderID).Sum(r => r.Price) - (decimal)sum;
            db.SaveChanges();

            if (VoucherID != null)
            {
                foreach (var voucherID in VoucherID)
                {
                    OrderVoucher orderVoucher = new OrderVoucher();
                    orderVoucher.OrderID = OrderID[0];
                    orderVoucher.VoucherID = voucherID;
                    db.OrderVouchers.Add(orderVoucher);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Category", "Categories");
        }

        public static int GetTotalQuan(string username)
        {
            var c = db.Customers.FirstOrDefault(r => r.UserName == username);
            if (c == null) return 0;
            var o = db.Orders.FirstOrDefault(r => r.Customers.FirstOrDefault().UserName == c.UserName && r.OrderStatus == 0);
            if (o == null || o.TotalQuantity == null) return 0;
            return (int)o.TotalQuantity;
        }

        public ActionResult LichSuMuaHang()
        {
            if (Session["Account"] == null) return RedirectToAction("Login", "Users");
            var acc = Session["Account"] as User;
            var order = db.Orders.Where(r => r.Customers.FirstOrDefault().UserName == acc.UserName && (r.OrderStatus == 0 || r.OrderStatus == 2));
            return View(order.ToList());
        }

        public ActionResult ChiTietDon(int orderID)
        {
            return View(db.OrderDetails.Where(r => r.OrderID == orderID).ToList());
        }

        public ActionResult HuyDonHang(int OrderID)
        {
            var order = db.Orders.FirstOrDefault(r => r.OrderID == OrderID);
            order.OrderStatus = 1;
            db.SaveChanges();
            return RedirectToAction("Category", "Categories");
        }
    }
}


