using System;
using System.Threading;
using System.Net.Http;
using System.Text;
using System.Web;
namespace SayHello
{
    class SayHello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Thread thread = new Thread(new ThreadStart(Hello.run));
            thread.Start();
        }
    }
}
