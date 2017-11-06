using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {
            Database.SetInitializer<UserContext>(new UsersInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}