using Nancy;
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
            conventions.StaticContentsConventions.AddFile("/robots.txt",System.IO.Path.Combine("Content", "robots.txt"));
            conventions.StaticContentsConventions.AddFile("/sitemap.xml", System.IO.Path.Combine("Content", "sitemap.xml"));
        }
    }
}