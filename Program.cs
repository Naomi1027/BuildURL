using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BuildURL
{
    internal static class Program
    {
        static async Task Main()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            string[] listUrls = {
                "https://naganofudou3.com/page0006.html",
                "https://naganofudou3.com/page0009.html",
                "https://naganofudou3.com/page561234.html"
            };

            // 物件ページのURLパターン
            //var propertyPagePattern = new Regex(@"^page\d+\.html$", RegexOptions.IgnoreCase);

            foreach (var url in listUrls)
            {
                var document = await context.OpenAsync(url);
                var elems = document.QuerySelectorAll("#content td div tbody tr:nth-child(2)");
                foreach (var elem in elems)
                {
                    var text = elem.textContent.Trim();
                    Console.WriteLine($"物件ページURL: {text}");
                }
            }


        }
    }
}
