using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class UsersInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            User manager = new User()
            {
                ID = 1,
                PermissionType = PermissionType.Manager,
                Username = "Super",
                Password = "Man"
            };

            context.Users.Add(manager);
            
            base.Seed(context);
        }
    }
}