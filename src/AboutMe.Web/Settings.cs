using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AboutMe.Web
{
    public static class Settings
    {
        public static IEnumerable<string> Phones = new[] {"iphone","ppc",
                                                      "windows ce","blackberry",
                                                      "opera mini","mobile","palm",
                                                      "portable","opera mobi", "android" };

        public static bool IsMobile(string userAgent)
        {
            if (string.IsNullOrWhiteSpace(userAgent))
            {
                return false;
            }
            var agent = userAgent.ToLower();
            return Phones.Any(x => agent.Contains(x));
        }
    }
}