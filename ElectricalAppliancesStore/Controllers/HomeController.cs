using ElectricalAppliancesStore.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            string userName = model.userName;
            string pwd = model.password;

            // TODO: Redirect to credentials validation

            // If credentials are valid , and of store manager:
            if (true)
            {
                return View(model);
            }
            else if (true)
            {
                // If credentials are valid, and of customer:
                return View(model);
            }

            // Inform the user of login error
            model.errorMsg = "Failed to  login. Invalid user name or password.";
            return View(model);
        }
    }
}