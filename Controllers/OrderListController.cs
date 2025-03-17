using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.DesignPattern.States;
using DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern;
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
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork();
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
            var cus = _unitOfWork.Customers.GetAll().FirstOrDefault(r => r.UserName == user.UserName);
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
            var orderId = OrderID[0];
            var order = _unitOfWork.Orders.GetAll().FirstOrDefault(r => r.OrderID == orderId);
            if (order == null) { return RedirectToAction("Cart"); }
            var orderManager = new OrderManager(order);
            orderManager.SetState(new ConfirmedState());
            order.OrderDate = DateTime.Now;

            var orDeList = _unitOfWork.OrderDetails.GetAll();
            for (var id = 0; id < OrderDetailID.Count; id++)
            {
                var orDeId = OrderDetailID[id];
                var orDe = orDeList.FirstOrDefault(r => r.OrderDetailID == orDeId);
                orDe.Quantity = Quantity[id];
                orDe.Price = Price[id];
                orDe.ProDetail.Product.RemainQuantity = orDe.ProDetail.Product.RemainQuantity - Quantity[id];
            }
            _unitOfWork.Commit();

            order.TotalQuantity = orDeList.Where(r => r.OrderID == order.OrderID).Sum(r => r.Quantity);
            var sum = 0.0;
            if (Discount != null) { sum = (double)Discount.Sum(); }
            order.TotalPrice = orDeList.Where(r => r.OrderID == order.OrderID).Sum(r => r.Price) - (decimal)sum;
            _unitOfWork.Commit();

            if (VoucherID != null)
            {
                foreach (var voucherID in VoucherID)
                {
                    OrderVoucher orderVoucher = new OrderVoucher();
                    orderVoucher.OrderID = OrderID[0];
                    orderVoucher.VoucherID = voucherID;
                    _unitOfWork.OrderVouchers.Add(orderVoucher);
                    _unitOfWork.Commit();
                }
            }

            return RedirectToAction("Category", "Categories");
        }

        public static int GetTotalQuan(string username)
        {
            var c = _unitOfWork.Customers.GetAll().FirstOrDefault(r => r.UserName == username);
            if (c == null) return 0;
            var o = DBContextSingleton.Instance.Orders.FirstOrDefault(r => r.Customers.FirstOrDefault().UserName == c.UserName && r.OrderStatus == 0);
            if (o == null || o.TotalQuantity == null) return 0;
            return (int)o.TotalQuantity;
        }

        public ActionResult LichSuMuaHang()
        {
            if (Session["Account"] == null) return RedirectToAction("Login", "Users");
            var acc = Session["Account"] as User;
            var order = _unitOfWork.Orders.GetAll().Where(r => r.Customers.FirstOrDefault().UserName == acc.UserName && (r.OrderStatus == 0 || r.OrderStatus == 2));
            return View(order.ToList());
        }

        public ActionResult ChiTietDon(int orderID)
        {
            return View(_unitOfWork.OrderDetails.GetAll().Where(r => r.OrderID == orderID).ToList());
        }

        public ActionResult HuyDonHang(int OrderID)
        {
            var order = _unitOfWork.Orders.GetAll().FirstOrDefault(r => r.OrderID == OrderID);
            var orderManager = new OrderManager(order);
            orderManager.SetState(new CanceledState());
            _unitOfWork.Commit();
            return RedirectToAction("Category", "Categories");
        }
    }
}


