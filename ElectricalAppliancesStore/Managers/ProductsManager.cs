using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void AddProduct(EditProductView product, 
                                      ProductsContext pContext,
                                      HttpServerUtilityBase server)
        {
            string pic = System.IO.Path.GetFileName(product.UploadImages.FileName);
            string path = System.IO.Path.Combine(server.MapPath("~/Content/Media/products/"), pic);
            product.UploadImages.SaveAs(path);

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
                PicturePath = ("../Content/Media/products/" + pic)
            };

            pContext.Products.Add(newProduct);

            pContext.SaveChanges();
        }

        public static EditProductView GetProductByID(int productID,
                                                 ProductsContext pContext,
                                                 ProvidersContext providerContext)
        {
            Product fromDB = pContext.Products.Find(productID);

            EditProductView view = new EditProductView()
                        {
                            Title = fromDB.Title,
                            BuyPrice = fromDB.BuyPrice,
                            Description = fromDB.Description,
                            Quantity = fromDB.Quantity,
                            ProductID = fromDB.ID,
                            SalePrice = fromDB.SalePrice,
                            SoldCounter = fromDB.SoldCounter,
                            SelectedBrandId = (int)fromDB.Brand,
                            SelectedCategoryId = (int)fromDB.Category,
                            SelectedProviderId = fromDB.ProviderID,

                        };
           return FillSelectLists(view, providerContext);
        }

        public static void EditProduct(EditProductView product, 
                                      ProductsContext pContext,
                                      HttpServerUtilityBase server)
        {
            Product fromDB = pContext.Products.Find(product.ProductID);

            if ((product.UploadImages != null) && !string.IsNullOrEmpty(product.UploadImages.FileName))
            {
                string pic = System.IO.Path.GetFileName(product.UploadImages.FileName);
                string path = System.IO.Path.Combine(server.MapPath("~/Content/Media/products/"), pic);
                product.UploadImages.SaveAs(path);
                fromDB.PicturePath = ("../Content/Media/products/" + pic);
            }
            
            fromDB.Title = product.Title;
            fromDB.BuyPrice = product.BuyPrice;
            fromDB.SalePrice = product.SalePrice;
            fromDB.Description = product.Description;
            fromDB.Quantity = product.Quantity;
            fromDB.ProviderID = product.SelectedProviderId;
            fromDB.Brand = GetBrandById(product.SelectedBrandId);
            fromDB.Category = GetCategoryById(product.SelectedCategoryId);
            
            pContext.Entry(fromDB).State = EntityState.Modified;
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