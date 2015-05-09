using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace AboutMe.Mvc.Web.Filters
{
    public class WhiteSpaceFilterAttribute : ActionFilterAttribute
    {
        private static readonly Regex RegexWhiteSpace = new Regex(@"\s+", RegexOptions.Compiled);
        private static readonly Regex RegexNewLine = new Regex(@"\s*\n\s*", RegexOptions.Compiled);
        private static readonly Regex RegexCharsInBetweenBackets = new Regex(@"\s*\>\s*\<\s*", RegexOptions.Compiled);
        private static readonly Regex RegexComments = new Regex(@"<!--(.*?)-->", RegexOptions.Compiled);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var response = filterContext.HttpContext.Response;

            response.Filter = new WhiteSpaceFilter(response.Filter, s =>
            {
                s = RegexWhiteSpace.Replace(s, " ");
                s = RegexNewLine.Replace(s, "\n");
                s = RegexCharsInBetweenBackets.Replace(s, "><");
                s = RegexComments.Replace(s, "");

                // single-line doctype must be preserved 
                var firstEndBracketPosition = s.IndexOf(">", StringComparison.Ordinal);
                if (firstEndBracketPosition >= 0)
                {
                    s = s.Remove(firstEndBracketPosition, 1);
                    s = s.Insert(firstEndBracketPosition, ">");
                }
                return s;
            });
        }
    }
}
