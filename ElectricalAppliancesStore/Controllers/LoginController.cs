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
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Models.User user)
        {
            PermissionType permission = 0;
            if (validate(user, ref permission))
            {
                if ( PermissionType.Manager == permission)
                {
                    return RedirectToAction("Index", "Manager");
                } 
                return RedirectToAction("Index", "Products");
            }
            return View("Index",user);
        }

        public bool validate(Models.User user, ref PermissionType permission)
        {
            List<User> users = UsersStub.GetUsers();
            foreach ( Models.User u in users)
            {
                if ( (u.Username == user.Username) && (u.Password == user.Password)) {
                    permission = u.PermissionType;
                    return true;
                }
            }
            return false;
        }
    }
}