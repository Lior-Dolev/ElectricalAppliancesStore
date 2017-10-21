using System;
using System.Collections.Generic;
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
        public int ID { get; set; }
        public PermissionType PermissionType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}