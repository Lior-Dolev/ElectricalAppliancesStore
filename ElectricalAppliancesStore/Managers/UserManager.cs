using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.DAL;
using System.Data.Entity;

namespace ElectricalAppliancesStore.Managers
{
    public static class UserManager
    {
        public static Client GetClientByClientID(int id, ClientsContext cContext)
        {
            return cContext.Clients.Find(id);
        }

        public static void AddManager(User user, UsersContext uContext)
        {
            user.PermissionType = PermissionType.Manager;
            
            uContext.Users.Add(user);

            uContext.SaveChanges();
        }

        public static void AddClient(EditClientView client, UsersContext uContext, ClientsContext cContext)
        {
            User user = new User() {
                Password = client.Password,
                Username = client.Username,
                PermissionType = PermissionType.Client
            };

            uContext.Users.Add(user);
            uContext.SaveChanges();

            Client newClient = new Client() {
                UserID = user.ID,
                Email = client.Email,
                Address = client.Address,
                FullName = client.FullName,
                PhoneNumber = client.PhoneNumber
            };

            cContext.Clients.Add(newClient);
            cContext.SaveChanges();
        }

        public static void DeleteClient(int clientID, 
                                        ClientsContext cContext,
                                        UsersContext uContext)
        {
            Client dbClient = cContext.Clients.Find(clientID);
            User dbUser = uContext.Users.Find(dbClient.UserID);

            cContext.Clients.Remove(dbClient);
            uContext.Users.Remove(dbUser);
            cContext.SaveChanges();
            uContext.SaveChanges();
        }

        public static int GetClientIdByUserId(int userID, ClientsContext cContext)
        {
            try
            {
                return cContext.Clients.Find(userID).ID;
            }
            catch (Exception )
            {
                return -1;
            }
        }

        public static List<User> GetUsers(UsersContext uContext)
        {
            return uContext.Users.ToList();
        }

        public static List<Client> GetClients(ClientsContext cContext)
        {
            return cContext.Clients.ToList();
        }

        public static EditClientView GetClientByID(int clientID, UsersContext uContext, ClientsContext cContext)
        {
            Client client = cContext.Clients.Find(clientID);
            User user = uContext.Users.Find(client.UserID);

            return new EditClientView() {
                ClientID = client.ID,
                FullName = client.FullName,
                Username = user.Username,
                Password = user.Password,
                Email = client.Email,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber
            };
        }

        public static void EditClient(EditClientView client, UsersContext uContext, ClientsContext cContext)
        {
            Client dbClient = cContext.Clients.Find(client.ClientID);
            
            dbClient.FullName = client.FullName;
            dbClient.Email = client.Email;
            dbClient.Address = client.Address;
            dbClient.PhoneNumber = client.PhoneNumber;

            cContext.Entry(dbClient).State = EntityState.Modified;
            cContext.SaveChanges();

            User dbUser = uContext.Users.Find(dbClient.UserID);

            dbUser.Username = client.Username;
            dbUser.Password = client.Password;

            uContext.Entry(dbUser).State = EntityState.Modified;
            uContext.SaveChanges();
        }
    }
}