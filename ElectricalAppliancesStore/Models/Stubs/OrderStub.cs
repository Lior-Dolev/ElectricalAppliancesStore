using ElectricalAppliancesStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class OrderStub
    {
        public static List<User> UsersManager { get; private set; }

        public static OrderView GetOrder(UsersContext uContext, 
                                     ProductsContext pContext,
                                     ProvidersContext providersContext)
        {
            List<Provider> providers = providersContext.Providers.ToList();
            List<User> user = uContext.Users.ToList();
            List<Product> products = pContext.Products.ToList();
            List<OrderItem> orItms = new List<OrderItem>();
            int i = 10;
            foreach (Product pr in products)
            {
                orItms.Add(new OrderItem { ID = i, Product = pr, Quantity = i % 3 });
                i++;
            }
            OrderView ord = new OrderView()
            {
                ID = 32,
                ClientID = 2,
                Items = orItms,
                PurchaseDate = DateTime.Now,
                CurrencyPurchase = "ILS"
            };

            return ord;
        }
    }
}