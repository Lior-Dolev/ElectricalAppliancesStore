using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;
using Newtonsoft.Json;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductViewController : Controller
    {
        ClientsContext dbClients = new ClientsContext();
        ProductsContext dbProducts = new ProductsContext();

        // GET: ProductView
        public ActionResult Products(int userID)
        {
            ProductView view = new ProductView()
            {
                currOrder = new Order()
                {
                    ClientID = UserManager.GetClientIdByUserId(userID, dbClients),
                    Items = new List<OrderItem>()
                },
                products = ProductsManager.GetProducts(dbProducts)
            };

            return View(view);
        }
        
        [HttpPost]
        public ActionResult CheckOut(string orderItems, int clientID)
        {
            Dictionary<int,int> quantityByProductId = JsonConvert.DeserializeObject<Dictionary<int,int>>(orderItems);
            
            Order order = OrderManager.CreateOrder(clientID,
                                                   quantityByProductId);

            string serializedOrder = JsonConvert.SerializeObject(order);
            string serializedItems = JsonConvert.SerializeObject(order.Items);
            //return RedirectToAction("CheckOut", "Order", new { clientID = clientID,
            //                                                    items = serializedItems });
            return Json(Url.Action("CheckOut", "Order", new
            {
                clientID = clientID,
                items = serializedItems
            }));
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbProducts.Dispose();
                dbClients.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}