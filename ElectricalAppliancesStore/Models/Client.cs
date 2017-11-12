using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}