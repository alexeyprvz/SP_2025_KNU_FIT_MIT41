using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Перша задача
            Task tsk1 = new Task(() =>
            {
                Console.WriteLine("Task №" + Task.CurrentId + " is started.");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"In Task №{Task.CurrentId} count = {count}");
                }
                Console.WriteLine("Task №" + Task.CurrentId + " is done.");
            });

            // Продовження: друга задача запускається після завершення першої
            Task tsk2 = tsk1.ContinueWith((prevTask) =>
            {
                Console.WriteLine("Continuation Task №" + Task.CurrentId + " is started.");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(300);
                    Console.WriteLine($"In Continuation Task №{Task.CurrentId} count = {count}");
                }
                Console.WriteLine("Continuation Task №" + Task.CurrentId + " is done.");
            });

            // Запускаємо першу задачу
            tsk1.Start();

            // Головний потік працює паралельно
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Main thread is done.");
            Console.ReadLine();
        }
    }
}
