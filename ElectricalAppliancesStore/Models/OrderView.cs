using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Models
{
    public class OrderView
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
            return Items.Sum(item => item.Product.SalePrice * item.Quantity);
        }
    }
}