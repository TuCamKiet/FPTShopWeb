using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.DesignPattern.Facades;
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
        private static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        private readonly ShopFacade _shopFacade = new ShopFacade();

        // GET: Carts
        public ActionResult Cart(int? id)
        {
            var product = _shopFacade.GetProductById((int)id);
            return View(product);
        }
    }
}