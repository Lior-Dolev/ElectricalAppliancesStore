using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class ProductView
    {
        public Order currOrder { get; set; }
        public List<Product> products { get; set; }
    }
}