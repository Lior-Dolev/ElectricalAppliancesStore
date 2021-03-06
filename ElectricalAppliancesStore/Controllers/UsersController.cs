﻿using ElectricalAppliancesStore.DAL;
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

        // Search for Users
        public ActionResult UsersByName(String name)
        {
            List<Client> clients = UserManager.GetClients(clientsContext);
            clients.RemoveAll(item => item.FullName != name);

            return View("Index", clients);
        }

        // GET: Users
        public ActionResult AddClient()
        {
            //clientsContext.Database.Delete();
            //clientsContext.SaveChanges();

            return View(new EditClientView() { Address = new Address() });
        }

        public ActionResult Add(EditClientView client)
        {
            UserManager.AddClient(client, usersContext, clientsContext);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(EditClientView client)
        {
            UserManager.EditClient(client, usersContext, clientsContext);

            return RedirectToAction("Index");
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