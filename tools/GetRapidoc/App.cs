using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using HtmlAgilityPack;
using System.IO;

namespace GetRapidoc
{
    public class App
    {

        private readonly ILogger<App> _logger;
        private readonly AppOption _appOption;
        public App(ILogger<App> logger, IOptions<AppOption> appOption)
        {
            _logger = logger;
            _appOption = appOption.Value;
        }

        public async Task RunAsync(string[] args)
        {
            _logger.LogInformation("App Run Start");

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
{ "Accept", "text /html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
{ "Accept-Encoding", "gzip, deflate"},
{ "Accept-Language", "zh-CN,zh;q=0.9" },
{ "Host", "rapidocweb.com"},
{ "Referer","https://rapidocweb.com/api.html"},
{ "Cache-Control"," max-age=0"},
{ "Connection"," keep-alive"},
//{ "Proxy-Connection"," keep-alive"},
{ "Upgrade-Insecure-Requests", "1"},
{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36"}
            };

            string url = "https://rapidocweb.com/api.html";
            HtmlWeb web = Util.GetHtmlWeb(headers);
            HtmlDocument htmlDoc = web.Load(url);
            HtmlNodeCollection tables = htmlDoc.DocumentNode.SelectSingleNode($"//div[@class='table-block']").SelectNodes("table[@class='m-table']");

            var apiDtos = new List<APIDto>();
            for (var i = 0; i < tables.Count; i++)
            {
                var trs = tables[i].SelectNodes("tr");
                for (var j = 0; j < trs.Count; j++)
                {
                    var tds = trs[j].SelectNodes("td");

                    if (tds.Count > 2)
                    {
                        var apiDto = new APIDto
                        {
                            Name = tds[0].InnerText.Trim(),
                            Desc = tds[1].InnerText.Trim().Replace("\n", "\n        ///").Replace("             ", ""),
                            DefaultVal = tds[2].InnerText.Trim()
                        };
                        apiDtos.Add(apiDto);
                    }
                }

            }

            var model = new
            {

                apilist = apiDtos

            };

            string templatePath = Path.Combine(Environment.CurrentDirectory, _appOption.TemplatesPath);
            CodeScaffolding codeScaffolding = new CodeScaffolding(templatePath, _appOption.OutputDirectory);
            await codeScaffolding.GenerateAsync(model);

            _logger.LogInformation("App Run End!");
        }

    }
}
