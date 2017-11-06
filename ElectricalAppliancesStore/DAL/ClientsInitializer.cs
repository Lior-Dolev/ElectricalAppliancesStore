using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.DAL
{
    public class ClientsInitializer : DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext context)
        {
            List<User> users = new UserContext().Users.ToList();

            User liorUser = users.First(a=> a.Username == "Lior");
            User ravidUser = users.First(a => a.Username == "Ravid");
            User idanUser = users.First(a => a.Username == "Idan");

            Client Lior = new Client()
            {
                ID = 1,
                FullName = "Lior Dolev",
                Email = "liordolev@gmail.com",
                PhoneNumber = "0502279233",
                User = liorUser,
                UserID = liorUser.ID,
                Address = new Address()
                {
                    ID = 1,
                    Country = "Israel",
                    City = "Hod Hasharon",
                    Street = "Zakif",
                    HouseNumber = 4,
                    AppartmentNumber = 19,
                    ZipCode = "45284"
                }
            };

            IList<Client> defualtClients = new List<Client>() {
                new Client() {
                    ID = 1,
                    FullName = "Lior Dolev",
                    Email = "liordolev@gmail.com",
                    PhoneNumber = "0502279233",
                    User = liorUser,
                    UserID = ravidUser.ID,
                    Address = new Address()
                    {
                        ID = 1,
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
                    User = ravidUser,
                    UserID = ravidUser.ID,
                    Address = new Address()
                    {
                        ID = 2,
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
                    FullName = "Idan Sinibar",
                    Email = "idansinibar@gmail.com",
                    PhoneNumber = "0544933682",
                    User = idanUser,
                    Address = new Address()
                    {
                        ID = 3,
                        Country = "Israel",
                        City = "Rishon LeZion",
                        Street = "Karl Neter",
                        HouseNumber = 20,
                        AppartmentNumber = 3,
                        ZipCode = "66666"
                    }
                }
            };
            
            foreach (Client currClient in defualtClients)
            {
                context.Clients.Add(currClient);
            }

            base.Seed(context);
        }
    }
}