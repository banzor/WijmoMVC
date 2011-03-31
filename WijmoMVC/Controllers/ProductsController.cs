using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Collections.Generic;

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

        public ActionResult Grid()
        {
            return View();
        }

        public JsonResult GetRows()
        {
            //paging
            string sPageSize = Request["paging[pageSize]"];
            int pageSize = -1;
            if (!string.IsNullOrEmpty(sPageSize))
            {
                pageSize = int.Parse(sPageSize);
            }
            string sPageIndex = Request["paging[pageIndex]"];
            int pageIndex = -1;
            if (!string.IsNullOrEmpty(sPageIndex))
            {
                pageIndex = int.Parse(sPageIndex);
            }

            //sorting
            var sort = "";
            var sortDir = "";
            if (Request["sorting[0][dataKey]"] != null && Request["sorting[0][dataKey]"] != "")
            {
                sort = Request["sorting[0][dataKey]"];
                if (Request["sorting[0][sortDirection]"] != null && Request["sorting[0][sortDirection]"] != "")
                {
                    sortDir = Request["sorting[0][sortDirection]"];
                    if (sortDir.ToLower() == "ascending")
                    {
                        sort = "it." + sort + " asc";
                    }
                    else if (sortDir.ToLower() == "descending")
                    {
                        sort = "it." + sort + " desc";
                    }
                }
            }
            IEnumerable<ProductModel> products;
            if (sort != "")
            {
                products = from p in northwind.Products.OrderBy(sort).Skip(pageIndex * pageSize).Take(pageSize) select new ProductModel() { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice.Value };
            }
            else
            {
                products = from p in northwind.Products.OrderBy("it.ProductID").Skip(pageIndex * pageSize).Take(pageSize) select new ProductModel() { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = p.UnitPrice.Value };
            }
            int totalCount = northwind.Products.Count();


            var result = new { TotalRowCount = totalCount, Items = products };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
