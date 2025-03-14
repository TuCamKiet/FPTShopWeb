using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern
{
    public class UnitOfWorK : IUnitOfWork
    {
        private readonly DBFPTSHOPEntities _db;

        public UnitOfWorK(DBFPTSHOPEntities db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}