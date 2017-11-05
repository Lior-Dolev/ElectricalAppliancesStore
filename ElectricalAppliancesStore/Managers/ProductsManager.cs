using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Managers
{
    public static class ProductsManager
    {
        public static List<Product> GetProducts(ProductsContext pContext)
        {
            return pContext.Products.ToList();
        }

        public static void AddProduct(Product product, ProductsContext pContext)
        {
            pContext.Products.Add(product);
        }
    }
}