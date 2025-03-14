using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DO_AN_FPT_SHOP.Models;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = CategoriesController.GetAll();

            return View(result.ToList());
        }
    }
}