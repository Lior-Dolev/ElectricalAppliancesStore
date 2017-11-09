using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public int AppartmentNumber { get; set; }

        public string ZipCode { get; set; }

        public override string ToString() {

            return (this.Street + " "+
                    this.HouseNumber + ", "+
                    ((this.AppartmentNumber!= 0) ?", Apt:" + this.AppartmentNumber +", ": "" )+ 
                    this.City + ", " + 
                    this.Country + 
                    ((this.ZipCode != null)?", " + this.ZipCode: ""));
        }
    }
}