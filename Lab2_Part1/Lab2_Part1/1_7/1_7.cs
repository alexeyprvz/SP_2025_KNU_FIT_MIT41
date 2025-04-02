using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prog9
{
    class Program
    {
        // Метод 1
        static void MyTask1()
        {
            Console.WriteLine("MyTask1 is started.");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyTask1 counter = " + count);
            }
            Console.WriteLine("MyTask1 is done.");
        }

        // Метод 2
        static void MyTask2()
        {
            Console.WriteLine("MyTask2 is started.");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(300);
                Console.WriteLine("In the method MyTask2 counter = " + count);
            }
            Console.WriteLine("MyTask2 is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is starting.");

            // Паралельний запуск обох методів
            Parallel.Invoke(MyTask1, MyTask2);

            Console.WriteLine("Main thread is done.");
            Console.ReadLine();
        }
    }
}
