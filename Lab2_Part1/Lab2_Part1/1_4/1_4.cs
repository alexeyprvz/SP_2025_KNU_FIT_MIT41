using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Задача створюється через лямбда-вираз
            Task tsk = new Task(() =>
            {
                Console.WriteLine("Task №" + Task.CurrentId + " is started.");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"In Task №{Task.CurrentId} count = {count}");
                }
                Console.WriteLine("Task №" + Task.CurrentId + " is done.");
            });

            // Запускаємо задачу
            tsk.Start();

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
