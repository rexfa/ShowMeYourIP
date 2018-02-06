using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading;

namespace SayHello
{
    public abstract class Hello
    {
        public static void run()
        {
            HttpClient client;
            Console.WriteLine("start");

            while (true)
            {
                client = new HttpClient();
                //client.BaseAddress = 
                client.Timeout = new TimeSpan(0, 0, 5);
                try
                {
                    client.GetAsync(new Uri("http://XXXXXXX/Home/Contact/7788"));
                    Console.WriteLine("ok!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(15000);
            }
        }

    }
}
