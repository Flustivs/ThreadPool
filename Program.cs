using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++) 
            {
                ThreadPool.QueueUserWorkItem(Write);
                Thread.Sleep(10);

            }
            for (int i = 0; i <5; i++)
            {
                Thread th = new Thread(Write);
                th.Start();
                Thread.Sleep(10);
            }
        }

        static void Write(object callback)
        {
            smth("\nHello World!\n");
            Process();
        }

        static void smth(string obj)
        {
            Console.WriteLine(obj);
        }
        static void Process()
        {
            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("Alive: " + Thread.CurrentThread.IsAlive.ToString());
            Console.WriteLine("Is Background: " + Thread.CurrentThread.IsBackground.ToString());
            Console.WriteLine("Priority: " + Thread.CurrentThread.Priority.ToString());
        }
    }
}