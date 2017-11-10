using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;

namespace ElectricalAppliancesStore.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Branchs(bool isMgr)
        {
            List<Branch> branches = BranchesStub.GetBranches();
            if (isMgr){
                return View("ManageBranches", branches);
            }
            return View(branches);
        }
    }
}