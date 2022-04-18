using AngleSharp;
using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class MangaRawClass
    {
        public static async Task<bool> GetMangaRawAsync(string website, string web)
        {
            try
            {
                var config = Configuration.Default;
                var context = BrowsingContext.New(config);
                string htmlString = GetSourceWebSiteClass.GetUrlMangaRAw(website);
                var docment = await context.OpenAsync(reg => reg.Content(htmlString));
                string h1Title = docment.QuerySelector(".main-head h1").InnerHtml.Trim();
                Directory.CreateDirectory(h1Title);
                var imgClass = docment.QuerySelectorAll(".chapter-list a");
                foreach (var item in imgClass)
                {
                    string address = @$"{web}{item.GetAttribute("href")}";
                    string title = item.GetAttribute("title");
                    GetHrefTitleMangarawClass.GetAttributeAsync(address, h1Title);
                    Console.WriteLine($"address: {address} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                
            }
            return true;
        }
        
    }
}
