using AngleSharp;
using AngleSharp.Dom;
using ConsoleApp2;

public class Webmota
{
    public static async Task<bool> GetWebmotaAsync(string website, int number)
    {
        try
        {
            string html = GetSourceWebSiteClass.GetUrlWebmota(website);
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument docment1 = await context.OpenAsync(reg => reg.Content(html));

            IHtmlCollection<IElement> imgClass = docment1.QuerySelectorAll("amp-img");
            //string? Title = docment1.QuerySelector("#chapter-heading").InnerHtml.Trim();
            string path = @$"WifeEmpror-{number}";
            string path1 = "";
            Directory.CreateDirectory(@$"{path}");
            int i = 0;
            List<string> items = new();
            foreach (IElement item in imgClass)
            {
                string? dataSrc = item.GetAttribute("src").Trim();
                if (!string.IsNullOrEmpty(dataSrc)) items.Add(dataSrc);
            }

            foreach (string item in items)
            {
                Console.WriteLine(item);
                path1 = @$"{path}/{i}.jpg";

                byte[] dw = await DownloadImageClass.DownloadImageAsync(@$"{item}");
                File.WriteAllBytes(path1, dw);
                i++;
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Finished ....");

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + " WebMota");
            return false;
        }
    }
}