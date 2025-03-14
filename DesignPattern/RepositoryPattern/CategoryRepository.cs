using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DO_AN_FPT_SHOP.DesignPattern.RepositoryPattern
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;

        public CategoryRepository()
        {
        }

        public IEnumerable<ViewModelCateItem> GetAllCategories()
        {
            return GetAll().ToList();
        }

        public IEnumerable<ViewModelCateItem> GetFilteredCategories(int? cateid, string supName, string function, double? minPrice, double? maxPrice, int? minPin, int? maxPin, int? minMonitor, int? maxMonitor, string camera)
        {
            var result = GetAll();

            if (cateid != null)
                result = result.Where(r => r.CatID == cateid);
            if (supName != null)
                result = result.Where(r => r.SupName == supName);
            if (minPrice != null && maxPrice != null)
                result = result.Where(r => r.Price < maxPrice && r.Price >= minPrice);
            if (function != null)
                result = result.Where(r => r.Function == function);
            if (minPin != null && maxPin != null)
                result = result.Where(r => r.Pin < maxPin && r.Pin >= minPin);
            if (minMonitor != null && maxMonitor != null)
                result = result.Where(r => r.Monitor < maxMonitor && r.Monitor >= minMonitor);
            if (camera != null)
                result = result.Where(r => r.Camera == camera);

            return result.OrderBy(r => r.ProID).ToList();
        }

        private static IQueryable<ViewModelCateItem> GetAll()
        {
            var ProToProDe = from a in db.Products
                             join b in db.ProDetails on a.ProID equals b.ProID
                             where a.RemainQuantity > 0
                             select new { a.CatID, a.ProID, a.ProName, b.ProDeID, b.Pin, b.Camera, b.Ram, b.Monitor, b.Chip, b.SupID, b.Function };

            var ProToSup = from a in ProToProDe
                           join b in db.Suppliers on a.SupID equals b.SupID
                           select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, b.SupName, a.Function };

            var ProToCoDe = from a in ProToSup
                            join b in db.ColorProDes on a.ProDeID equals b.ProDeID
                            select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, b.ColorID, b.ProImg };

            var ProToStoDe = from a in ProToCoDe
                             join b in db.StoProDes on a.ProDeID equals b.ProDeID
                             select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, a.ColorID, a.ProImg, b.StoID, b.Price };

            var ProToSto = from a in ProToStoDe
                           join b in db.Storages on a.StoID equals b.StoID
                           select new { a.CatID, a.ProID, a.ProName, a.ProDeID, a.Pin, a.Camera, a.Ram, a.Monitor, a.Chip, a.SupName, a.Function, a.ColorID, a.ProImg, b.StoID, b.StoValue, a.Price };

            var result = from a in (ProToSto.GroupBy(r => r.ProDeID).Select(r => r.FirstOrDefault()))
                         select new ViewModelCateItem
                         {
                             CatID = a.CatID,
                             ProID = a.ProID,
                             ProName = a.ProName,
                             ProDeID = a.ProDeID,
                             Pin = a.Pin,
                             Camera = a.Camera,
                             Ram = a.Ram,
                             Monitor = a.Monitor,
                             Chip = a.Chip,
                             SupName = a.SupName,
                             Function = a.Function,
                             ProImg = a.ProImg,
                             Price = (double)a.Price,
                             Storage = a.StoValue
                         };

            return result;
        }
    }
}