using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DO_AN_FPT_SHOP.Models
{
    public class ViewModelCateItem
    {
        public Nullable<int> CatID { get; set; }
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string ProImg { get; set; }

        public int ProDeID { get; set; }
        public string SupName { get; set; }
        public Nullable<double> Price { get; set; }
        public string Function { get; set; }
        public Nullable<int> Pin { get; set; }
        public Nullable<int> Monitor { get; set; }
        public string Camera { get; set; }
        public string Chip { get; set; }
        public Nullable<int> Ram { get; set; }
        public Nullable<double> Storage { get; set; }
    }
}