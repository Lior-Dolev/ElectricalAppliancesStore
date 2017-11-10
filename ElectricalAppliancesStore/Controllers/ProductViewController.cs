﻿using System;
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

        public List<Product> getProductByCategory(int category)
        {
            List<Product> products = ProductsManager.GetProducts(dbProducts);
            products.RemoveAll(item => category != (int)item.Category);

            return products;
        }

        // Search By Category
        public ActionResult ProductsByCategory(int userID, int category)
        {
            ProductView view = new ProductView()
            {
                currOrder = new Order()
                {
                    ClientID = 2, //UserManager.GetClientIdByUserId(userID, dbClients),
                    Items = new List<OrderItem>()
                },
                products = getProductByCategory(category)
            };

            return View("Products", view);
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