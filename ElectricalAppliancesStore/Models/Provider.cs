using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Provider
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string TelephoneNumber { get; set; }
    }
}