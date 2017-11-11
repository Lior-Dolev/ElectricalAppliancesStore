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

            int clientID = UserManager.GetClientIdByUserId(userID, dbClients);
            if ( -1 == clientID)
            {
                return RedirectToAction("Login", "Login");
            }

            //int userID = ((int)Session["UserID"]) ;
            ProductView view = new ProductView()
            {
                currOrder = new OrderView()
                {
                    ClientID = clientID,
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

        public List<Product> getSpecificProducts(string category, string brand, int maxPrice)
        {
            List<Product> products = ProductsManager.GetProducts(dbProducts);

            bool filterCategory = "All" != category;
            bool filterBrand    = "All" != brand;

            Category ctg_id = 0;
            if  ( filterCategory && ! Enum.TryParse<Category>(category, out ctg_id))
            {
                products.Clear();
                return products;
            }

            Brand brd_id = 0;
            if ( filterBrand && ! Enum.TryParse<Brand>(brand, out brd_id))
            {
                products.Clear();
                return products;
            }

            if (filterCategory)
            {
                products.RemoveAll(item => ctg_id != item.Category);
            }

            if (filterBrand)
            {
                products.RemoveAll(item => brd_id != item.Brand);
            }

            products.RemoveAll(item => maxPrice < item.BuyPrice);
            return products;
        }

        public ActionResult ProductsByCategoryBrandAndMaxPrice(int userID, 
                                                               string category, 
                                                               string brand, 
                                                               int maxPrice)
        {

            ProductView view = new ProductView()
            {
                currOrder = new OrderView()
                {
                    ClientID = UserManager.GetClientIdByUserId(userID, dbClients),
                    Items = new List<OrderItem>()
                },
                products = getSpecificProducts(category, brand, maxPrice)
            };

            return View("Products", view);
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
