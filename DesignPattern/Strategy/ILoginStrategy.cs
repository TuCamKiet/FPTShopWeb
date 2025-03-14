using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_FPT_SHOP.DesignPattern.Strategy
{
    public interface ILoginStrategy
    {
        User Login(string username, string password, DBFPTSHOPEntities db);
    }
}
