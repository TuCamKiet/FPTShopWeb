using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern
{
    public class DBContextSingleton
    {
        private static DBFPTSHOPEntities _instance;
        private static readonly object _lock = new object();

        private DBContextSingleton() { }

        public static DBFPTSHOPEntities Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBFPTSHOPEntities();
                    }
                    return _instance;
                }
            }
        }
    }
}