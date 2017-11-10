using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Models;

using System.Web.Services;

using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using ElectricalAppliancesStore.DAL;
using ElectricalAppliancesStore.Managers;
using ElectricalAppliancesStore.Models.Stubs;

namespace ElectricalAppliancesStore.Controllers
{
    public class ManagerController : Controller
    {
        public ProductsContext dbProducts = new ProductsContext();
        public ProvidersContext dbProviders = new ProvidersContext();

        public static ITwitterCredentials auth =
            Auth.SetUserCredentials("pQJn6sjNxuivMZMlRz6aGIqSk",
                                    "hRchrNrU8pv10e5HIu4eag5ZQz1J2jYPZuwv7ME6mMEnns6503",
                                    "924214133867806720-2LCmCadngZ8HU7FedaBRDF3qPBZKm39",
                                    "vDdph6vAYdW41Xq95G6MR3fuRvC8xLw6MxuZwt49XnGef");

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public void PostTweet(string text)
        {
            Tweet.PublishTweet(text);
        }

        public JsonResult JoinProductsByProvider()
        {
           
            var query = dbProviders.Providers.AsEnumerable().Join(
                                                dbProducts.Products.AsEnumerable(),
                                                provider => provider.ID,
                                                product => product.ProviderID,
                                                (provider, product) => new
                                                {
                                                    CompanyName = provider.CompanyName,
                                                    ProductName = product.Title
                                                }).ToList();// .GroupBy(record => record.ProviderId);

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public decimal CurrencyRate()
        {
            WebClient web = new WebClient();
            var fromCurrency = "ILS";
            var toCurrency = "USD";
            var amount = 1;
            string url = string.Format("https://finance.google.com/finance/converter?a={2}&from={0}&to={1}&meta=ei%3DNqL8WbiQLIOWUq6Bv_gH", fromCurrency.ToUpper(), toCurrency.ToUpper(), amount);
            string response = web.DownloadString(url);
            Regex regex = new Regex("<span class=bld>(\\d*.\\d*) ");
            decimal rate = System.Convert.ToDecimal(regex.Match(response).Groups[1].Value);
            return rate;
        }
        
        public JsonResult GetBranches()
        {
            var data = BranchesStub.GetBranches();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts()
        {
            var data = ProductsManager.GetProducts(dbProducts);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbProducts.Dispose();
                dbProviders.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}