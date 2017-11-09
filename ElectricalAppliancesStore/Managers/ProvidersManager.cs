using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Managers
{
    public class ProvidersManager
    {
        public static List<Provider> GetProviders(ProvidersContext pContext)
        {
            return pContext.Providers.ToList();
        }

        public static void AddProvider(Provider provider, ProvidersContext pContext)
        {
            pContext.Providers.Add(provider);
        }
    }
}