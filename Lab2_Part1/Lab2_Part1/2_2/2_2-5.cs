using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_FinalVersion
{
    class Program
    {
        // Метод задачі
        static void MyTask()
        {
            int? taskId = Task.CurrentId ?? 0;

            Console.WriteLine("Task  # " + taskId + "  is started.");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(200);
                Console.WriteLine("Task  # " + taskId + "  counter = " + count);
            }

            Console.WriteLine("Task  # " + taskId + "  is finished.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.\n");

            // 1. Створення та запуск двох задач
            Task tsk1 = new Task(MyTask);
            Task tsk2 = new Task(MyTask);

            tsk1.Start();
            tsk2.Start();

            // 2. Очікування завершення обох задач
            Task.WaitAll(tsk1, tsk2);

            // 3. Задача у вигляді лямбда-виразу
            Task lambdaTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("\nLambda task is started.");
                for (int count = 0; count < 5; count++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Lambda  counter = " + count);
                }
                Console.WriteLine("Lambda task is finished.");
            });

            lambdaTask.Wait();

            // 4. Паралельні лямбда-вирази з Invoke()
            Console.WriteLine("\nParallel.Invoke is starting.");

            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Parallel 1 is started.");
                    for (int count = 0; count < 5; count++)
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Parallel 1  counter = " + count);
                    }
                    Console.WriteLine("Parallel 1 is finished.");
                },
                () =>
                {
                    Console.WriteLine("Parallel 2 is started.");
                    for (int count = 0; count < 5; count++)
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Parallel 2  counter = " + count);
                    }
                    Console.WriteLine("Parallel 2 is finished.");
                }
            );

            Console.WriteLine("\nMain thread is done.");
            Console.ReadLine();
        }
    }
}
