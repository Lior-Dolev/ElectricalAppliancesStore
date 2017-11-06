using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base()
        { }

        public DbSet<User> Users { get; set; }
    }
}