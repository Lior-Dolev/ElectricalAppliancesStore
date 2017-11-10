using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CurrencyPurchase { get; set; }
        public List<OrderItem> Items { get; set; }
        public string CreditCardNum { get; set; }
        public int CartSafeNum { get; set; }
        [ForeignKey("ClientID")]
        public Client client { get; set; }

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