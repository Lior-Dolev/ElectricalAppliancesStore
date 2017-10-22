using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Shared
{
    public class Orrder
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public DateTime Date_Time { get; set; }
        public double TotalCost { get; set; }
        public string Currency { get; set; }
        public List<Product> Products { get; set; }
    }
}