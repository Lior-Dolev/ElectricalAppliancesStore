using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public enum Brand
    {

    }

    public enum Category
    {

    }

    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public int SoldCounter { get; set; }
        public Provider Provider { get; set; }
    }
}