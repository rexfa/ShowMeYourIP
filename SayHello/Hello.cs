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
            
            Console.WriteLine("start");

            while (true)
            {
                using (var handler = new HttpClientHandler())
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("XXXXX");
                    //client.Timeout = new TimeSpan(0, 0, 5);
                    try
                    {
                        Task<HttpResponseMessage> response = client.GetAsync("Home/Contact/7788");
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
                Thread.Sleep(20000);
            }
        }

    }
}
