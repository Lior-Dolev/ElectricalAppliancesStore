using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using ElectricalAppliancesStore.DAL;
using Newtonsoft.Json;
using ElectricalAppliancesStore.Managers;

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
        
        public ActionResult CheckOut(int clientID, string items)
        {
            Order order = new Order()
            {
                ClientID = clientID
            };

            order.Items = OrderManager.GetOrderItems(items, dbProducts);

            return View(order);
        }
    }
}