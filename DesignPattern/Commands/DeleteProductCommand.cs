using DO_AN_FPT_SHOP.Models;
using DO_AN_FPT_SHOP.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Commands
{
    public class DeleteProductCommand : ICommand
    {
        private readonly int _productId;
        private readonly DBFPTSHOPEntities db;

        public DeleteProductCommand(int productId, DBFPTSHOPEntities dbContext)
        {
            _productId = productId;
            db = dbContext;
        }

        public void Execute()
        {

            var product = db.Products.Where(r => r.ProID == _productId).FirstOrDefault();
            if (product != null)
            {
                var proDe = product.ProDetails.FirstOrDefault(); //dù là list nhưng sẽ chỉ có 1 thằng
                db.ColorProDes.RemoveRange(proDe.ColorProDes);
                db.StoProDes.RemoveRange(proDe.StoProDes);

                //Xóa orderDe(quan hệ giữa 2 bảng Order và ProDe)
                db.OrderDetails.RemoveRange(proDe.OrderDetails);
                db.SaveChanges();

                //Xóa đi order nếu orDe vừa xóa là cái duy nhất trong order ấy
                var emptyOrders = db.Orders.Where(r => r.OrderDetails.Count == 0);

                foreach (var emptyOr in emptyOrders)
                {
                    if (emptyOr.OrderStatus == 2) //Nếu là đơn đã thanh toán thì phải kiểm tra xem có gắn voucher hay ko
                    {
                        db.OrderVouchers.RemoveRange(emptyOr.OrderVouchers);
                    }
                }
                db.SaveChanges();

                if (emptyOrders.Count() > 0)
                {
                    foreach (var order in emptyOrders)
                    {
                        order.Customers.Clear();
                    }
                    db.Orders.RemoveRange(emptyOrders);
                }

                db.ProDetails.Remove(proDe);
                db.Products.Remove(product);
                db.SaveChanges();

            }
        }
    }
}