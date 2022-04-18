namespace ConsoleApp2;

public class ChoiceClass
{
    public static async void Choice()
    {
        //string website = "https://www.manga-raw.club/manga/i-reincarnated-as-a-legendary-surgeon";
        string MangaRawWebSite_manga = "https://www.manga-raw.club/manga/perfect-surgeon";
        string MangaRAwWebSite = "https://www.manga-raw.club";
        string ReaperScanWebSite_manga = "https://reaperscans.com/series/seoul-station-druid/chapter-37";
        string seoulstationdruidOnline = "https://www.seoulstationdruid.online/manga/seoul-station-druid-chapter-47/";

        Console.WriteLine(" plz enter your choice  ");
        Console.WriteLine("0: MangaRaw \n 1: ReaperScan \n 2 : WebMota 3: seoulstationdruid.online ");
        Console.WriteLine(" Choice : ");
        int choice;
        bool flag = int.TryParse(Console.ReadLine(), out choice);
        if (flag)
            switch (choice)
            {
                case 0:
                {
                    await MangaRawClass.GetMangaRawAsync(MangaRawWebSite_manga, MangaRAwWebSite);
                    break;
                }
                case 1:
                {
                    await ReaperScanClass.GetReaperScanAsync(ReaperScanWebSite_manga);
                    break;
                }
                case 2:
                {
                    for (int i = 54; i < 58; i++)
                    {
                        string webmotaAddress =
                            "https://www.webmota.com/comic/chapter/wojianiangzijingranshinudi-yuanzhulaogouciweimaoyueduxinrexie" +
                            $"/0_{i}.html";
                        Webmota.GetWebmotaAsync(webmotaAddress, i);
                    }

                    break;
                }
                case 3:
                {
                    break;
                }
                default:
                    Choice();
                    break;
            }
    }
}