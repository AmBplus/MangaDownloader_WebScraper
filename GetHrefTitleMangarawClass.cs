using AngleSharp;

namespace ConsoleApp2
{
    public class GetHrefTitleMangarawClass
    {
        public static async Task GetAttributeAsync(string href , string TitlePath)
        {
            string html = GetSourceWebSiteClass.GetUrlMangaRAw(href);
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            // GetSourceWebSiteClass geSourceWebSiteClass = new GetSourceWebSiteClass();
           
            var docment1 = await context.OpenAsync(reg => reg.Content(html));
            var imgClass = docment1.QuerySelectorAll("center img");
            string? Title = docment1.QuerySelector("h2").InnerHtml.Trim();
            
            string path = @$"{TitlePath}/{Title}";
            string path1 = "";
            
            Directory.CreateDirectory(@$"{path}");

            int i = 0;
            foreach (var item in imgClass)
            {
             path1 =  @$"{path}/{i}.jpg" ;
                byte[] dw= await DownloadImageClass.DownloadImageAsync(@$"{item.GetAttribute("src")}");
                File.WriteAllBytes(path1,dw);
                i++;
            }
        }
    }
}
