using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class ClientsStub
    {
        public static List<Client> GetClients()
        {
            List<User> users = UsersStub.GetUsers();
            List<Client> clients = new List<Client>() {
                new Client() {
                    ID = 1,
                    FullName = "Lior Dolev",
                    Email = "liordolev@gmail.com",
                    PhoneNumber = "0502279233",
                    UserID = users.Single(user => user.Username == "Lior").ID,
                    Address = new Address()
                    {
                        Country = "Israel",
                        City = "Hod Hasharon",
                        Street = "Zakif",
                        HouseNumber = 4,
                        AppartmentNumber = 19,
                        ZipCode = "45284"
                    }
                },
                new Client() {
                    ID = 2,
                    FullName = "Ravid Batat",
                    Email = "ravidbatat@gmail.com",
                    PhoneNumber = "0545949311",
                    UserID = users.Single(user => user.Username == "Ravid").ID,
                    Address = new Address()
                    {
                        Country = "Israel",
                        City = "Holon",
                        Street = "Herzel",
                        HouseNumber = 9,
                        AppartmentNumber = 1,
                        ZipCode = "55555"
                    }
                },
                new Client() {
                    ID = 3,
                    FullName = "Eidan Siniver",
                    Email = "eidans@gmail.com",
                    PhoneNumber = "0544933682",
                    UserID = users.Single(user => user.Username == "Eidan").ID,
                    Address = new Address()
                    {
                        Country = "Israel",
                        City = "Rishon LeZion",
                        Street = "Karl Neter",
                        HouseNumber = 20,
                        AppartmentNumber = 3,
                        ZipCode = "66666"
                    }
                }
            };

            return clients;
        }
    }
}