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

        public bool getSupplierID(string supplier, out int id)
        {
            List<Provider> providers = ProvidersManager.GetProviders(dbProviders);
            foreach (var provider in providers)
            {
                if ( provider.CompanyName == supplier)
                {
                    id = provider.ID;
                    return true;
                }
            }

            id = 0;
            return false;
        }

        public List<Product> getSpecificProducts(string category, string supplier, int maxBuyPrice)
        {
            List<Product> products = ProductsManager.GetProducts(dbProducts);

            bool filterCategory = "All" != category;
            bool filterSupplier = "All" != supplier;
            bool filterPrice    = 0 < maxBuyPrice;

            Category ctg_id = 0;
            if (filterCategory && ! Enum.TryParse<Category>(category, out ctg_id))
            {
                products.Clear();
                return products;
            }

            int splr_id = 0;
            if (filterSupplier && ! getSupplierID(supplier, out splr_id))
            {
                products.Clear();
                return products;
            }

            if ( filterCategory )
            {
                products.RemoveAll(item => ctg_id != item.Category);
            }

            if ( filterSupplier)
            {
                products.RemoveAll(item => splr_id != item.ProviderID);
            }

            if ( filterPrice)
            {
                products.RemoveAll(item => maxBuyPrice < item.BuyPrice);
            }

            return products;
        }

        public ActionResult ProductsByCategoryBrandAndMaxPrice(string category,
                                                               string supplier,
                                                               int maxBuyPrice = -1)
        {

            List<Product> products = getSpecificProducts(category, supplier, maxBuyPrice);
            return View("Inventory", products);
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