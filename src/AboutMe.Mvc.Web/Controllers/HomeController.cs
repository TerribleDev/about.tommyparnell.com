using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AboutMe.Mvc.Web.Models;
using Untappd.Net.Client;
using Untappd.Net.Request;
using Untappd.Net.Responses.Feeds.UserActivityFeed;

namespace AboutMe.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 720)]
        public async Task<ActionResult> Index()
        {
            var currentBeer = string.Empty;
            try
            {
                var req = new UnAuthenticatedUntappdCredentials(ConfigurationManager.AppSettings["untappdkey"],
                ConfigurationManager.AppSettings["untappdsecret"]);
                var response = await new Repository().GetAsync<UserActivityFeed>(req, "tparnell");
                currentBeer = response.Response.Checkins.Items.First(a => DateTime.Parse(a.CreatedAt) > DateTime.Now.AddHours(-4)).Beer.BeerName;
            }
            catch(Exception)
            {
                
            }
            var t = new HomeViewModel() { CurrentBeer = currentBeer };
            return View(t);
        }
    }
}