using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.Strategy
{
    public class CustomerLoginStrategy : ILoginStrategy
    {
        public User Login(string username, string password, DBFPTSHOPEntities db)
        {
            return db.Users.FirstOrDefault(r => r.UserName == username && r.PassWord == password && r.Role == false);
        }
    }
}