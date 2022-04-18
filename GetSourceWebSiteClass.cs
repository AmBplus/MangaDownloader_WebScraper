using System.Net;

namespace ConsoleApp2;

public class GetSourceWebSiteClass
{
    public static string GetUrlMangaRAw(string Url)
    {
        CookieContainer cookieJar = new();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.CookieContainer = cookieJar;
        request.Accept = @"text/html, application/xhtml+xml, */*";
        request.Referer = @"https://www.manga-raw.club/";
        request.Headers.Add("Accept-Language", "en-GB");
        request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
        request.Host = @"www.manga-raw.club";
        HttpWebResponse response03 = (HttpWebResponse)request.GetResponse();
        string htmlString;
        using (StreamReader reader = new StreamReader(response03.GetResponseStream()))
        {
            htmlString = reader.ReadToEnd();
        }

        return htmlString;
    }

    public static string GetUrlReaper(string Url)
    {
        try
        {
            string t = GetFinalRedirect(Url);

            WebClient client1 = new();
            string url = client1.DownloadString(Url);
            HttpClient client = new();
            Task<string> htT = client.GetStringAsync(Url);
            string ht = htT.ToString();
            CookieContainer cookieJar = new();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = cookieJar;
            request.Accept = @"text/html, application/xhtml+xml, */*";
            request.Referer = @"https://reaperscans.com";
            request.Headers.Add("Accept-Language", "en-GB");
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            request.Host = @"www.reaperscans.com";
            request.AllowAutoRedirect = true;
            HttpWebResponse response03 = (HttpWebResponse)request.GetResponse();
            string htmlString;
            using (StreamReader reader = new StreamReader(response03.GetResponseStream()))
            {
                htmlString = reader.ReadToEnd();
            }

            return htmlString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + " GetUrlReaper");
            return "";
        }
    }

    public static string GetUrlWebmota(string Url)
    {
        try
        {
            string t = GetFinalRedirect(Url);

            WebClient client1 = new();
            string url = client1.DownloadString(Url);
            HttpClient client = new();
            Task<string> htT = client.GetStringAsync(Url);
            string ht = htT.ToString();
            CookieContainer cookieJar = new();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = cookieJar;
            request.Accept = @"text/html, application/xhtml+xml, */*";
            request.Referer = @"https://www.webmota.com";
            request.Headers.Add("Accept-Language", "zh");
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            request.Host = @"www.webmota.com";
            request.AllowAutoRedirect = true;
            HttpWebResponse response03 = (HttpWebResponse)request.GetResponse();
            string htmlString;
            using (StreamReader reader = new StreamReader(response03.GetResponseStream()))
            {
                htmlString = reader.ReadToEnd();
            }

            return htmlString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + " GetUrlWebmota");
            return "";
        }
    }

    public static string GetFinalRedirect(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse response = request.GetResponse();
            return response.ResponseUri.AbsoluteUri;
        }
        catch (Exception ax)
        {
            return "";
        }
    }
}