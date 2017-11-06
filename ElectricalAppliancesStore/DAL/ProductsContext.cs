using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base()
        { }

        public DbSet<Product> Products { get; set; }
    }
}