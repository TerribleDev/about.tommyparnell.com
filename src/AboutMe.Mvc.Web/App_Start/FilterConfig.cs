using System.Web.Mvc;
using AboutMe.Mvc.Web.Filters;

namespace AboutMe.Mvc.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new WhiteSpaceFilterAttribute());
        }
    }
}
