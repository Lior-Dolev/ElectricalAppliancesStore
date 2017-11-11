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
            List<Product> products = ProductsManager.GetProducts(dbProducts);
            return View(products);
        }

        public ActionResult AddProduct()
        {
            return View(ProductsManager.CreateEditProductView(dbProviders));
        }

        public ActionResult Delete(int productID)
        {
            ProductsManager.DeleteProduct(productID, dbProducts);

            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public ActionResult Add(EditProductView product)
        {   
            ProductsManager.AddProduct(product, dbProducts, Server);
            EditProductView fullProduct = ProductsManager.FillSelectLists(product, dbProviders);

            return RedirectToAction("Inventory");
        }

        public ActionResult EditProduct(int productID)
        {
            EditProductView view = ProductsManager.GetProductByID(productID, dbProducts, dbProviders);
            return View("EditProduct", view);
        }

        public ActionResult Edit(EditProductView product)
        {
            ProductsManager.EditProduct(product, dbProducts, Server);
            EditProductView fullProduct = ProductsManager.FillSelectLists(product, dbProviders);

            return RedirectToAction("Inventory");
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbProducts.Dispose();
                dbClients.Dispose();
                dbProviders.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}