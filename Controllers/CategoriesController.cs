using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DO_AN_FPT_SHOP.Models;
using System.Data.Entity;
using System.Net;
using PagedList;
using PagedList.Mvc;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class CategoriesController : Controller
    {
        DBFPTSHOPEntities db = new DBFPTSHOPEntities();
        // GET: Categories

        

        public ActionResult Category(int? cateid,int?page, string supName, string function, double? minPrice, double? maxPrice, int? minPin, int? maxPin, int? minMonitor, int? maxMonitor, string camera)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);

            ViewBag.CheckSupName = supName;
            ViewBag.Style = "background-color:#dc3545;";
            ViewBag.CheckMinPrice = minPrice;
            ViewBag.CheckMaxPrice = maxPrice;
            ViewBag.CheckMinPin = minPin;
            ViewBag.CheckMaxPin = maxPin;
            ViewBag.CheckMinMonitor = minMonitor;
            ViewBag.CheckMaxMonitor = maxMonitor;
            ViewBag.CheckCamera = camera;
            ViewBag.CheckFunction = function;

            var result = GetAll();

            if (cateid != null)
                result = result.Where(r => r.CatID == cateid).OrderBy(r => r.ProID);
            if (supName != null)
                result = result.Where(r => r.SupName == supName);
            if (minPrice != null && maxPrice != null)
                result = result.Where(r => r.Price < maxPrice && r.Price >= minPrice);
            if (function != null)
                result = result.Where(r => r.Function == function);
            if (minPin != null && maxPin != null)
                result = result.Where(r => r.Pin < maxPin && r.Pin >= minPin);
            if (minMonitor != null && maxMonitor != null)
                result = result.Where(r => r.Monitor < maxMonitor && r.Price >= minMonitor);
            if (camera != null)
                result = result.Where(r => r.Camera == camera);



            result = result.OrderBy(r => r.ProID);
            return View(result.ToPagedList(pageNum, pageSize));
        }

        public static IQueryable<ViewModelCateItem> GetAll()
        {
            DBFPTSHOPEntities db = new DBFPTSHOPEntities();
            var ProToProDe = from a in db.Products
                             join b in db.ProDetails on a.ProID equals b.ProID
                             where a.RemainQuantity > 0
                             select new { a.CatID, a.ProID, a.ProName, b.ProDeID, b.Pin, b.Camera, b.Ram, b.Monitor, b.Chip, b.SupID, b.Function };
            var ProToSup = from a in ProToProDe
                           join b in db.Suppliers on a.SupID equals b.SupID
                           select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, b.SupName, a.Function };
            var ProToCoDe = from a in ProToSup
                            join b in db.ColorProDes on a.ProDeID equals b.ProDeID
                            select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, b.ColorID, b.ProImg };
            var ProToStoDe = from a in ProToCoDe
                             join b in db.StoProDes on a.ProDeID equals b.ProDeID
                             select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, a.ColorID, a.ProImg, b.StoID, b.Price };
            var ProToSto = from a in ProToStoDe
                           join b in db.Storages on a.StoID equals b.StoID
                           select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, a.ColorID, a.ProImg, b.StoID, b.StoValue, a.Price };


            var result = from a in (ProToSto.GroupBy(r => r.ProDeID).Select(r => r.FirstOrDefault()))
                         select new ViewModelCateItem
                         {
                             CatID = a.CatID,
                             ProID = a.ProID,
                             ProName = a.ProName,
                             ProDeID = a.ProDeID,
                             Pin = a.Pin,
                             Camera = a.Camera,
                             Ram = a.Ram,
                             Monitor = a.Monitor,
                             Chip = a.Chip,
                             SupName = a.SupName,
                             Function = a.Function,
                             ProImg = a.ProImg,
                             Price = (double)a.Price,
                             Storage = a.StoValue
                         };
            return result;
        }
    }
}