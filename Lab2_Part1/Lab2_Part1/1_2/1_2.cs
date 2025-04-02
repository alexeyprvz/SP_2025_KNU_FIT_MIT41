using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog3
{
    class Program
    {
        // Метод, що виконується як задача
        static void MyTask()
        {
            Console.WriteLine("MyTask №" + Task.CurrentId + " is started.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"In the method MyTask() №{Task.CurrentId} counter = {count}");
            }

            Console.WriteLine("MyTask() №" + Task.CurrentId + " is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            // Створення двох задач
            Task tsk1 = new Task(MyTask);
            Task tsk2 = new Task(MyTask);

            // Запуск задач
            tsk1.Start();
            tsk2.Start();

            // Вивід їхніх ідентифікаторів
            Console.WriteLine("Id of task tsk1 = " + tsk1.Id);
            Console.WriteLine("Id of task tsk2 = " + tsk2.Id);

            // Головний потік щось робить
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
