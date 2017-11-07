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

namespace ElectricalAppliancesStore.Controllers
{
    public class ManagerController : Controller
    {
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
            //Tweet.PublishTweet(rate.ToString());
        }

        public JsonResult GetProviders()
        {
            var data = Models.Stubs.ProvidersStub.GetProviders();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProducts()
        {
            var data = Models.Stubs.ProductsStub.GetProducts();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}