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

#line 1 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
using DO_AN_FPT_SHOP.Models;

#line default
#line hidden

public class _Page_TaoSanPham_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_TaoSanPham_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 2 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
  
    ViewBag.Title = "Create";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";


#line default
#line hidden

#line 3 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                          DBFPTSHOPEntities db = DO_AN_FPT_SHOP.DesignPattern.DBContextSingleton.Instance;

#line default
#line hidden

#line 4 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Categories.ToList())
                        {
                            

#line default
#line hidden

#line 5 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.CatID;


#line default
#line hidden

#line 6 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.CatID;


#line default
#line hidden

#line 7 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.NameCate;


#line default
#line hidden

#line 8 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                
                        }

#line default
#line hidden

#line 9 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Suppliers.ToList())
                        {
                            

#line default
#line hidden

#line 10 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.SupID;


#line default
#line hidden

#line 11 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.SupID;


#line default
#line hidden

#line 12 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.SupName;


#line default
#line hidden

#line 13 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                               
                        }

#line default
#line hidden

#line 14 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Colors.ToList())
                        {
                            

#line default
#line hidden

#line 15 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.ColorID;


#line default
#line hidden

#line 16 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                         __o = item.ColorID;


#line default
#line hidden

#line 17 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                        __o = item.ColorName;


#line default
#line hidden

#line 18 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                     
                        }

#line default
#line hidden

#line 19 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Storages.ToList())
                        {
                            

#line default
#line hidden

#line 20 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.StoID;


#line default
#line hidden

#line 21 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.StoID;


#line default
#line hidden

#line 22 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.StoValue;


#line default
#line hidden

#line 23 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                
                        }

#line default
#line hidden

#line 24 "C:\Users\truon\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\15\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
               __o = Html.ActionLink("Danh s�ch", "DanhSachSanPham", null, new { @class = "btn btn-info" });


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

#line 1 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
using DO_AN_FPT_SHOP.Models;

#line default
#line hidden

public class _Page_Views_Admins_TaoSanPham_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Views_Admins_TaoSanPham_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 2 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
  
    ViewBag.Title = "Create";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";


#line default
#line hidden

#line 3 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                           private readonly DBFPTSHOPEntities db = DBContextSingleton.Instance;

#line default
#line hidden

#line 4 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Categories.ToList())
                        {
                            

#line default
#line hidden

#line 5 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.CatID;


#line default
#line hidden

#line 6 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.CatID;


#line default
#line hidden

#line 7 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.NameCate;


#line default
#line hidden

#line 8 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                
                        }

#line default
#line hidden

#line 9 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Suppliers.ToList())
                        {
                            

#line default
#line hidden

#line 10 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.SupID;


#line default
#line hidden

#line 11 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.SupID;


#line default
#line hidden

#line 12 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.SupName;


#line default
#line hidden

#line 13 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                               
                        }

#line default
#line hidden

#line 14 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Colors.ToList())
                        {
                            

#line default
#line hidden

#line 15 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.ColorID;


#line default
#line hidden

#line 16 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                         __o = item.ColorID;


#line default
#line hidden

#line 17 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                        __o = item.ColorName;


#line default
#line hidden

#line 18 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                     
                        }

#line default
#line hidden

#line 19 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                        foreach (var item in db.Storages.ToList())
                        {
                            

#line default
#line hidden

#line 20 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                   __o = item.StoID;


#line default
#line hidden

#line 21 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                       __o = item.StoID;


#line default
#line hidden

#line 22 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                    __o = item.StoValue;


#line default
#line hidden

#line 23 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
                                                                                                
                        }

#line default
#line hidden

#line 24 "C:\Users\ACER\AppData\Local\Temp\2C19C00D6AB0E4F1093734CCC32412FA95B3\14\DO_AN_FPT_SHOP\Views\Admins\TaoSanPham.cshtml"
               __o = Html.ActionLink("Danh s�ch", "DanhSachSanPham", null, new { @class = "btn btn-info" });


#line default
#line hidden
}
}
}
