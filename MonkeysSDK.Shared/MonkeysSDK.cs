using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonkeysSDK
{
    public static class MonkeysSDK
    {
        public static async Task<string> GetRandomMonkey()
        {
            return (await ListMonkeys()).FirstOrDefault().Name; //I know... not very efficient
        }

        public static async Task<Monkey[]> GetMonkeyDevs()
        {
            return await ListMonkeys(); //I know... not very efficient

        }

        private static async Task<Monkey[]> ListMonkeys()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Constants.XAMARIN_UY_ENDPOINT);
                Stream stream = await response.Content.ReadAsStreamAsync();
                var sr = new StreamReader(stream);
                return DeserializeJsonFromsStream<Monkey[]>(stream);
            }
        }

        private static T DeserializeJsonFromsStream<T>(Stream stream)
        {
            var sr = new StreamReader(stream);
            var jtr = new JsonTextReader(sr);
            var js = new JsonSerializer();
            var result = js.Deserialize<T>(jtr);
            return result;
        }
    }
}
