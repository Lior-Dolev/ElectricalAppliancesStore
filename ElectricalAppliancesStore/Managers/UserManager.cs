using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.DAL;

namespace ElectricalAppliancesStore.Managers
{
    public static class UserManager
    {
        public static void AddManager(User user, UsersContext uContext)
        {
            user.PermissionType = PermissionType.Manager;
            
            uContext.Users.Add(user);

            uContext.SaveChanges();
        }

        public static void AddClient(Client client, User user, UsersContext uContext, ClientsContext cContext)
        {
            user.PermissionType = PermissionType.Client;

            uContext.Users.Add(user);
            cContext.Clients.Add(client);

            uContext.SaveChanges();
            cContext.SaveChanges();
        }

        public static int GetClientIdByUserId(int userID, ClientsContext cContext)
        {
            return cContext.Clients.Find(userID).ID;
        }

        public static List<User> GetUsers(UsersContext uContext)
        {
            return uContext.Users.ToList();
        }

        public static List<Client> GetClients(ClientsContext cContext)
        {
            return cContext.Clients.ToList();
        }
    }
}