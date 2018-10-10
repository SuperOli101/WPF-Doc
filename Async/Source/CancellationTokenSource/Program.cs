using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var task = Task.Factory.StartNew(() =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                bool moreToDo = true;
                while (moreToDo)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        moreToDo = false;
                    }
                    Console.WriteLine("Working for " + sw.Elapsed);
                }
            }, cts.Token);
            task.Wait();
            Console.Read();
        }
    }
}
