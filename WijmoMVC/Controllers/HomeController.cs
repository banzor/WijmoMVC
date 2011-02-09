using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijmoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Wijmo & ASP.NET MVC!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
