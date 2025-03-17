using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Builders
{
    public class ProductDirector
    {
        private readonly IProductBuilder _builder;

        public ProductDirector(IProductBuilder builder)
        {
            _builder = builder;
        }

        public Product BuildProduct(int catID, string proName, int remainQuantity, int supID, string function, int pin, int monitor, string camera, string chip, int ram, int colorID, string proImage, int stoID, double price)
        {
            _builder.BuildProduct(catID, proName, remainQuantity);
            _builder.BuildProDetail(supID, function, pin, monitor, camera, chip, ram);
            _builder.BuildColorProDe(colorID, proImage);
            _builder.BuildStoProDe(stoID, price);

            return _builder.GetProduct();
        }
    }
}