using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductViewController : Controller
    {
        ClientsContext dbClients = new ClientsContext();
        ProductsContext dbProducts = new ProductsContext();

        public ActionResult Products(int userID)
        {
            // TODO: Remove when there'll be an option to add products
            AddMocks();

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

        // TODO: Connect the '+' button to this function
        public ActionResult AddOrderItem(ProductView view, int productID)
        {
            if (!view.currOrder.Items.Exists(item => item.ProductID == productID))
            {
                view.currOrder.Items.Add(new OrderItem()
                {
                    ProductID = productID,
                    Quantity = 1
                });
            }

            view.currOrder.Items.Find(item => item.ProductID == productID).Quantity++;

            return View("Products", view);
        }

        // TODO: Connect the '-' button to this function
        public ActionResult RemoveOrderItem(ProductView view, int productID)
        {
            if (view.currOrder.Items.Exists(item => item.ProductID == productID))
            {
                OrderItem oItem = view.currOrder.Items.Find(item => item.ProductID == productID);

                if (oItem.Quantity > 0)
                {
                    view.currOrder.Items.Find(item => item.ProductID == productID).Quantity--;
                }
            }

            return View("Products", view);
        }
        #region Mocks
        public void AddMocks()
        {
            dbProducts.Database.Delete();

            List<Product> products = ProductsStub.GetProducts();

            foreach (Product p in products)
            {
                dbProducts.Products.Add(p);
            }

            dbProducts.SaveChanges();
        }
        #endregion
    }
}