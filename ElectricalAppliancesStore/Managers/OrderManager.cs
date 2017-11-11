using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Managers
{
    public static class OrderManager
    {
        public static Order CreateOrder(int clientID, 
                                        Dictionary<int, int> quantityByProductId)
        {
            Order order = new Order()
            {
                ClientID = clientID,
                Items = new List<OrderItem>()
            };

            foreach (var currRow in quantityByProductId)
            {
                order.Items.Add(new OrderItem()
                {
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