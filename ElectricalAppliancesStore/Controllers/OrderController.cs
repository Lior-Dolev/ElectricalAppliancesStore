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
using System.Net;

namespace ElectricalAppliancesStore.Controllers
{
    public class OrderController : Controller
    {
        ProductsContext dbProducts = new ProductsContext();
        UsersContext dbUsers = new UsersContext();
        ProvidersContext dbProviders = new ProvidersContext();
        ClientsContext dbClients = new ClientsContext();
        OrdersContext dbOrders = new OrdersContext();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CheckOut(int clientID, string items)
        {
            OrderView order = new OrderView()
            {
                ClientID = clientID,
                client = UserManager.GetClientByClientID(clientID, dbClients),
                Items = new List<OrderItem>()
            };

            order.Items = OrderManager.GetOrderItems(items, dbProducts);
            OrderManager.AddOrder(order, dbOrders, dbProducts);

            return View(order);
        }

        public ActionResult Payment(int clientID, 
                                    decimal priceSum,
                                    string currency,
                                    string cardNum,
                                    int safeCardNum)
        {
            OrderManager.AddPaymentDetails(clientID,
                                    (int)priceSum,
                                    currency,
                                    cardNum,
                                    safeCardNum, 
                                    dbOrders);

            return new HttpStatusCodeResult(HttpStatusCode.OK); ;
        }

        //public ActionResult Pay()
        //{
        //    return View();
        //}
    }
}