using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductsController : Controller
    {
        ClientsContext dbClients = new ClientsContext();
        ProductsContext dbProducts = new ProductsContext();
        

        // GET: Products for inventory view
        public ActionResult Inventory()
        {
            // TODO: Remove when there'll be an option to add products
            AddMocks();
            
            return View(ProductsManager.GetProducts(dbProducts));
        }
        
        #region Mocks
        public void AddMocks()
        {
            dbProducts.Database.Delete();

            List<Product> products = ProductsStub.GetProducts();

            foreach(Product p in products)
            {
                dbProducts.Products.Add(p);
            }

            dbProducts.SaveChanges();
        }
        #endregion
    }
}