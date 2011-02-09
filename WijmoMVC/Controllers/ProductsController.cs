using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WijmoMVC.Models;
namespace WijmoMVC.Controllers
{
    public class ProductsController : Controller
    {
        NorthwindEntities northwind = new NorthwindEntities();
        //
        // GET: /Products/

        public ActionResult Index()
        {
            ViewBag.Message = "Products";
            var products = northwind.Products.ToList();
            return View(products);
        }
        public ActionResult Categories()
        {
            ViewBag.Message = "Categories";
            var categories = northwind.Categories.ToList();
            foreach (Categories c in categories)
            {
                c.Products.Load();
            }
            return View(categories);
        }
    }
}
