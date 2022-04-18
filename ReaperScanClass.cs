using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ReaperScanClass
    {
        public static async Task<bool> GetReaperScanAsync(string website )
        {
            try
            {
                string html = GetSourceWebSiteClass.GetUrlReaper(website);
                var config = Configuration.Default;
                var context = BrowsingContext.New(config);
                var docment1 = await context.OpenAsync(reg => reg.Content(html));
                var imgClass = docment1.QuerySelectorAll("wp-manga-chapter-img");
                string? Title = docment1.QuerySelector("#chapter-heading").InnerHtml.Trim();
                string path = @$"{Title}";
                string path1 = "";
                Directory.CreateDirectory(@$"{path}");
                int i = 0;
                foreach (var item in imgClass)
                {
                    path1 = @$"{path}/{i}.jpg";
                    string DataSrc = item.GetAttribute("data-src").Trim();
                    byte[] dw = await DownloadImageClass.DownloadImageAsync(@$"{DataSrc}");
                    File.WriteAllBytes(path1, dw);
                    i++;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetReaperScanAsync");
                return false;
            }
            
        }
    }
}
