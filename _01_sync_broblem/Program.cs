using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_sync_broblem
{
    /*
    ■ Thread 1 reads count into register → 0
    ■ Thread 1 increments the register value → 1
    ■ Scheduler disables Thread 1
    ■ Scheduler connects Thread 2
    ■ Thread 2 reads count into register → 0
    ■ Thread 2 increases the value of the register → 1
    ■ Thread 2 stores the value in memory → 1
    ■ Scheduler disables Thread 2
    ■ Scheduler connects Thread 1
    ■ Thread 1 saves the value to memory → 1
    */
    class Counter
    {
        public static int count = 0;//0
    }
    class Program
    {
        static void Function()
        {
            for (int j = 1; j <= 1_000_000; ++j)
            { ++Counter.count; Thread.Sleep(500); }      
        }
        static void Main(string[] args)
        {

            Console.WriteLine(Counter.count);
            //Function();
            //Console.WriteLine(Counter.count);
            //int[] arr = new int[10];
            //ThreadStart
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 1; j <= 1_000_000; ++j)
                    { ++Counter.count;  }
                });
                threads[i].Start();
                //threads[i].Join();//wait - freez
            }
            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join(); // wait

            Console.WriteLine("counter = {0}", Counter.count);//5_000_000
        }
    }
}