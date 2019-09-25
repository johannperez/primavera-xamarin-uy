using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonkeysSDK
{
    public class MonkeysSDK
    {
        #region sync methods

        public string GetRandomMonkey()
        {
            try
            {
                String randomMonkey = String.Empty;

                Task.Run(async () =>
                {
                    randomMonkey = await GetRandomMonkeyAsync();
                }).Wait() ;

                return randomMonkey;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Monkey[] GetMonkeyDevs()
        {
            try
            {
                Monkey[] monkeys = null;

                Task.Run(async () =>
                {
                    monkeys = await GetMonkeyDevsAsnyc();
                }).Wait();

                return monkeys;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void MonkeyBomb()
        {
            throw new Exception("Boom!");
        }

        #endregion

        #region async

        //These methods won't be generated on the Native library. Embeddinator does not understand Task
        private async Task<string> GetRandomMonkeyAsync()
        {
            //I know... not very efficient

            var monkeys = await ListMonkeys();
            int randomIndex = new Random(DateTime.Now.Millisecond).Next(monkeys.Count());
            return monkeys[randomIndex].Name; 
        }

        private async Task<Monkey[]> GetMonkeyDevsAsnyc()
        {
            return await ListMonkeys();
        }

        #endregion


        #region private methods
        private async Task<Monkey[]> ListMonkeys()
        {
            Console.WriteLine("**********1!");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.MEETUP_API);

                var response = await client.GetAsync(Constants.XAMARIN_UY_MEMBERS_ENDPOINT);
                Stream stream = await response.Content.ReadAsStreamAsync();
                var sr = new StreamReader(stream);
                Console.WriteLine("**********1!");

                return DeserializeJsonFromsStream<Monkey[]>(stream);
            }
        }

        private T DeserializeJsonFromsStream<T>(Stream stream)
        {
            var sr = new StreamReader(stream);
            var jtr = new JsonTextReader(sr);
            var js = new JsonSerializer();
            var result = js.Deserialize<T>(jtr);
            return result;
        }
        #endregion
    }
}
