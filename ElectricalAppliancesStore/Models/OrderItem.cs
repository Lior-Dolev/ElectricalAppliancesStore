using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}