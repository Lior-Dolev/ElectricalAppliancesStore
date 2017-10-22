using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class ProvidersStub
    {
        public static List<Provider> GetProviders()
        {
            List<Provider> providers = new List<Provider>()
            {
                new Provider()
                {
                    ID = 1,
                    CompanyName = "Sale Electric",
                    ContactPerson = "Oren",
                    PhoneNumber = "0502233447",
                    Email = "SaleElectric@gmail.com"
                },
                new Provider()
                {
                    ID = 2,
                    CompanyName = "Last Price",
                    ContactPerson = "Lola",
                    PhoneNumber = "0547782135",
                    Email = "LastPrice@gmail.com"
                },
                new Provider()
                {
                    ID = 3,
                    CompanyName = "Time2Buy",
                    ContactPerson = "Menashe",
                    PhoneNumber = "0533332783",
                    Email = "Time2Buy@gmail.com"
                },
                new Provider()
                {
                    ID = 4,
                    CompanyName = "City Deal",
                    ContactPerson = "Nisim",
                    PhoneNumber = "0544443322",
                    Email = "CityDeal@gmail.com"
                },
                new Provider()
                {
                    ID = 5,
                    CompanyName = "Best Electric",
                    ContactPerson = "Sarit",
                    PhoneNumber = "0502932455",
                    Email = "BestElectric@gmail.com"
                }
            };

            return providers;
        }
    }
}