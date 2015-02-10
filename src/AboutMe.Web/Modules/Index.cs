using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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