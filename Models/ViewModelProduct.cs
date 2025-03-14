using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Models
{
    public class ViewModelProduct
    {
        //public int CatID { get; set; }
        //public int ProID { get; set; }
        //public int StoID { get; set; }
        //public int ColorID { get; set; }
        //public string ProName { get; set; }
        //public string ProImg { get; set; }

        //public int ProDeID { get; set; }
        //public string SupName { get; set; }
        //public double Price { get; set; }
        //public static string GetPrice(double price)
        //{
        //    var value = price;
        //    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        //    string a = "";
        //    if (price % 1 == 0)
        //        a = String.Format(info, "{0:c0}", value);
        //    else
        //        a = String.Format(info, "{0:c}", value);
        //    return a;
        //}
        //public string Function { get; set; }
        public Nullable<int> Pin { get; set; }
        public Nullable<int> Monitor { get; set; }
        public string Camera { get; set; }
        public string Chip { get; set; }
        public Nullable<int> Ram { get; set; }
        public Nullable<double> Storage { get; set; }
        public string ColorName { get; set; }
        public Product Product { get; set; }
        public ProDetail ProDetail { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public List<int> StoIDList { get; set; }
        public List<int> ColorIDList { get; set; }
        public List<double?> StoValueList { get; set; }
        public List<string> ColorNameList { get; set; }
        public List<string> ProImgList { get; set; }
        public List<double?> PriceList { get; set; }
        public static string GetPrice(double? price)
        {
            string a = "";
            if (price != null)
            {
                var value = price;
                var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

                if (price % 1 == 0)
                    a = String.Format(info, "{0:c0}", value);
                else
                    a = String.Format(info, "{0:c}", value);
            }
            return a;
        }

        public static string GetStoValue(double? stoValue)
        {
            string a = "" + stoValue;
            if (stoValue != null)
            {
                if (stoValue / 100 == 0)
                    a += " TB";
                else
                    a += " GB";
            }
            return a;
        }
    }
}