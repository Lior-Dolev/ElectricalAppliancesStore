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
        private ActionResult getViewStart(){
            List<Product> products = ProductsStub.GetProducts();

            return View(products);
        }
        // GET: Products
        public ActionResult Index()
        {
            return getViewStart();
        }
        // GET: Products for inventory view
        public ActionResult Inventory()
        {
            return getViewStart();
        }

        [HttpPost]
        public ActionResult Index(Product model)
        {
            return View();
        }

    }
}