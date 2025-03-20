using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Data.Entity;
using DO_AN_FPT_SHOP.Models;
using Newtonsoft.Json.Linq;
using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.DesignPattern.Facades;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        private readonly ShopFacade _shopFacade = new ShopFacade();

        public ActionResult ProductDetail(int? id)
        {
            if (id == null) return RedirectToAction("Category", "Categories");
            var product = GetDetails((int)id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Search(string key)
        {
            var p =  _shopFacade.GetAllProducts().Where(r => r.ProName.Contains(key)).ToList();

            List<ViewModelProduct> searchResult = new List<ViewModelProduct>();

            foreach (var product in p)
            {
                searchResult.Add(GetDetails(product.ProID));
            }

            return View(searchResult);
        }

        public static ViewModelProduct GetDetails(int id)
        {
            var pro = db.Products.Where(r => r.ProID == id).FirstOrDefault();
            if (pro == null) return null;
            var proDe = pro.ProDetails.FirstOrDefault();
            if (proDe == null) return null;
            var color = proDe.ColorProDes.OrderBy(r => r.ColorID);
            if (color == null) return null;
            var storage = proDe.StoProDes.OrderBy(r => r.StoID);
            if (storage == null) return null;
            ViewModelProduct result = new ViewModelProduct()
            {
                Product = pro,
                ProDetail = proDe,
                Supplier = proDe.Supplier,
                Category = pro.Category,
                ColorIDList = color.Select(r => r.ColorID).ToList(),
                ColorNameList = color.Select(r => r.Color.ColorName).ToList(),
                ProImgList = color.Select(r => r.ProImg).ToList(),
                StoIDList = storage.Select(r => r.StoID).ToList(),
                StoValueList = storage.Select(r => r.Storage.StoValue).ToList(),
                PriceList = storage.Select(r => r.Price).ToList().ConvertAll(r => (double?)r),
            };

            return result;
        }


        //Admin===================================================================================
        //public ActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(int? catID, string ProName,
        //    string Function, int? Pin, int? Monitor, string Camera, string Chip, int? Ram, int? supID,
        //    int colorID, string ProImage,
        //    int stoID, double? Price)
        //{
        //    Product product = new Product();
        //    product.CatID = (int)catID;
        //    product.ProName = ProName;
        //    db.Products.Add(product);

        //    ProDetail proDe = new ProDetail();
        //    proDe.ProID = product.ProID;
        //    proDe.SupID = (int)supID;
        //    if (Function != null)
        //        proDe.Function = Function;
        //    if (Pin != null)
        //        proDe.Pin = Pin;
        //    if (Monitor != null)
        //        proDe.Monitor = Monitor;
        //    if (Camera != null)
        //        proDe.Camera = Camera;
        //    if (Chip != null)
        //        proDe.Chip = Chip;
        //    if (Ram != null)
        //        proDe.Ram = Ram;
        //    db.ProDetails.Add(proDe);

        //    ColorProDe color = new ColorProDe();
        //    color.ColorID = colorID;
        //    color.ProDeID = proDe.ProDeID;
        //    if (ProImage != null)
        //        color.ProImg = ProImage;
        //    db.ColorProDes.Add(color);

        //    StoProDe sto = new StoProDe();
        //    sto.StoID = stoID;
        //    sto.ProDeID = proDe.ProDeID;
        //    if (Price != null)
        //        sto.Price = (decimal?)Price;
        //    db.StoProDes.Add(sto);

        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product pro = db.Products.Where(r => r.ProID == id).FirstOrDefault();
        //    if (pro == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pro);
        //}

        //[HttpPost]
        //public ActionResult Edit(int proID, int catID, string ProName, int RemainQuantity,
        //    string Function, int? Pin, int? Monitor, string Camera, string Chip, int? Ram, int supID,
        //    int colorID, string ProImage,
        //    int stoID, double? Price)
        //{
        //    var pro = db.Products.Where(r => r.ProID == proID).FirstOrDefault();
        //    var proDe = pro.ProDetails.FirstOrDefault();
        //    pro.ProName = ProName;
        //    pro.RemainQuantity = RemainQuantity;
        //    pro.CatID = catID;
        //    proDe.Function= Function;
        //    proDe.Pin = Pin;
        //    proDe.Monitor = Monitor;
        //    proDe.Camera = Camera;
        //    proDe.Chip = Chip;
        //    proDe.Ram = Ram;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");   
        //}

        //public ActionResult Details(int?id )
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}


        //public ActionResult Delete(int? id)
        //{
        //    if (id == null) return RedirectToAction("Index");
        //    var product=db.Products.Where(r=>r.ProID== id).FirstOrDefault();
        //    if(product != null)
        //    {
        //        var proDe = product.ProDetails.FirstOrDefault(); //dù là list nhưng sẽ chỉ có 1 thằng
        //        proDe.ColorProDes.Clear();
        //        proDe.StoProDes.Clear();

        //        //Xóa orderDe(quan hệ giữa 2 bảng Order và ProDe)
        //        db.OrderDetails.RemoveRange(proDe.OrderDetails);
        //        proDe.OrderDetails.Clear();
        //        db.SaveChanges();

        //        //Xóa đi order nếu orDe vừa xóa là cái duy nhất trong order ấy
        //        var emptyOrders = db.Orders.Where(r => r.OrderDetails.Count == 0);
        //        if (emptyOrders.Count() > 0)
        //        {
        //            foreach (var order in emptyOrders)
        //            {
        //                order.Customers.Clear();
        //            }
        //            db.Orders.RemoveRange(emptyOrders);
        //        }

        //        product.ProDetails.Clear();
        //        db.ProDetails.Remove(proDe);
        //        db.Products.Remove(product);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}


        //public ActionResult Buy(int? proID, string username)
        //{
        //    if(username==null)
        //    {
        //        return RedirectToAction("Login", "Users");
        //    }
        //    var orderList = db.Orders.Where(r => r.Username == username).ToList();
        //    OrderDetail newOrderDe;
        //    if (orderList.Count() > 0)
        //    {
        //        newOrderDe = new OrderDetail();
        //        newOrderDe.ProID = proID;
        //        newOrderDe.Status = true;
        //        newOrderDe.OrderID = orderList[0].OrderID;
        //        db.OrderDetails.Add(newOrderDe);
        //        db.SaveChanges();
        //        return RedirectToAction("Cart", "Carts", new { orderID = orderList[0].OrderID });
        //    }

        //    Order newOrder= new Order();
        //    newOrder.Username = username;
        //    newOrder.Status = 0;
        //    db.Orders.Add(newOrder);
        //    db.SaveChanges();

        //    newOrderDe= new OrderDetail();
        //    newOrderDe.ProID = proID;
        //    newOrderDe.Status = true;
        //    newOrderDe.OrderID=newOrder.OrderID;
        //    db.OrderDetails.Add(newOrderDe);
        //    db.SaveChanges();
        //    return View("Index", "Home");
        //}
    }
}