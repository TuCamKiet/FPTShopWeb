using DO_AN_FPT_SHOP.Factories;
using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Builders
{
    public class ProductBuilder : IProductBuilder
    {
        private Product _product;
        private ProDetail _proDetail;

        public void BuildProduct(int catID, string proName, int remainQuantity)
        {
            _product = EntityFactory.CreateProduct(catID, proName, remainQuantity);
        }

        public void BuildProDetail(int supID, string function, int pin, int monitor, string camera, string chip, int ram)
        {
            _proDetail = EntityFactory.CreateProDetail(_product.ProID, supID, function, pin, monitor, camera, chip, ram);
            _product.ProDetails.Add(_proDetail);
        }

        public void BuildColorProDe(int colorID, string proImage)
        {
            var colorProDe = EntityFactory.CreateColorProDe(colorID, _proDetail.ProDeID, proImage);
            _proDetail.ColorProDes.Add(colorProDe);
        }

        public void BuildStoProDe(int stoID, double price)
        {
            var stoProDe = EntityFactory.CreateStoProDe(stoID, _proDetail.ProDeID, (decimal?)price);
            _proDetail.StoProDes.Add(stoProDe);
        }

        public Product GetProduct()
        {
            return _product;
        }
    }
}