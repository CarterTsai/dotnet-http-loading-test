using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace dotnet
{
    class Program
    {
        public static int Main(string[] args) {
            var attackNum = Environment.GetEnvironmentVariable("ATTACK_NUMBER");

            if(attackNum == null) {
                System.Console.WriteLine("Please Set Environment: ATTACK_NUMBER");
                return 0 ;
            }

            for (int i = 0; i < Int64.Parse(attackNum); i++)
            {
                Task<string> task = MainAsync();
                task.Wait();
                var x = task.Result;
            }

            return 0;
        }
        static async Task<string> MainAsync()
        {
            var url =  Environment.GetEnvironmentVariable("TEST_URL");
            if(url == null) {
                System.Console.WriteLine("Please Set Environment: TEST_URL");
                return "";
            }
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var status = response.StatusCode;
            Console.WriteLine("status " + status);

            return responseBody;
        }
    }
}
