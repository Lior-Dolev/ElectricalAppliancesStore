using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Home
{
    public class LoginModel
    {
        string AppNeme;
        public string userName { get; set; }
        public string password { get; set; }
        public string errorMsg { get; set; }

        public LoginModel()
        {
            userName = "";
            password = "";
            errorMsg = "";
        }
    }
}