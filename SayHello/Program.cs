using System;
using System.Threading;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace SayHello
{
    class SayHello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            //Hello hello = new Hello();
            Thread thread = new Thread(new ThreadStart(Hello.run));
            thread.Start();
            //var tokenSource = new CancellationTokenSource();
            //var taskCall = Task.Run(hello.runAsync(),tokenSource.Token);
            //tokenSource.Cancel();
            //try
            //{
            //    await cancellableTask;
            //}
            //catch (OperationCanceledException e)
            //{
            //    // handle the exception
            //}
        }
    }
}
