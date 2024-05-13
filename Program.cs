using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread oldThread = new Thread(Write);
            for (int i = 0; i < 5; i++) 
            {
                ThreadPool.QueueUserWorkItem(Write);
                Thread.Sleep(10);

            }
            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(Write);
                th.Start(); // Starts the thread from where this threads entrypoint is, in this case its th Write() method

                if (i == 4)
                {
                    th.Join(); // The Join method will block and thread calling to this untill its terminated
                    Console.WriteLine("Succesfully used Join()");
                }
                if (i == 1)
                {
                    th.Interrupt(); // Read about how the Abort would give a compile-time warning plus i couldnt make it work, but i know it
                    Console.WriteLine("Succesfully used Interrupt()");
                }
                Thread.Sleep(10);
            }
        }

        static void Write(object callback)
        {
            ThreadWrite("\nHello World!\n");
            Process();
        }

        static void ThreadWrite(string obj)
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