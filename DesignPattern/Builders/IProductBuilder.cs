using DO_AN_FPT_SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_FPT_SHOP.Builders
{
    public interface IProductBuilder
    {
        void BuildProduct(int catID, string proName, int remainQuantity);
        void BuildProDetail(int supID, string function, int pin, int monitor, string camera, string chip, int ram);
        void BuildColorProDe(int colorID, string proImage);
        void BuildStoProDe(int stoID, double price);
        Product GetProduct();
    }
}
