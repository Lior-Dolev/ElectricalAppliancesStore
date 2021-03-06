﻿using System;
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
        public string CreditCardNum { get; set; }
        public int CartSafeNum { get; set; }
        public double PriceSum { get; set; }
    }
}