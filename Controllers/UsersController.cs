using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using DO_AN_FPT_SHOP.DesignPattern;
using DO_AN_FPT_SHOP.DesignPattern.Strategy;
using DO_AN_FPT_SHOP.Models;
using Microsoft.Ajax.Utilities;

namespace DO_AN_FPT_SHOP.Controllers
{
    public class UsersController : Controller
    {
        private readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;
        private ILoginStrategy _loginStrategy;

        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == null || password == null) { return View(); }
            if (IsAdmin(username))
            {
                _loginStrategy = new AdminLoginStrategy();
            }
            else
            {
                _loginStrategy = new CustomerLoginStrategy();
            }
            //var user = db.Users.Where(r => r.UserName == username && r.PassWord == password).FirstOrDefault();
            var user = _loginStrategy.Login(username, password, db);
            if (user != null)
            {
                Session["Account"]=user;
                if (user.Role == false) {
                    if (user.Customers.FirstOrDefault().LoginStatus == true /*bị khóa tài khoản*/)
                    {
                        ViewBag.BlockedWarn = "*Tài khoản của bạn đã bị khóa";
                        return View();
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("ProfileAdmin", "Users");
                }
            }

            ViewBag.Message = "*Tài khoản không tồn tại";

            return View();
        }

        private bool IsAdmin(string username)
        {
            // Kiểm tra xem người dùng có phải là admin hay không
            var user = db.Users.FirstOrDefault(r => r.UserName == username);
            return user != null && user.Role == true;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string phonenumber, string UserName, string password, string cpassword, string email, string name, string role)
        {
            var user = db.Users.Where(r => r.UserName == UserName).FirstOrDefault();
            if (user != null)
            {
                ViewBag.Message = "*Tên người dùng đã tồn tại";
                return View();
            }
            if (password.Length < 8 || password != cpassword)
            {
                ViewBag.Message = "*Kiểm tra lại độ dài hoặc confirm password";
                return View();
            }

            if (phonenumber.Length != 10)
            {
                ViewBag.Message = "*Số điện thoại không hợp lệ";
                return View();
            }
            var customer = db.Customers.Where(r => r.Phone == phonenumber).FirstOrDefault();
            if (customer != null)
            {
                ViewBag.Message = "*Số điện thoại đã tồn tại";
                return View();
            }

            User newUser = new User();
            newUser.UserName = UserName;
            newUser.PassWord = password;
            newUser.Role = false;

            Customer newCustomer = new Customer();
            newCustomer.UserName = UserName;
            newCustomer.Phone = phonenumber;
            if (email != null) { newCustomer.Email = email; }
            if (name != null) { newCustomer.CusName = name; }

            newUser.Role = false;

            db.Customers.Add(newCustomer);

            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        [Route("Users/ProfileCustomer")]
        [Route("Users/ProfileAdmin")]
        public ActionResult Profile() {
            if (Session["Account"] != null)
            {
                var acc = Session["Account"] as User;
                if(acc.Role == false)
                {
                    var customer=db.Customers.Where(r=>r.UserName == acc.UserName).FirstOrDefault();
                    return View("ProfileCustomer", customer);
                }
                else
                {
                    var admin = db.Admins.Where(r => r.UserName == acc.UserName).FirstOrDefault();
                    return View("ProfileAdmin", admin);
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult DeleteAccount() 
        {
            if (Session["Account"] != null)
            {
                var acc = Session["Account"] as User;
                var user = db.Users.Where(r => r.UserName == acc.UserName).FirstOrDefault();
                if (user != null)
                {
                    if (user.Role == false)
                    {
                        var customer = db.Customers.Where(r => r.UserName == user.UserName).FirstOrDefault();
                        var order = db.Orders.Where(r => r.Customers.FirstOrDefault().UserName == acc.UserName).FirstOrDefault();
                        if (order != null)
                        {
                            var orderDeList = db.OrderDetails.Where(r => r.OrderID == order.OrderID).ToList();
                            foreach (var item in orderDeList)
                            {
                                db.OrderDetails.Remove(item);
                            }

                            if (order.OrderStatus == 2) //đã thanh toán => có thể có liên hệ với voucher=> xóa
                            {
                                db.OrderVouchers.RemoveRange(order.OrderVouchers);
                            }
                            order.Customers.Remove(customer);
                            customer.Orders.Remove(order);
                            db.Orders.Remove(order);
                        }

                        user.Customers.Remove(customer);
                        db.Customers.Remove(customer);

                        db.Users.Remove(user);
                        db.SaveChanges();
                    }
                    Session["Account"] = null;
                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult EditProfile(string password,string phone, string name,string email, string address)
        {
            if (phone.Length != 10 || password.Length < 8 || phone == null || password == null)
            {
                return RedirectToAction("Profile");
            }

            if (Session["Account"] != null)
            {
                var acc = Session["Account"] as User;
                User user = db.Users.Where(r => r.UserName == acc.UserName).FirstOrDefault();
                if (user.Role == false)
                {
                    Customer customer = db.Customers.Where(r => r.UserName == user.UserName).FirstOrDefault();
                    customer.Email = email;
                    customer.Phone = phone;
                    customer.CusName = name;
                    customer.Address = address;

                }
                else
                {
                    Admin admin = db.Admins.Where(r => r.UserName == user.UserName).FirstOrDefault();
                    admin.Email = email;
                    admin.Phone = phone;
                    admin.AdName = name;
                }

                user.PassWord = password;
                db.SaveChanges();
                Session["Account"] = user;

                return RedirectToAction("Profile");
            }

            return RedirectToAction("Login");
        }
  
    }
}