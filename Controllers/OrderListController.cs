using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.Models;
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
        // GET: OrderList

        private static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        // GET: Carts
        public ActionResult Cart()
        {
            if (Session["Account"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            var user = Session["Account"] as User;
            if (user == null || user.Role == true) { { return RedirectToAction("Category", "Categories"); } }
            var cus = db.Customers.Where(r => r.UserName == user.UserName).FirstOrDefault();
            if (cus == null) { return RedirectToAction("Category", "Categories"); }
            var order = cus.Orders.Where(r => r.OrderStatus == 0).FirstOrDefault();
            if (order == null) { return RedirectToAction("Category", "Categories"); }
            var orderDetails = order.OrderDetails.ToList();
            return View(orderDetails);
        }

        public ActionResult Huy(int? orDeID)
        {
            if (orDeID == null) { return RedirectToAction("Cart"); }
            var orDe = db.OrderDetails.Where(r => r.OrderDetailID == orDeID).FirstOrDefault();
            var order = db.Orders.Where(r => r.OrderID == orDe.OrderID && r.OrderStatus == 0).FirstOrDefault();
            if (orDe != null && order != null)
            {
                order.TotalQuantity = (int)order.TotalQuantity - (int)orDe.Quantity;
                order.TotalPrice = (int)order.TotalPrice - (int)orDe.Price;
                db.OrderDetails.Remove(orDe);

                if (order.TotalQuantity == 0)
                {
                    order.Customers.Clear();
                    db.Orders.Remove(order);
                }

                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        public ActionResult Buy(int? ProID)
        {
            if (ProID == null) { return RedirectToAction("Category", "Categories"); }
            var product = ProductsController.GetDetails((int)ProID);

            if (Session["Account"] == null) return RedirectToAction("Login", "Users");
            var acc = (Session["Account"] as User);

            var cus = db.Customers.Where(r => r.UserName == acc.UserName).FirstOrDefault();
            if (cus == null) return RedirectToAction("Login", "Users");
            var CusOrders = cus.Orders.Where(r => r.OrderStatus == 0).ToList();

            if (CusOrders.Count == 0) //Customer chưa đặt hàng || không có đơn hàng đang đặt
            {
                Order order = new Order();

                OrderDetail item = new OrderDetail();
                item.OrderID = order.OrderID;
                item.ProDeID = product.ProDetail.ProDeID;
                item.Quantity = 1;
                item.Price = (decimal)product.PriceList[0];

                order.OrderDate = DateTime.Now;
                order.TotalPrice = item.Price;
                order.TotalQuantity = item.Quantity;
                order.OrderStatus = 0; //dang dat hang
                order.Customers.Add(cus);

                db.Orders.Add(order);//Add vào bảng order
                db.OrderDetails.Add(item);
                Customer c = db.Customers.Where(r => r.Phone == cus.Phone).FirstOrDefault(); //Tạo mới Order thì phải lưu Customer (n-n)
                c.Orders.Add(order);//Add vào danh sách 'khóa ngoại' của customer              //và ngược lại.
                db.SaveChanges();                                                          //Tuy nhiên, lưu mỗi OrderDetail thì không cần
                                                                                           //:)) Kính gửi Kiệt của tương lai
                return RedirectToAction("Cart");
            }
            else //Có order
            {
                //Đã có mặt sản phẩm vừa thêm

                var ordering = CusOrders.FirstOrDefault(); //FirstorDefault vì tại 1 thời điểm && ở 1 tài khoản thì chỉ có 1 đơn hàng đang đặt.

                var unpaidItems = db.OrderDetails.Where(r => r.OrderID == ordering.OrderID).ToList();
                foreach (var item in unpaidItems)
                {
                    if (item.ProDeID == product.ProDetail.ProDeID)
                    {
                        item.Quantity += 1;
                        item.Price = (decimal)(product.PriceList[0] * (int)item.Quantity); //Quantity sẽ không rỗng vì mặc định là 1 khi tạo đơn
                        var orderDe = db.OrderDetails.Where(r => r.OrderDetailID == item.OrderDetailID).FirstOrDefault();
                        orderDe.Quantity = item.Quantity;
                        orderDe.Price = item.Price;
                        db.SaveChanges();

                        //Cập nhật orderDetail ở đâu thì tính total của order tại đó

                        var tempList1 = db.OrderDetails.Where(r => r.OrderID == item.OrderID);
                        var totalQuan1 = tempList1.Sum(r => r.Quantity);
                        var totalPrice1 = tempList1.Sum(r => r.Price);
                        Order order1 = db.Orders.Where(r => r.OrderID == item.OrderID && r.OrderStatus == 0).FirstOrDefault();
                        order1.TotalQuantity = totalQuan1;
                        order1.TotalPrice = totalPrice1;
                        db.SaveChanges();

                        return RedirectToAction("Cart");
                    }
                }

                //Sản phẩm lần đầu xuất hiện trong Order
                OrderDetail newitem = new OrderDetail();
                newitem.OrderID = ordering.OrderID;
                newitem.ProDeID = product.ProDetail.ProDeID;
                newitem.Quantity = 1;
                newitem.Price = (decimal)product.PriceList[0];
                db.OrderDetails.Add(newitem);
                db.SaveChanges();

                //Cập nhật orderDetail ở đâu thì tính total của order tại đó
                var tempList = db.OrderDetails.Where(r => r.OrderID == ordering.OrderID);
                var totalQuan = tempList.Sum(r => r.Quantity);
                var totalPrice = tempList.Sum(r => r.Price);
                Order order = db.Orders.Where(r => r.OrderID == ordering.OrderID && r.OrderStatus == 0).FirstOrDefault();
                order.TotalQuantity = totalQuan;
                order.TotalPrice = totalPrice;
                db.SaveChanges();

                return RedirectToAction("Cart");
            }
        }
        [HttpPost]
        public ActionResult HasOrdered(List<int> OrderID, List<int> OrderDetailID, List<int> ProDeID, List<int> Quantity, List<decimal> Price,
            List<int> VoucherID ,List<decimal?>Discount)
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
            
            order.TotalQuantity = orDeList.Where(r=>r.OrderID==order.OrderID).Sum(r => r.Quantity);
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
            
            var c = db.Customers.Where(r => r.UserName == username).FirstOrDefault();
            if (c == null) return 0;
            var o = db.Orders.Where(r => r.Customers.FirstOrDefault().UserName == c.UserName && r.OrderStatus == 0).FirstOrDefault();
            if (o == null || o.TotalQuantity == null) return 0;
            return (int)o.TotalQuantity;
        }

        public ActionResult LichSuMuaHang()
        {
            if (Session["Account"] == null) return RedirectToAction("Login", "Users");
            var acc = Session["Account"] as User;
            var order =db.Orders.Where(r => r.Customers.FirstOrDefault().UserName == acc.UserName && (r.OrderStatus==0||r.OrderStatus==2/*Da thanh toan*/));
            return View(order.ToList());
        }

        //Customer
        public ActionResult ChiTietDon(int orderID)
        {
            return View(db.OrderDetails.Where(r => r.OrderID == orderID).ToList());
        }

        public ActionResult HuyDonHang(int OrderID)
        {
            var order = db.Orders.Where(r => r.OrderID == OrderID).FirstOrDefault();
            order.OrderStatus = 1;//huy don
            db.SaveChanges();
            return RedirectToAction("Category", "Categories");
        }
        
        //// Tìm đơn hàng đang mua
        //var ordering = db.Orders.Where(r => r.OrderStatus == 0).FirstOrDefault();

        //if (ordering == null) //Không có đơn đang mua || rỗng
        //{
        //    Order order = new Order();

        //    OrderDetail item = new OrderDetail();
        //    item.OrderID = order.OrderID;
        //    item.ProDeID = product.ProDeID;
        //    item.Quantity = 1;
        //    item.Price = (decimal)product.Price;
        //    item.OrderDetailStatus = false; //chua thanh toan

        //    order.OrderDate = DateTime.Now;
        //    order.TotalPrice = item.Price;
        //    order.TotalQuantity = item.Quantity;
        //    order.OrderStatus = 0; //dang dat hang

        //    db.Orders.Add(order);
        //    db.OrderDetails.Add(item);
        //    db.SaveChanges();

        //    return RedirectToAction("ProductDetail", "Products", new { id = product.ProID });
        //}
        //else
        //{
        //    //DA CO TRONG ORDER VÀ CHƯA THANH TOÁN
        //    var unpaidItems = db.OrderDetails.Where(r => r.OrderID == ordering.OrderID && r.OrderDetailStatus == false).ToList();
        //    foreach (var item in unpaidItems)
        //    {
        //        if (item.ProDeID == product.ProDeID)
        //        {
        //            item.Quantity += 1;
        //            item.Price = (decimal)(product.Price * (double)item.Quantity);
        //            var orderDe = db.OrderDetails.Where(r => r.OrderDetailID == item.OrderDetailID).FirstOrDefault();
        //            orderDe.Quantity = item.Quantity;
        //            orderDe.Price = item.Price;
        //            var order = db.Orders.Where(r => r.OrderID == ordering.OrderID && r.OrderStatus == 0);
        //            db.SaveChanges();
        //            return RedirectToAction("ProductDetail", "Products", new { id = product.ProID });
        //        }
        //    }

        //    //KO CO TRONG ORDER
        //    OrderDetail newitem = new OrderDetail();
        //    newitem.OrderID = ordering.OrderID;
        //    newitem.ProDeID = product.ProDeID;
        //    newitem.Quantity = 1;
        //    newitem.Price = (decimal)product.Price;
        //    newitem.OrderDetailStatus = false; //chua thanh toan
        //    db.OrderDetails.Add(newitem);
        //    db.SaveChanges();
        //    return RedirectToAction("ProductDetail", "Products", new { id = product.ProID });
        //}
    }


}

