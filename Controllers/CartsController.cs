using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class CartsController : Controller
    {
        DBFPTSHOPEntities db = new DBFPTSHOPEntities();
        // GET: Carts
        public ActionResult Cart(int? id)
        {
            var product=db.Products.Where(r=>r.ProID==id).FirstOrDefault();
            return View(product);
        }
    }
}