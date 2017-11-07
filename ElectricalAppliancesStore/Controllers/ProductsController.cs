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
        ProvidersContext dbProviders = new ProvidersContext();

        // GET: Products for inventory view
        public ActionResult Inventory()
        {
            // TODO: Remove when there'll be an option to add products
            AddMocks();
            
            return View(ProductsManager.GetProducts(dbProducts));
        }

        public ActionResult AddProduct()
        {
            return View(ProductsManager.CreateEditProductView(dbProviders));
        }

        [HttpPost]
        public ActionResult Add(EditProductView product)
        {
            ProductsManager.AddProduct(product, dbProducts);
            return View("AddProduct", product);
        }
        
        #region Mocks
        public void AddMocks()
        {
            dbProducts.Database.Delete();
            dbProviders.Database.Delete();

            List<Product> products = ProductsStub.GetProducts();
           
            foreach(Product p in products)
            {
                dbProducts.Products.Add(p);
            }

            dbProducts.SaveChanges();

            List<Provider> providers = ProvidersStub.GetProviders();

            foreach(Provider p in providers)
            {
                dbProviders.Providers.Add(p);
            }

            dbProviders.SaveChanges();  
        }
        #endregion
    }
}