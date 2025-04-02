using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog4
{
    class Program
    {
        // Метод для задачі
        static void MyTask()
        {
            Console.WriteLine("MyTask №" + Task.CurrentId + " is started.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"In the method MyTask() №{Task.CurrentId} counter = {count}");
            }

            Console.WriteLine("MyTask №" + Task.CurrentId + " is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Створюємо дві задачі
            Task tsk1 = new Task(MyTask);
            Task tsk2 = new Task(MyTask);

            // Запускаємо задачі
            tsk1.Start();
            tsk2.Start();

            // Очікуємо завершення задачі 1
            tsk1.Wait();
            Console.WriteLine("First task is completed");

            // Очікуємо завершення обох задач
            Task.WaitAll(tsk1, tsk2);
            Console.WriteLine("Both tasks are completed");

            // Очікуємо завершення будь-якої задачі
            Task.WaitAny(tsk1, tsk2);  // вже завершились, тому одразу спрацює
            Console.WriteLine("Any task is completed");

            Console.WriteLine("Main thread is done.");
            Console.ReadLine();
        }
    }
}
