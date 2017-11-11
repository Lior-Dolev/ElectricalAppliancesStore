using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class OrdersContext : DbContext
    {
        public OrdersContext() : base()
        { }

        public DbSet<Order> Orders { get; set; }
    }
}