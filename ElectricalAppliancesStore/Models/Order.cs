using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CurrencyPurchase { get; set; }
        public List<OrderItem> Items { get; set; }
        public string creditCardNum { get; set; }
        public int cartSafeNum { get; set; }
        public double PriceSum()
        {
            return Items.Sum(item => item.Product.SalePrice* item.Quantity);
        }
        public Order()
        {
            this.Items = new List<OrderItem>();
        }
        public Order(List<OrderItem> items)
        {
            this.Items = items;
        }
    }
}