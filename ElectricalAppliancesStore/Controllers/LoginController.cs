using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Controllers
{
    public class LoginController : Controller
    {
        UsersContext dbUsers = new UsersContext();
        ClientsContext dbClients = new ClientsContext();

        // GET: Login
        public ActionResult Index()
        {
            // TODO: Remove when there'll be an option to add clients
            AddMocks();

            return View();
        }
        
        public ActionResult Login(Models.User user)
        {
            if (validate(user))
            {
                User dbUser = UserManager.GetUsers(dbUsers).Find(stubUser => (stubUser.Username == user.Username) && (stubUser.Password == user.Password));

                if (dbUser.PermissionType == PermissionType.Client)
                {
                    // Client view
                    return RedirectToAction("Products", "ProductView", new { userID = dbUser.ID });
                }
                else
                {
                    // Manager view
                    return RedirectToAction("Inventory", "Products");
                }
            }

            // Error
            return View("Index",user);
        }

        public bool validate(Models.User user)
        {
            List<User> users = UserManager.GetUsers(dbUsers);

            if(users.Exists(stubUser => (stubUser.Username == user.Username) && (stubUser.Password == user.Password)))
            {
                return true;
            }

            return false;
        }

        #region Mocks
        public void AddMocks()
        {
            dbUsers.Database.Delete();
            dbClients.Database.Delete();

            List<User> usersMock = UsersStub.GetUsers();
            List<Client> clientsMock = ClientsStub.GetClients();

            foreach (User u in usersMock)
            {
                if (u.PermissionType == PermissionType.Manager)
                {
                    UserManager.AddManager(u, dbUsers);
                }
                else
                {
                    UserManager.AddClient(clientsMock.Find(a => a.UserID == u.ID),
                                            u,
                                            dbUsers,
                                            dbClients);
                }
            }
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbUsers.Dispose();
                dbClients.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

    }
}