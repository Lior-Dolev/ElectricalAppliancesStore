using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Managers
{
    public static class ProductsManager
    {
        public static List<Product> GetProducts(ProductsContext pContext)
        {
            return pContext.Products.ToList();
        }

        public static void AddProduct(EditProductView product, ProductsContext pContext)
        {
            Product newProduct = new Product() {
                Title = product.Title,
                BuyPrice = product.BuyPrice,
                SalePrice = product.SalePrice,
                Description = product.Description,
                Quantity = product.Quantity,
                SoldCounter = 0,
                ProviderID = product.SelectedProviderId,
                Brand = GetBrandById(product.SelectedBrandId),
                Category = GetCategoryById(product.SelectedCategoryId),
                PicturePath = "../Content/Media/products/eggs.jpg"
            };

            pContext.Products.Add(newProduct);

            pContext.SaveChanges();
        }

        public static Brand GetBrandById(int id)
        {
            Brand brand;
            Enum.TryParse(id.ToString(), out brand);
            return brand;
        }

        public static Category GetCategoryById(int id)
        {
            Category category;
            Enum.TryParse(id.ToString(), out category);
            return category;
        }

        public static EditProductView CreateEditProductView(ProvidersContext pContext)
        {
            EditProductView view = new EditProductView();
            return FillSelectLists(view, pContext);
        }

        public static EditProductView FillSelectLists(EditProductView view, ProvidersContext pContext)
        {
            view.ProviderItems = new SelectList(pContext.Providers.ToList(), "ID", "CompanyName");
            view.BrandItems = new SelectList(GetBrands(), "Id", "Name");
            view.CategoryItems = new SelectList(GetCategories(), "Id", "Name");

            view.PicturesPaths = new List<string>() {
                "../Content/Media/products/eggs.jpg",
                "../Content/Media/products/fan.jpg",
                "../Content/Media/products/fridge.jpg",
                "../Content/Media/products/milk.jpg",
                "../Content/Media/products/oven.jpg",
                "../Content/Media/products/pumpkin.jpg",
                "../Content/Media/products/toaster.jpg"
            };

            return view;
        }

        public static List<object> GetBrands()
        {
            List<object> enums = new List<object>();
            int counter = 0;

            Array brandValues = Enum.GetValues(typeof(Brand));

            foreach(var name in brandValues)
            {
                
                enums.Add(new {
                    Name = name,
                    Id = counter
                });
                counter++;
            }

            return enums;
        }

        public static List<object> GetCategories()
        {
            List<object> enums = new List<object>();
            int counter = 0;

            Array categoryValues = Enum.GetValues(typeof(Category));

            foreach (var name in categoryValues)
            {

                enums.Add(new
                {
                    Name = name,
                    Id = counter
                });
                counter++;
            }

            return enums;
        }
    }
}