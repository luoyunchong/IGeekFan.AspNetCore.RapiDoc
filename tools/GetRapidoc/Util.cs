using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetRapidoc
{
    class Util
    {
        public static HtmlWeb GetHtmlWeb(Dictionary<string, string> _headers)
        {
            HtmlWeb web = new HtmlWeb();

            HtmlWeb.PreRequestHandler handler = delegate (HttpWebRequest request)
            {
                foreach (var header in _headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.CookieContainer = new CookieContainer();
                return true;
            };
            web.PreRequest += handler;
            web.OverrideEncoding = Encoding.Default;

            return web;
        }
    }
}
