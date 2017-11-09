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
        
        public ActionResult CheckOut(ProductView order)
        {
            return RedirectToAction("CheckOut", "Order", order.currOrder);
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