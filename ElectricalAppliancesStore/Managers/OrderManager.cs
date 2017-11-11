using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Managers
{
    public static class OrderManager
    {
        public static void AddPaymentDetails(int clientID,
                                    int priceSum,
                                    string currency,
                                    string cardNum,
                                    int safeCardNum,
                                             OrdersContext oContext)
        {
            Order newOrder = new Order() {
                PurchaseDate = DateTime.Now,
                CreditCardNum = cardNum,
                ClientID = clientID,
                CurrencyPurchase = currency,
                CartSafeNum = safeCardNum,
                PriceSum = priceSum
            };

            oContext.Orders.Add(newOrder);
            oContext.SaveChanges();
        }

        public static void AddOrder(OrderView order, 
                                    OrdersContext oContext, 
                                    ProductsContext pContext)
        {
            foreach(OrderItem item in order.Items)
            {
                Product dbProduct = pContext.Products.Find(item.ProductID);
                
                dbProduct.SoldCounter += item.Quantity;

                pContext.Entry(dbProduct).State = EntityState.Modified;
            }
            
            pContext.SaveChanges();
        }

        public static OrderView CreateOrder(int clientID, 
                                        Dictionary<int, int> quantityByProductId)
        {
            OrderView order = new OrderView()
            {
                ClientID = clientID,
                Items = new List<OrderItem>()
            };

            foreach (var currRow in quantityByProductId)
            {
                order.Items.Add(new OrderItem()
                {
                    ID = currRow.Key,
                    ProductID = currRow.Key,
                    Quantity = currRow.Value
                });
            }

            return order;
        }

        public static List<OrderItem> GetOrderItems(string serializedItems,
                                                    ProductsContext pContext)
        {
            List<OrderItem> items = JsonConvert.DeserializeObject<List<OrderItem>>(serializedItems);

            IDictionary<int, Product> productsById = ProductsManager.GetProductsById(pContext);

            foreach (OrderItem currItem in items)
            {
                currItem.Product = productsById[currItem.ProductID];
            }

            return items;
        }
    }
}