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

        public ActionResult UpdateOrder(ProductView view, int productID, int quantity)
        {

            // check if such item exist
            if (!view.currOrder.Items.Exists(item => item.ProductID == productID))
            {
                // If not - add it to the order with the given qty
                view.currOrder.Items.Add(new OrderItem()
                {
                    ProductID = productID,
                    Quantity = quantity
                });
            }
            else
            { // Item exist in current order
                // check if given amount is 0 - and if so - remove the item from the order
                if (quantity == 0)
                {
                    var found = view.currOrder.Items.Find(item => item.ProductID == productID);
                    if (found != null) view.currOrder.Items.Remove(found);
                }
                else
                { //Update item's qty 
                    view.currOrder.Items.Find(item => item.ProductID == productID).Quantity = quantity;
                }
            }
            return View("Products", view);
        }
    }
}