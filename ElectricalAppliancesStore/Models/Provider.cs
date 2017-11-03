using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Provider
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double[] LocationCoordinates { get; set; }
        public string   LocationDescription { get; set; }
    }
}