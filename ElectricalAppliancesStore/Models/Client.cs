using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Client
    {
        public int ID { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
    }
}