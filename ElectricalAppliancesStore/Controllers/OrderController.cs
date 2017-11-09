using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using ElectricalAppliancesStore.DAL;

namespace ElectricalAppliancesStore.Controllers
{
    public class OrderController : Controller
    {
        ProductsContext dbProducts = new ProductsContext();
        UsersContext dbUsers = new UsersContext();
        ProvidersContext dbProviders = new ProvidersContext();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        // GET: Products for check out view
        public ActionResult CheckOut()
        {
            Order ord = OrderStub.GetOrder(dbUsers, dbProducts, dbProviders);
            return View(ord);
        }

        public ActionResult CheckOut(Order order)
        {
            return View(order);
        }
    }
}