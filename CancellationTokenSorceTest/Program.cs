using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenSorceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var notifier = new CancellationTokenSource();
            int a = 10;
            Task.Factory.StartNew(() =>
            {
                while (!notifier.IsCancellationRequested)
                {
                    Thread.Sleep(30);
                }
                Console.WriteLine("Enter Here");
            }, notifier.Token);
            notifier.Token.Register(() =>
            {
                Thread.Sleep(1100);
                Console.WriteLine(a);
            });

            Thread.Sleep(1000);
            notifier.Cancel();
            Console.ReadLine();
        }
    }
}
