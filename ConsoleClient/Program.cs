using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Async Exercise - type 'q' to quit");

            HttpClient _client = new HttpClient();

            Console.Write(">");
            char input = Console.ReadKey().KeyChar;
            while (input != 'q')
            {
                DateTime start = DateTime.Now;
                await Task.Factory.StartNew(async () =>
                {
                    Task<HttpResponseMessage> gettingAsyncResponse = _client.GetAsync("https://localhost:5003/numbers/12");
                    var asyncResponse = await gettingAsyncResponse;
                    string result = asyncResponse.Content.ReadAsStringAsync().Result;
                    WriteToFile("Result: " + result + " between " + start.ToLongTimeString() + " - " + DateTime.Now.ToLongTimeString());
                });

                Console.Write(">");
                input = Console.ReadKey().KeyChar;
            }
        }

        private static void WriteToFile(string s)
        {
                string path = @"fromclient.txt";

                StreamWriter sw = File.AppendText(path);

                sw.WriteLine(s);

                sw.Flush();
        }
    }
}
