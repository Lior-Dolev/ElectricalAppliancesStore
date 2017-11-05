using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class OrderStub
    {
        public static Order GetOrder()
        {
            List<Provider> providers = ProvidersStub.GetProviders();
            List<User> user = UsersStub.GetUsers();
            List<Product> products = ProductsStub.GetProducts();
            List<OrderItem> orItms = new List<OrderItem>();
            int i = 10;
            foreach (Product pr in products)
            {
                orItms.Add(new OrderItem { ID = i, Product = pr, Quantity = i % 3 });
                i++;
            }
            Order ord = new Order()
            {
                ID = 32,
                Client = new Client()
                {
                    ID = 12,
                    User = user.Last(),
                    Address = new Address()
                    {
                        Street = "HaTamar",
                        HouseNumber = 6,
                        City = "Ramat Gan",
                        Country = "Israel"
                    },
                    Email = "junkMail132@walla.co.il",
                    FullName = "Mr. Spider Pig",
                    PhoneNumber = "0987655333"
                },
                Items = orItms,
                PurchaseDate = DateTime.Now,
                CurrencyPurchase = "ILS"
            };

            return ord;
        }
    }
}