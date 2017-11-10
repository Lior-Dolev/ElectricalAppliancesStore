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
        public ProductsContext  dbProducts   = new ProductsContext();
        public ProvidersContext dbProviders  = new ProvidersContext();

        public OrdersContext  dbOrders       = new OrdersContext();
        public ClientsContext dbClients      = new ClientsContext();

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

        public JsonResult AveragePurchasePerMonth()
        {
            // Calculate average 'order' price per month ...
            double[] totalPerMonth = new double[13];
            int[] CountPerMount    = new int[13];

            foreach(var order in dbOrders.Orders)
            { 
                CountPerMount[order.PurchaseDate.Month] += 1;
                double totalSum = order.PriceSum();

                if (order.CurrencyPurchase == "USD")
                {
                    totalSum *= (double)CurrencyRate();
                }

                totalPerMonth[order.PurchaseDate.Month] += totalSum ;
            }

            for ( int idx = 1; idx < 13; ++idx)
            {
                if ( 0 == CountPerMount[idx])
                {
                    ++CountPerMount[idx];
                }
            }

            var toBeJson = new[]
            {
                new { Month = "January"    ,   price = (totalPerMonth[1] / CountPerMount[1]) },
                new { Month = "February"   ,   price = (totalPerMonth[2] / CountPerMount[2]) },
                new { Month = "March"      ,   price = (totalPerMonth[3] / CountPerMount[3]) },
                new { Month = "April"      ,   price = (totalPerMonth[4] / CountPerMount[4]) },
                new { Month = "May"        ,   price = (totalPerMonth[5] / CountPerMount[5]) },
                new { Month = "June"       ,   price = (totalPerMonth[6] / CountPerMount[6]) },
                new { Month = "July"       ,   price = (totalPerMonth[7] / CountPerMount[7]) },
                new { Month = "August"     ,   price = (totalPerMonth[8] / CountPerMount[8]) },
                new { Month = "September"  ,   price = (totalPerMonth[9] / CountPerMount[9]) },
                new { Month = "October"    ,   price = (totalPerMonth[10] / CountPerMount[10]) },
                new { Month = "November"   ,   price = (totalPerMonth[11] / CountPerMount[11]) },
                new { Month = "December"   ,   price = (totalPerMonth[12] / CountPerMount[12]) },
            };

            return Json(toBeJson, JsonRequestBehavior.AllowGet);
        }

   
        public JsonResult JoinOrdersByClients()
        {
            // TODO:: should be uncommented when we have 
            //          clients and orders
            //var query = dbClients.Clients.AsEnumerable().Join(
            //                                   dbOrders.Orders.AsEnumerable(),
            //                                   client => client.ID,
            //                                   order => order.ClientID,
            //                                   (client, order) => new
            //                                   {
            //                                       PurchaseDate     = order.PurchaseDate,
            //                                       FullName         = client.FullName,
            //                                       PriceSum         = order.PriceSum(),
            //                                       CurrencyPurchase = order.CurrencyPurchase
            //                                   }).GroupBy(record => record.PurchaseDate).ToList();

            //return Json(query, JsonRequestBehavior.AllowGet);

            return null;
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