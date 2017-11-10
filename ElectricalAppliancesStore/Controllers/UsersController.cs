using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;
using ElectricalAppliancesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Controllers
{
    public class UsersController : Controller
    {
        public UsersContext usersContext = new UsersContext();
        public ClientsContext clientsContext = new ClientsContext();

        public ActionResult Index()
        {
            return View(UserManager.GetClients(clientsContext));
        }

        // GET: Users
        public ActionResult AddClient()
        {
            return View(new EditClientView() { Address = new Address() });
        }

        public ActionResult Add(EditClientView client)
        {
            UserManager.AddClient(client, usersContext, clientsContext);

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Edit(EditClientView client)
        {
            UserManager.EditClient(client, usersContext, clientsContext);

            return RedirectToAction("Index", "Login");
        }

        public ActionResult EditClient(int clientID)
        {
            EditClientView client = UserManager.GetClientByID(clientID, usersContext, clientsContext);
            return View(client);
        }

        public ActionResult DeleteClient(int clientID)
        {
            UserManager.DeleteClient(clientID, clientsContext, usersContext);
            return RedirectToAction("Index");
        }
    }
}