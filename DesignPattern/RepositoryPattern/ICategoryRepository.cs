using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_FPT_SHOP.DesignPattern.RepositoryPattern
{
    public interface ICategoryRepository
    {
        IEnumerable<ViewModelCateItem> GetAllCategories();
        IEnumerable<ViewModelCateItem> GetFilteredCategories(int? cateid, string supName, string function, double? minPrice, double? maxPrice, int? minPin, int? maxPin, int? minMonitor, int? maxMonitor, string camera);
    }
}
