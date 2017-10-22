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
            if (validate(user))
            {
                return RedirectToAction("Index", "Products");
            }
            return View("Index",user);
        }

        public bool validate(Models.User user)
        {
            if(!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                return true;
            }

            return false;
        }
    }
}