using System;
using System.IO;
using System.Text;
using Nancy;
using Nancy.Responses;

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