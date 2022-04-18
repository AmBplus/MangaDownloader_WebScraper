namespace ConsoleApp2
{
    public class DownloadImageClass
    {
        public static async Task<byte[]> DownloadImageAsync(string ImageUrl)
        {

            HttpClient client = new HttpClient();
            byte[] httpResponseMessage = await client.GetByteArrayAsync(ImageUrl);
            return httpResponseMessage;
        }
    }
}
