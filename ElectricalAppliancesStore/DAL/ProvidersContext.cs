using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class ProvidersContext : DbContext
    {
        public ProvidersContext() : base()
        { }

        public DbSet<Provider> Providers { get; set; }
    }
}