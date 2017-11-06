using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class UsersInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            IList<User> defualtUsers = new List<User>() {
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

            foreach (User currUser in defualtUsers)
            {
                context.Users.Add(currUser);
            }
            
            base.Seed(context);
        }
    }
}