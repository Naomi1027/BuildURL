using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BuildURL
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    string url = @"https://naganofudou3.com/page0006.html";
        //    Console.WriteLine(url);
        //}


        static async Task Main()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            string url = @"https://harenohi-fudousan.com/sale-/#contents";

            var document = await context.OpenAsync(url);
            Console.WriteLine($"物件一覧ページ: {url}");
            var elems = document.QuerySelectorAll(".reals .link a");
            //物件の一つの情報を取得
            foreach (var elem in elems)
            {
                // 物件の詳細URLを取得
                var info = GetDetail(elem);
            }
            

        }

        public static string GetDetail(IElement elem)
        {
            string detailInfo = string.Empty;
            // 物件の名前を取得
            //var detailInfo = elem.QuerySelector("div div div div:nth-child(2) strong a").TextContent;

            // 物件の詳細URLを取得
            //var detailInfo = elem.QuerySelector("a").GetAttribute("href");

            // 物件の金額を取得
            //var price1 = elem.QuerySelector("div div div div:nth-child(3) strong span");
            //var price2 = elem.QuerySelector("div div div div div div:last-child div div:nth-child(2) strong span");
            //var detailInfo1 = price1?.TextContent;
            //var detailInfo2 = price2?.TextContent;
            //if (detailInfo1.Contains("円"))
            //{
            //    var detailInfo = detailInfo1;
            //    return detailInfo;

            //}
            //else if (detailInfo2.Contains("円"))
            //{
            //    var detailInfo = detailInfo2;
            //    return detailInfo;
            //}
            //else
            //{
            //    var detailInfo = "価格情報なし";
            //    return detailInfo;

            //}
            //var elements = elem.QuerySelectorAll("span");
            //foreach (var element in elements)
            //{
            //    var text = element.TextContent;
            //    if (text != null && text.Contains("土地："))
            //    {
            //        var idx = text.IndexOf("土地：");
            //        if (idx >= 0)
            //        {
            //            detailInfo = text.Substring(idx).Trim();
            //        }
            //    }
            //}
            var element = elem.GetAttribute("href");
            var uri = "https://harenohi-fudousan.com" + element.Remove(0, 1) + "#contents";
            detailInfo = uri;

            return detailInfo;
        }

        //public static string GetDetail(Element elem)
        //{
        //    var propertyInfo = new Dictionary<string, string>();

        //    // cellpadding="15" を持つテーブルを探す（物件情報のテーブル）
        //    var propertyTable = elem.QuerySelector("table[cellpadding='15']");
        //    if (propertyTable != null)
        //    {
        //        var rows = propertyTable.QuerySelectorAll("tr");
        //        foreach (var row in rows)
        //        {
        //            // 背景色を持つtd（見出しセル）を探す
        //            var labelCell = row.QuerySelector("td[style*='background-color: #f0e3ca']");
        //            var valueCell = row.QuerySelector("td:not([style*='background-color'])");

        //            if (labelCell != null && valueCell != null)
        //            {
        //                var label = labelCell.TextContent?.Trim();
        //                var value = valueCell.TextContent?.Trim();

        //                // 価格と所在地の情報を収集
        //                if (label?.Contains("価格") == true || label?.Contains("所在地") == true)
        //                {
        //                    propertyInfo[label] = value ?? "情報なし";
        //                }
        //            }
        //        }
        //    }

        //    // 収集した情報を整形して返す
        //    var result = string.Join("\n", propertyInfo.Select(p => $"{p.Key}: {p.Value}"));
        //    return string.IsNullOrEmpty(result) ? "情報なし" : result;
        //}
        //public static string GetDetail(Element elem)
        //{
        //    var propertyInfo = new Dictionary<string, string>();

        //    // cellpadding="15" を持つすべてのテーブルを探す（複数のテーブルに情報が分散している可能性があるため）
        //    var propertyTables = elem.QuerySelectorAll("table[cellpadding='15']");
        //    foreach (var table in propertyTables)
        //    {
        //        var rows = table.QuerySelectorAll("tr");
        //        foreach (var row in rows)
        //        {
        //            // 背景色を持つtd（見出しセル）を探す
        //            var labelCell = row.QuerySelector("td:first-child");
        //            //var labelCell = row.QuerySelector("td[style*='background-color: #f0e3ca']");
        //            //var valueCell = row.QuerySelector("td:not([style*='background-color'])");
        //            var valueCell = row.QuerySelector("td:last-child");

        //            if (labelCell != null && valueCell != null)
        //            {
        //                var label = labelCell.TextContent?.Trim();
        //                var value = valueCell.TextContent?.Trim();

        //                // 取得したい情報のキーワードリスト
        //                if (label != null && value != null &&
        //                    (label.Contains("価格") ||
        //                     label.Contains("住所") ||
        //                     label.Contains("建物構造") ||
        //                     label.Contains("上下水道") ||
        //                     label.Contains("間取り") ||
        //                     label.Contains("土地面積") ||
        //                     label.Contains("建物面積")))
        //                {
        //                    propertyInfo[label] = value;
        //                }
        //            }
        //        }
        //    }

        //    // 収集した情報を整形して返す
        //    var result = string.Join("\n", propertyInfo.Select(p => $"{p.Key}: {p.Value}"));
        //    return string.IsNullOrEmpty(result) ? "情報なし" : result;
        //}


    }

}
