using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Shared
{
    public class Address
    {
        public int ID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string AppartmentNumber { get; set; }

        public string ZipCode { get; set; }
    }
}