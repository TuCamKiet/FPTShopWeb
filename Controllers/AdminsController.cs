using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DO_AN_FPT_SHOP.Models;
using DO_AN_FPT_SHOP.Factories;
using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.Observers;
using DO_AN_FPT_SHOP.Builders;
using DO_AN_FPT_SHOP.Commands;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class AdminsController : Controller
    {
        private readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        private readonly ProductObserver productObserver;
        private readonly ProductManager _productManager = new ProductManager();

        public AdminsController()
        {
            productObserver = new ProductObserver();
            // Attach observers
            productObserver.Attach(new LoggerObserver(this));
        }

        // GET: Admins
        public ActionResult DanhSachDanhMuc()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult TaoDanhMuc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoDanhMuc(string NameCate)
        {
            if (db.Categories.Where(r => r.NameCate.ToLower() == NameCate.ToLower()).Count() > 0 || NameCate.Trim(' ').Length == 0)
                return View();

            // Sử dụng Factory để tạo đối tượng Category
            Category c = EntityFactory.CreateCategory(NameCate);
            db.Categories.Add(c);
            db.SaveChanges();
            productObserver.Notify("Category added: " + NameCate);
            return RedirectToAction("DanhSachDanhMuc");
        }

        public ActionResult ChinhSuaDanhMuc(int? id)
        {
            if (id == null)
                return RedirectToAction("DanhSachDanhMuc");
            return View(db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult ChinhSuaDanhMuc(int? id, string name)
        {
            if (id == null)
            {
                return RedirectToAction("DanhSachDanhMuc");
            }
            if (db.Categories.Where(r => r.NameCate.ToLower() == name.ToLower()).Count() > 0 || name.Trim(' ').Length == 0)
            {
                return RedirectToAction("ChinhSuaDanhMuc", new { id = id });
            }
            var pro = db.Categories.Where(r => r.CatID == id).FirstOrDefault();
            if (pro == null) return RedirectToAction("DanhSachDanhMuc");
            pro.NameCate = name;
            db.SaveChanges();
            productObserver.Notify("Category updated: " + name);
            return RedirectToAction("DanhSachDanhMuc");
        }

        public ActionResult XoaDanhMuc(int? id)
        {
            if (id == null) return RedirectToAction("DanhSachDanhMuc");
            var category = db.Categories.Where(r => r.CatID == id).FirstOrDefault();
            if (category != null)
            {
                foreach (var pro in category.Products)
                {
                    XoaSanPham(pro.ProID);
                }
                db.SaveChanges();

                db.Categories.Remove(category);
                db.SaveChanges();
                productObserver.Notify("Category deleted: " + category.NameCate);
            }
            return RedirectToAction("DanhSachDanhMuc");
        }

        public ActionResult DanhSachSanPham()
        {
            return View(db.Products.ToList());
        }

        public ActionResult TaoSanPham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoSanPham(int? catID, string ProName, int RemainQuantity,
                                       string Function, int? Pin, int? Monitor, string Camera, string Chip, int? Ram, int? supID,
                                       int colorID, string ProImage, int stoID, double? Price)
        {
            if (ProName == null || db.Products.Any(r => r.ProName.ToLower() == ProName.ToLower()) || ProName.Trim().Length == 0)
            {
                return RedirectToAction("TaoSanPham");
            }

            var builder = new ProductBuilder();
            var director = new ProductDirector(builder);

            var product = director.BuildProduct((int)catID, ProName, RemainQuantity, (int)supID, Function, (int)Pin, (int)Monitor, Camera, Chip, (int)Ram, colorID, ProImage, stoID, (double)Price);

            _productManager.AddCommand(new AddProductCommand(product, db));
            _productManager.ExecuteCommands();

            productObserver.Notify("Product added: " + ProName);
            return RedirectToAction("DanhSachSanPham");
        }

        public ActionResult ChinhSuaSanPham(int? id)
        {
            if (id == null)
                return RedirectToAction("DanhSachSanPham");
            return View(db.Products.Where(r => r.ProID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult ChinhSuaSanPham(int proID, int catID, string ProName, int RemainQuantity,
            string Function, int? Pin, int? Monitor, string Camera, string Chip, int? Ram, int supID,
            int colorID, string ProImage,
            int stoID, double? Price)
        {
            var pro = db.Products.Where(r => r.ProID == proID).FirstOrDefault();
            var proDe = pro.ProDetails.FirstOrDefault();

            if (ProName == null ||
                (db.Products.Where(r => r.ProName.ToLower() == ProName.ToLower()).Count() > 0) && pro.ProName != ProName //vế thứ 2 để khi tên truyền vào
                                                                                                                         //mà trùng với pro gốc thì cho phép sửa tiếp
                || ProName.Trim(' ').Length == 0)
            {
                return RedirectToAction("ChinhSuaSanPham", new { id = proID });
            }

            pro.ProName = ProName;
            pro.RemainQuantity = RemainQuantity;
            pro.CatID = catID;
            proDe.Function = Function;
            proDe.Pin = Pin;
            proDe.Monitor = Monitor;
            proDe.Camera = Camera;
            proDe.Chip = Chip;
            proDe.Ram = Ram;
            proDe.SupID = supID;
            proDe.ColorProDes.FirstOrDefault().ProImg = ProImage;
            proDe.StoProDes.FirstOrDefault().Price = (decimal?)Price;

            _productManager.AddCommand(new UpdateProductCommand(pro, db));
            _productManager.ExecuteCommands();

            productObserver.Notify("Product updated: " + ProName);
            return RedirectToAction("DanhSachSanPham");
        }

        public ActionResult ChiTietSanPham(int? id)
        {
            if (id == null)
                return RedirectToAction("DanhSachSanPham");
            Product product = db.Products.Find(id);
            if (product == null)
                return RedirectToAction("DanhSachSanPham");
            return View(product);
        }

        public ActionResult XoaSanPham(int? id)
        {
            if (id == null) return RedirectToAction("DanhSachSanPham");


            _productManager.AddCommand(new DeleteProductCommand((int)id, db));
            _productManager.ExecuteCommands();

            productObserver.Notify("Product deleted: " + id);

            return RedirectToAction("DanhSachSanPham");
        }

        public ActionResult DanhSachKhachHang()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult DanhSachDonHang(string phone)
        {
            if (phone == null || phone.Length == 0) return RedirectToAction("DanhSachKhachHang");
            return View(db.Customers.Where(r => r.Phone == phone).FirstOrDefault().Orders.ToList());
        }

        public ActionResult ChiTietDonHang(int OrderID)
        {
            var orderDeList = db.OrderDetails.Where(r => r.OrderID == OrderID).ToList();
            if (orderDeList.Count <= 0)
                return RedirectToAction("DanhSachDonHang");
            return View(orderDeList);
        }

        public ActionResult BlockCustomer(string username)
        {
            var user = db.Users.Where(r => r.UserName == username && r.Role == false).FirstOrDefault();
            if (user != null)
                user.Customers.FirstOrDefault().LoginStatus = true;
            db.SaveChanges();
            return RedirectToAction("DanhSachKhachHang");
        }

        public ActionResult UnblockCustomer(string username)
        {
            var user = db.Users.Where(r => r.UserName == username && r.Role == false).FirstOrDefault();
            if (user != null)
                user.Customers.FirstOrDefault().LoginStatus = false;
            db.SaveChanges();
            return RedirectToAction("DanhSachKhachHang");
        }

        public ActionResult DanhSachVoucher()
        {
            return View(db.Vouchers);
        }

        public ActionResult TaoVoucher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoVoucher(decimal? Discount, string Description)
        {
            if (Description == null || db.Vouchers.Where(r => r.Description.ToLower() == Description.ToLower()).Count() > 0 || Description.Trim(' ').Length == 0)
                return View();
            Voucher voucher = new Voucher();
            voucher.Description = Description;
            voucher.Discount = Discount;
            db.Vouchers.Add(voucher);
            db.SaveChanges();
            return RedirectToAction("DanhSachVoucher");
        }

        public ActionResult ChinhSuaVoucher(int? voucherID)
        {
            if (voucherID != null)
            {
                return View(db.Vouchers.Where(r => r.VoucherID == voucherID).FirstOrDefault());
            }
            return RedirectToAction("DanhSachVoucher");
        }

        [HttpPost]
        public ActionResult ChinhSuaVoucher(int voucherID, string Description, decimal Discount)
        {
            var voucher = db.Vouchers.Where(r => r.VoucherID == voucherID).FirstOrDefault();
            if (Description == null ||
                (db.Vouchers.Where(r => r.Description.ToLower() == Description.ToLower()).Count() > 0) && voucher.Description != Description //vế thứ 2 để khi tên truyền vào
                                                                                                                                             //mà trùng với pro gốc thì cho phép sửa ti[...]
                || Description.Trim(' ').Length == 0)
                return RedirectToAction("ChinhSuaVoucher", new { voucherID = voucherID });
            voucher.Description = Description;
            voucher.Discount = Discount;
            db.SaveChanges();

            return RedirectToAction("DanhSachVoucher");
        }

        public ActionResult XoaVoucher(int? voucherID)
        {
            if (voucherID != null)
            {
                var voucher = db.Vouchers.Where(r => r.VoucherID == voucherID).FirstOrDefault();

                db.OrderVouchers.RemoveRange(voucher.OrderVouchers);
                db.SaveChanges();

                db.Vouchers.Remove(voucher);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachVoucher");
        }
    }

    public class LoggerObserver : IObserver
    {
        private readonly Controller _controller;

        public LoggerObserver(Controller controller)
        {
            _controller = controller;
        }

        public void Update(string message)
        {
            // Store the message in TempData to be displayed in the view
            _controller.TempData["AlertMessage"] = message;
        }
    }
}
