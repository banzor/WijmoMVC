using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WijmoMVC.Models;
namespace WijmoMVC.Controllers
{
    public class SalesController : Controller
    {
        NorthwindEntities northwind = new NorthwindEntities();
        //
        // GET: /Products/

        public ActionResult Index()
        {
            ViewBag.Message = "Sales";
            var orders = northwind.Category_Sales_for_1997.ToList();
            return View(orders);
        }
        public ActionResult ProductSales()
        {
            ViewBag.Message = "Product Sales";
            var products = northwind.Product_Sales_for_1997.ToList();
            return View(products);
        }
        [HttpGet]
        public JsonResult ProductSalesData()
        {
            var products = northwind.Product_Sales_for_1997.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SalesByCategory()
        {
            ViewBag.Message = "Sales By Category";
            var orders = northwind.Category_Sales_for_1997.ToList();
            return View(orders);
        }
        [HttpGet]
        public JsonResult SalesByCategoryData()
        {
            var orders = northwind.Category_Sales_for_1997.ToList();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TopProductSales()
        {
            ViewBag.Message = "Top Selling Products";
            var orders = northwind.Product_Sales_for_1997.OrderByDescending(o => o.ProductSales).Take(10).ToList();
            return View(orders);
        }
        [HttpGet]
        public JsonResult TopProductSalesData()
        {
            var orders = northwind.Product_Sales_for_1997.OrderByDescending(o => o.ProductSales).Take(10).ToList();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

    }
}
