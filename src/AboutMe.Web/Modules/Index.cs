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
            Get["robots.txt"] = x =>
            {
                var res = this.Response.AsFile("robots.txt", "text/plain");
                res.Contents = a =>
                {
                    var msg = new StreamWriter(a);
                    msg.Write(new StringBuilder().AppendLine("User-agent: *"));
                    msg.Flush();
                    msg.Dispose();
                };

                return res;
            };
        }
    }
}