using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ChinaExpress.Extensions
{
    public static class APIHelper
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string PixBayKey = "44085187-b326463c8edbb03c88e77d31e";
        private static readonly Random random = new Random();

        public static async Task<string> GetRandomPhoto(string keyword)
        {
            string url = $"https://pixabay.com/api/?key={PixBayKey}&q={Uri.EscapeDataString(keyword)}&orientation=horizontal";

            try
            {
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var data = JObject.Parse(responseBody);

                return data
                    ["hits"]
                    [random.Next(1, 10)]
                    ["previewURL"]
                    .ToString();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request Failed: {e.Message}");
            }

            //Return photo default on error;
            return
                "https://previews.123rf.com/images/fordzolo/fordzolo1506/fordzolo150600296/41026708-example-white-stamp-text-on-red-backgroud.jpg";
        }
    }
}
