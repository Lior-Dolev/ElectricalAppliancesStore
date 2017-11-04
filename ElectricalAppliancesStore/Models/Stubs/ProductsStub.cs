using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class ProductsStub
    {
        public static List<Product> GetProducts()
        {
            List<Provider> providers = ProvidersStub.GetProviders();

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ID = 1,
                    Title = "Samsung Refrigerator H2900",
                    Category = Category.Refrigerators,
                    Brand = Brand.Samsung,
                    Quantity = 5,
                    Provider = providers.Single(provider => provider.ID == 1),
                    SoldCounter = 3,
                    BuyPrice = 10000,
                    SalePrice = 13000,
                    Description = "Realy good refrigerator",
                    PicturePath = "../Content/Media/products/fridge.jpg",
                    orderQuantity = 2
                },
                new Product()
                {
                    ID = 2,
                    Title = "LG Freezer HRF456",
                    Category = Category.Freezers,
                    Brand = Brand.LG,
                    Quantity = 10,
                    Provider = providers.Single(provider => provider.ID == 1),
                    SoldCounter = 0,
                    BuyPrice = 5000,
                    SalePrice = 7000,
                    Description = "Newest Freezer!",
                    PicturePath = "../Content/Media/products/toaster.jpg",
                    orderQuantity = 5
                },
                new Product()
                {
                    ID = 3,
                    Title = "LG Freezer HRF500",
                    Category = Category.Freezers,
                    Brand = Brand.LG,
                    Quantity = 7,
                    Provider = providers.Single(provider => provider.ID == 2),
                    SoldCounter = 10,
                    BuyPrice = 6000,
                    SalePrice = 10000,
                    Description = "The best freezer ever",
                    PicturePath = "../Content/Media/products/fan.jpg",
                    orderQuantity = 1
                },
                new Product()
                {
                    ID = 4,
                    Title = "Dishwasher RT50K",
                    Category = Category.Dishwashers,
                    Brand = Brand.Panasonic,
                    Quantity = 5,
                    Provider = providers.Single(provider => provider.ID == 5),
                    SoldCounter = 20,
                    BuyPrice = 2500,
                    SalePrice = 3000,
                    Description = "Washes your dishes like crazy",
                    PicturePath = "../Content/Media/products/oven.jpg",
                    orderQuantity = 0
        }
            };

            return products;
        }
    }
}