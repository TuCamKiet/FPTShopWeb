//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Search_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Search_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
  
    ViewBag.Title = "Search";
    Layout = "~/Views/Shared/_MasterLayout.cshtml";


#line default
#line hidden

#line 3 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
            foreach (var item in Model)
            {
                

#line default
#line hidden

#line 4 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                        __o = Url.Action("ProductDetail", "Products", new { id=item.Product.ProID });


#line default
#line hidden

#line 5 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                       __o = item.ProImgList[0];


#line default
#line hidden

#line 6 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                __o = item.Product.ProName;


#line default
#line hidden

#line 7 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                       __o = item.Product.ProName;


#line default
#line hidden

#line 8 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                   var price = DO_AN_FPT_SHOP.Models.ViewModelProduct.GetPrice(item.PriceList[0]);

#line default
#line hidden

#line 9 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                               __o = price;


#line default
#line hidden

#line 10 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                              __o = item.ProDetail.Chip;


#line default
#line hidden

#line 11 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                        __o = item.ProDetail.Monitor;


#line default
#line hidden

#line 12 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                        __o = item.ProDetail.Ram;


#line default
#line hidden

#line 13 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                __o = DO_AN_FPT_SHOP.Models.ViewModelProduct.GetStoValue(item.StoValueList[0]);


#line default
#line hidden

#line 14 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\13\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                      
            }

#line default
#line hidden
}
}
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Search_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Search_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
  
    ViewBag.Title = "Search";
    Layout = "~/Views/Shared/_MasterLayout.cshtml";


#line default
#line hidden

#line 3 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
            foreach (var item in Model)
            {
                

#line default
#line hidden

#line 4 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                        __o = Url.Action("ProductDetail", "Products", new { id=item.Product.ProID });


#line default
#line hidden

#line 5 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                       __o = item.ProImgList[0];


#line default
#line hidden

#line 6 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                __o = item.Product.ProName;


#line default
#line hidden

#line 7 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                       __o = item.Product.ProName;


#line default
#line hidden

#line 8 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                   var price = DO_AN_FPT_SHOP.Models.ViewModelProduct.GetPrice(item.PriceList[0]);

#line default
#line hidden

#line 9 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                               __o = price;


#line default
#line hidden

#line 10 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                              __o = item.ProDetail.Chip;


#line default
#line hidden

#line 11 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                        __o = item.ProDetail.Monitor;


#line default
#line hidden

#line 12 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                        __o = item.ProDetail.Ram;


#line default
#line hidden

#line 13 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                                                                                __o = DO_AN_FPT_SHOP.Models.ViewModelProduct.GetStoValue(item.StoValueList[0]);


#line default
#line hidden

#line 14 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Products\Search.cshtml"
                      
            }

#line default
#line hidden
}
}
}
