using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Length here");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Insert Width here");
            int width = int.Parse(Console.ReadLine());

            AreaRectangle.AreaRec rect = new AreaRectangle.AreaRec(length,width);
            var result = AreaRecAsync(rect).Result;
            Console.WriteLine("Final result is " + result);
            Console.ReadKey();
        }

        public static async Task<string> AreaRecAsync(AreaRectangle.AreaRec rec)
        {
            string result = null;
            using (HttpClient client = new HttpClient())
            {
                var jsonstring = JsonConvert.SerializeObject(rec);
                StringContent content = new StringContent(jsonstring, Encoding.UTF8,"application/json");

                HttpResponseMessage response =
                    await client.PostAsync("https://localhost:44372/Rectangle/AreaRectangle", content);
                if (response.StatusCode != HttpStatusCode.Conflict)
                {
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("Service is not running");
                }
            }

            return result;
        }
    }
}
