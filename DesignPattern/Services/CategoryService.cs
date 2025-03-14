using DO_AN_FPT_SHOP.DesignPattern.RepositoryPattern;
using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.DesignPattern.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        // Inject Repository vào Service
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<ViewModelCateItem> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public IEnumerable<ViewModelCateItem> GetFilteredCategories(int? cateid, string supName, string function, double? minPrice, double? maxPrice, int? minPin, int? maxPin, int? minMonitor, int? maxMonitor, string camera)
        {
            return _categoryRepository.GetFilteredCategories(cateid, supName, function, minPrice, maxPrice, minPin, maxPin, minMonitor, maxMonitor, camera);
        }
    }
}