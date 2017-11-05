using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class ClientsContext : DbContext
    {
        public ClientsContext() : base()
        { }

        public DbSet<Models.Client> Clients { get; set; }
    }
}