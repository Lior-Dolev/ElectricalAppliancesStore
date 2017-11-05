using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductViewController : Controller
    {
        // GET: ProductView
        public ActionResult Products()
        {
            List<Product> products = ProductsStub.GetProducts();
            ProductView pv = new ProductView()
            {
                products = products,
                currOrder = OrderStub.GetOrder()
            //currOrder = new Order()
        };
            return View(pv);
        }
    }
}