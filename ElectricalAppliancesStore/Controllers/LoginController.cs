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
            return View();
        }
        
        public ActionResult Login(Models.User user)
        {
            PermissionType permission = 0;
            if (Validate(user, ref permission))
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

        public bool Validate(Models.User user, ref PermissionType permission)
        {
            List<User> users = UserManager.GetUsers(dbUsers);

            if (users.Exists(stubUser => (stubUser.Username == user.Username) && (stubUser.Password == user.Password)))
            {
                    permission = user.PermissionType;
                    return true;
            }

            return false;
        }
        
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