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
                    Email = "SaleElectric@gmail.com",
                    LocationCoordinates = new double[] { 51.503454,-0.119562 },
                    LocationDescription = "London Eye, London"

                },
                new Provider()
                {
                    ID = 2,
                    CompanyName = "Last Price",
                    ContactPerson = "Lola",
                    PhoneNumber = "0547782135",
                    Email = "LastPrice@gmail.com",
                    LocationCoordinates = new double[] { 51.499633,-0.124755 },
                    LocationDescription = "Palace of Westminster, London"
                },
                new Provider()
                {
                    ID = 3,
                    CompanyName = "Time2Buy",
                    ContactPerson = "Menashe",
                    PhoneNumber = "0533332783",
                    Email = "Time2Buy@gmail.com",
                    LocationCoordinates = new double[] { 51.5008636,-0.1241971 },
                    LocationDescription = "Westminster Bridge, London"
                },
                new Provider()
                {
                    ID = 4,
                    CompanyName = "City Deal",
                    ContactPerson = "Nisim",
                    PhoneNumber = "0544443322",
                    Email = "CityDeal@gmail.com",
                    LocationCoordinates = new double[] {51.5007292,-0.1246254 },
                    LocationDescription = "Big Ben, London"
                },
   
            };

            return providers;
        }
    }
}