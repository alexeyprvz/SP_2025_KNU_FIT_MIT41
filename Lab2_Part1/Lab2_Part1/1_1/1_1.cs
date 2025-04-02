using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lz4
{
    class DemoTask
    {
        // Метод, що виконується як задача
        public static void MyTask()
        {
            Console.WriteLine("MyTask() is started.");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyTask() counter = " + count);
            }
            Console.WriteLine("MyTask() is done.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            // Створення задачі
            Task tsk = new Task(DemoTask.MyTask);

            // Запуск задачі на виконання
            tsk.Start();

            // Головний потік виконує свою роботу паралельно
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
