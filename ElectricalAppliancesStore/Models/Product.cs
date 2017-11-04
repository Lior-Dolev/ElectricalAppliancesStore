using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public enum Brand
    {
        Electra,
        Samsung,
        LG,
        Sony,
        Toshiba,
        Panasonic
    }

    public enum Category
    {
        Refrigerators,
        Freezers,
        Dishwashers,
        BakingOvens,
        Microwaves,
        Mixers,
        Blenders,
        CoffeeMachines
    }

    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public int SoldCounter { get; set; }
        public Provider Provider { get; set; }
        public String PicturePath { get; set; }
        public String Description { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public int orderQuantity { get; set; }
    }
}