//using AngleSharp;
//using AngleSharp.Dom;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;


//namespace BuildURL
//{
//    internal static class Program
//    {
//        static async Task Main()
//        {
//            var config = Configuration.Default.WithDefaultLoader();
//            var context = BrowsingContext.New(config);

//            string url = @"https://naganofudou3.com/page551715.html";

//            var document = await context.OpenAsync(url);
//            Console.WriteLine($"物件一覧ページ: {url}");

//            List<string> buildingInfos = new List<string>();
//            var elems = document.QuerySelectorAll(".content_inn span");
//            //物件の一つの情報を取得
//            foreach (var elem in elems)
//            {
//                // 物件の詳細情報を取得
//                var info = GetDetail(elem);
//                buildingInfos.Add(info);
//            }
//        }

//        public static string GetDetail(IElement elem)
//        {
//            string detailInfos = string.Empty;

//            var title = elem?.TextContent;
//            switch(title)
//            {
//                case "価格":
//                    var price = GetTitle(elem);
//                    detailInfos = price;
//                    break;
//                case "所在地":
//                    var address = GetTitle(elem);
//                    detailInfos = address;
//                    break;
//                case "土地面積":
//                    var area = GetTitle(elem);
//                    detailInfos = area;
//                    break;
//                case "接道状況":
//                    var road = GetTitle(elem);
//                    detailInfos = road;
//                    break;
//                default:
//                    detailInfos = string.Empty; // またはnull
//                    break;
//            }
//            return detailInfos;
//        }

//        public static string GetTitle(IElement elem)
//        {
//            // spanの親tdを取得
//            var parentTd = elem?.Closest("td");
//            // 次の兄弟tdを取得
//            var valueTd = parentTd?.NextElementSibling;
//            var targetSpan = valueTd.QuerySelector("span");
//            if (targetSpan != null)

//                return targetSpan.TextContent.Trim();

//            return valueTd.TextContent.Trim(); ;
//        }
//    }

//}
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
        static async Task Main()
        {
            try
            {
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                string url = @"https://naganofudou3.com/page551715.html";
                var document = await context.OpenAsync(url);
                Console.WriteLine($"物件一覧ページ: {url}");

                var propertyInfo = new PropertyInfo();
                var elems = document.QuerySelectorAll(".content_inn span");

                // 物件の詳細情報を取得
                foreach (var elem in elems)
                {
                    var title = elem?.TextContent?.Trim();
                    var value = GetPropertyValue(elem);

                    if (!string.IsNullOrEmpty(value))
                    {
                        SetPropertyValue(propertyInfo, title, value);
                    }
                }

                // 結果を表示
                Console.WriteLine(propertyInfo.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }

        // 物件の値を取得（null安全）
        public static string GetPropertyValue(IElement elem)
        {
            try
            {
                // spanの親tdを取得
                var parentTd = elem?.Closest("td");
                if (parentTd == null) return string.Empty;

                // 次の兄弟tdを取得
                var valueTd = parentTd.NextElementSibling;
                if (valueTd == null) return string.Empty;

                // span要素があればそれを、なければtdの内容を取得
                var targetSpan = valueTd.QuerySelector("span");
                var result = targetSpan?.TextContent?.Trim() ?? valueTd.TextContent?.Trim();

                return result ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        // プロパティに値を設定
        private static void SetPropertyValue(PropertyInfo propertyInfo, string title, string value)
        {
            switch (title)
            {
                case "価格":
                    propertyInfo.Price = value;
                    Console.WriteLine($"価格: {value}");
                    break;
                case "所在地":
                    propertyInfo.Address = value;
                    Console.WriteLine($"所在地: {value}");
                    break;
                case "土地面積":
                    propertyInfo.LandArea = value;
                    Console.WriteLine($"土地面積: {value}");
                    break;
                case "接道状況":
                    propertyInfo.RoadAccess = value;
                    Console.WriteLine($"接道状況: {value}");
                    break;
            }
        }
    }
}