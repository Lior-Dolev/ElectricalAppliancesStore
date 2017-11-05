using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base()
        {
            Database.SetInitializer<ClientContext>(new ClientsInitializer());
        }

        public Client GetClientByUserID(int userID)
        {
            return this.Clients.FirstOrDefault(client => client.UserID == userID);
        }

        public DbSet<Client> Clients { get; set; }
    }
}