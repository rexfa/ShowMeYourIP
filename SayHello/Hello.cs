using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading;
using System.Threading.Tasks;

namespace SayHello
{
    public class Hello
    {
        public static void run()
        {
            
            Console.WriteLine("start-15");

            while (true)
            {
                using (var handler = new HttpClientHandler())
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("XXXXXXXXX");
                    //client.Timeout = new TimeSpan(0, 0, 5);
                    try
                    {
                        Task<HttpResponseMessage> response = client.GetAsync("Home/Contact/7788");
                        //Task<HttpResponseMessage> response = client.GetAsync("Home/About");
                        //var header0 = hrm.Headers.Contains("title");
                        Console.WriteLine("ok!"+ response.Result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        client.Dispose();
                    }
                }
                System.GC.Collect();
                Thread.Sleep(15000);
            }
        }

    }
}
