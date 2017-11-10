using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            pContext.SaveChanges();
        }

        public static Provider GetProviderByID(int providerID, ProvidersContext pContext)
        {
            return pContext.Providers.Find(providerID);
        }

        public static void Edit(Provider provider, ProvidersContext pContext)
        {
            Provider dbProvider = pContext.Providers.Find(provider.ID);

            dbProvider.CompanyName = provider.CompanyName;
            dbProvider.ContactPerson = provider.ContactPerson;
            dbProvider.Email = provider.Email;
            dbProvider.PhoneNumber = provider.PhoneNumber;
            
            pContext.Entry(dbProvider).State = EntityState.Modified;
            pContext.SaveChanges();
        }

        public static void Delete(int providerID, ProvidersContext pContext)
        {
            pContext.Providers.Remove(pContext.Providers.Find(providerID));
            pContext.SaveChanges();
        }
    }
}