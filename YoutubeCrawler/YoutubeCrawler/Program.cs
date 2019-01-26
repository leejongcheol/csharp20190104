using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace YoutubeCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri targetUri = new Uri("https://www.youtube.com/watch?v=KB7HyDBy97U");
            HttpWebRequest webRequest = HttpWebRequest.Create(targetUri) as HttpWebRequest;
            using (HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse)
            {
                using (Stream webResponseStream = webResponse.GetResponseStream())
                {
                    Encoding targetEncoding = Encoding.UTF8;
                    HtmlAgilityPack.HtmlDocument s = new HtmlAgilityPack.HtmlDocument();
                    s.Load(webResponseStream, targetEncoding, true);
                    IXPathNavigable nav = s;

                    string title = WebUtility.HtmlDecode(nav.CreateNavigator().SelectSingleNode("/ html / head / meta[@property =’og:title’] / @content").ToString());
                    string description = WebUtility.HtmlDecode(nav.CreateNavigator().SelectSingleNode("/ html / head / meta[@property =’og:description’] / @content").ToString());
                    string fullDescription = WebUtility.HtmlDecode(s.GetElementbyId("eow - description").InnerHtml);

                    fullDescription = Regex.Replace(fullDescription, @"< (br | hr)[^>] >", Environment.NewLine);
                    fullDescription = Regex.Replace(fullDescription, @"<[^>] >", String.Empty).Trim();

                    Console.WriteLine(title);
                    Console.WriteLine(description);
                    Console.WriteLine(fullDescription);
                }
            }
        }
    }
}
