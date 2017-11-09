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
    public class ProvidersController : Controller
    {
        ProvidersContext dbProviders = new ProvidersContext();

        // GET: Providers
        public ActionResult Index()
        {
            return View(ProvidersManager.GetProviders(dbProviders));
        }

        public ActionResult AddProvider()
        {
            return View("AddProvider", new Provider());
        }

        public ActionResult Add(Provider provider)
        {
            ProvidersManager.AddProvider(provider, dbProviders);

            return RedirectToAction("Index");
        }

        public ActionResult EditProvider(int providerID)
        {
            Provider provider = ProvidersManager.GetProviderByID(providerID, dbProviders);
            return View("EditProvider", provider);
        }

        public ActionResult Edit(Provider provider)
        {
            ProvidersManager.Edit(provider, dbProviders);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int providerID)
        {
            ProvidersManager.Delete(providerID, dbProviders);
            return RedirectToAction("Index");
        }
    }
}