using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AboutMe.Mvc.Web.Models;
using Untappd.Net.Client;
using Untappd.Net.Request;
using Untappd.Net.Responses.Feeds.UserActivityFeed;

namespace AboutMe.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 900)]
        public async Task<ActionResult> Index()
        {
            var currentBeer = string.Empty;
            try
            {
                var req = new UnAuthenticatedUntappdCredentials(ConfigurationManager.AppSettings["untappdkey"],
                ConfigurationManager.AppSettings["untappdsecret"]);
                var response = await new Repository().GetAsync<UserActivityFeed>(req, "tparnell");
                currentBeer = response.Response.Checkins.Items[0].Beer.BeerName;
            }
            catch(Exception)
            {
                
            }
            var t = new HomeViewModel() { CurrentBeer = currentBeer };
            return View(t);
        }
    }
}