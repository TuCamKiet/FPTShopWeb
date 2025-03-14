using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DO_AN_FPT_SHOP.Templates
{
    public abstract class OrderTemplate : Controller
    {
        protected static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;

        public ActionResult ProcessOrder(int? id)
        {
            if (id == null) return RedirectToAction("Category", "Categories");

            var productOrOrder = GetProductOrOrder((int)id);
            if (productOrOrder == null) return RedirectToAction("Category", "Categories");

            
            var user = GetUser();
            if (user == null) return RedirectToAction("Login", "Users");

            if (!ValidateUser(user)) return RedirectToAction("Category", "Categories");

            ExecuteOrder(user, productOrOrder);
            return RedirectToAction("Cart");
        }

        protected abstract object GetProductOrOrder(int id);
        protected abstract User GetUser();
        protected abstract bool ValidateUser(User user);
        protected abstract void ExecuteOrder(User user, object productOrOrder);
    }
}

