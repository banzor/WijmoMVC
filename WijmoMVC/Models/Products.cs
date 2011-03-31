using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WijmoMVC.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}