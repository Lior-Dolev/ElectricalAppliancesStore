using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public Address Address { get; set; }
        public string PicturePath { get; set; }
        public double[] LocationCoordinates { get; set; }
        public string LocationDescription { get; set; }
    }
}