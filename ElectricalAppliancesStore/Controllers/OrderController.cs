using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;

namespace ElectricalAppliancesStore.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        // GET: Products for check out view
        public ActionResult CheckOut()
        {
            Order ord = OrderStub.GetOrder();
            return View(ord);
        }
    }
}