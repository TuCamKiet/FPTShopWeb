using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DO_AN_FPT_SHOP.Models;
using DO_AN_FPT_SHOP.DesignPattern.RepositoryPattern;
using DO_AN_FPT_SHOP.DesignPattern.Services;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        // 🔹 Inject Service vào Controller
        public HomeController()
        {
            this._categoryService = new CategoryService();
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetAllCategories(); //
            return View(categories);
        }

    }
}