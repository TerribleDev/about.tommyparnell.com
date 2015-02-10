using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;

namespace AboutMe.Web.AppStart
{
    public class Bootstrap : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.AddDirectory("Images");
            conventions.StaticContentsConventions.AddDirectory("Scripts");
            conventions.StaticContentsConventions.AddDirectory("fonts");
        }
    }
}