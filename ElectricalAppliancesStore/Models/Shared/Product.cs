using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Shared
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SupplierID { get; set; }
        public String Category { get; set; }
        public String Brand { get; set; }
        public String PNG_Path { get; set; }
        public String Description { get; set; }
        public double buyPrice { get; set; }
        public double salePrice { get; set; }
        public int quantity { get; set; }
        public int salesCounter { get; set; }
    }
}