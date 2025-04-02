using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Задача, яка повертає результат (сума чисел)
            Task<int> tsk = new Task<int>(() =>
            {
                Console.WriteLine("Task №" + Task.CurrentId + " is started.");
                int sum = 0;
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(200);
                    sum += i;
                    Console.WriteLine($"In Task №{Task.CurrentId} i = {i}, sum = {sum}");
                }
                Console.WriteLine("Task №" + Task.CurrentId + " is done.");
                return sum;
            });

            // Запускаємо задачу
            tsk.Start();

            // Отримуємо результат (блокує потік, поки задача не завершиться)
            int result = tsk.Result;

            Console.WriteLine($"\nResult from Task: {result}");
            Console.WriteLine("Main thread is done.");
            Console.ReadLine();
        }
    }
}
