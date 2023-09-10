namespace Contracts.Extensions
{
    public static class ImageExtention
    {
        public static async Task<string> GetImageAsBase64Url(this string url)
        {
            using HttpClientHandler handler = new() { };
            using HttpClient client = new(handler);
            byte[] bytes = await client.GetByteArrayAsync(url);
            return "image/jpeg;base64," + Convert.ToBase64String(bytes);
        }
    }
}
