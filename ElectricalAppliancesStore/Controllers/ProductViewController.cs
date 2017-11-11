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
            //int userID = ((int)Session["UserID"]) ;
            ProductView view = new ProductView()
            {
                currOrder = new OrderView()
                {
                    ClientID = UserManager.GetClientIdByUserId(userID, dbClients),
                    Items = new List<OrderItem>()
                },
                products = ProductsManager.GetProducts(dbProducts)
            };

            return View(view);
        }
        
        public List<Product> getProductByCategory(int category)
        {
            List<Product> products = ProductsManager.GetProducts(dbProducts);
            if (-1 != category)
            {
                products.RemoveAll(item => category != (int)item.Category);
            }
            return products;
        }

        // Search By Category
        public ActionResult ProductsByCategory(int userID, int category)
        {
            ProductView view = new ProductView()
            {
                currOrder = new OrderView()
                {
                    ClientID = UserManager.GetClientIdByUserId(userID, dbClients),
                    Items = new List<OrderItem>()
                },
                products = getProductByCategory(category)
            };

            return View("Products", view);
        }

        public ActionResult CheckOut(string orderItems, int clientID)
        {
            Dictionary<int,int> quantityByProductId = JsonConvert.DeserializeObject<Dictionary<int,int>>(orderItems);
            
            OrderView order = OrderManager.CreateOrder(clientID,
                                                   quantityByProductId);
            
            string serializedItems = JsonConvert.SerializeObject(order.Items);
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
