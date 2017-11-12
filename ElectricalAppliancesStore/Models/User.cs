using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models
{
    public enum PermissionType
    {
        Client,
        Manager
    }

    public class User
    {
        [Key]
        public int ID { get; set; }
        public PermissionType PermissionType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}