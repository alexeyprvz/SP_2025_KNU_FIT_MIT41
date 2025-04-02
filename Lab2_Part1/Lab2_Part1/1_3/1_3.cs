using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Створення і запуск задачі за допомогою TaskFactory
            Task tsk = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task №" + Task.CurrentId + " is started.");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"In Task №{Task.CurrentId} count = {count}");
                }
                Console.WriteLine("Task №" + Task.CurrentId + " is done.");
            });

            // Основний потік паралельно виводить крапки
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
