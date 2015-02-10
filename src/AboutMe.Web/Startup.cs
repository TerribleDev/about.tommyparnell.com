using Microsoft.Owin;
using Microsoft.Owin.Extensions;

[assembly: OwinStartup(typeof(AboutMe.Web.Startup))]

namespace AboutMe.Web
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}