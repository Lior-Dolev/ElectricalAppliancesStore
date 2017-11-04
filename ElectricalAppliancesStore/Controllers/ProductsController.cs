using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = ProductsStub.GetProducts();

            return View(products);
        }
        [HttpPost]
        public ActionResult Index(Product model)
        {
            return View();
        }

    }
}