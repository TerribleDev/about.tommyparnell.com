using Nancy;

namespace AboutMe.Web.Modules
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = x => View["Index"];
        }
    }
}