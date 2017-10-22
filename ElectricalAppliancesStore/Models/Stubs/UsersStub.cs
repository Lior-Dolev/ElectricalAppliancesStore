using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class UsersStub
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>() {
                new User()
                {
                    ID = 1,
                    PermissionType = PermissionType.Manager,
                    Username = "Super",
                    Password = "Man"
                },
                new User()
                {
                    ID = 2,
                    PermissionType = PermissionType.Client,
                    Username = "Lior",
                    Password = "Dolev"
                },
                new User()
                {
                    ID = 3,
                    PermissionType = PermissionType.Client,
                    Username = "Ravid",
                    Password = "Batat"
                },
                new User()
                {
                    ID = 4,
                    PermissionType = PermissionType.Client,
                    Username = "Idan",
                    Password = "Sinibar"
                }
            };

            return users;
        }
    }
}