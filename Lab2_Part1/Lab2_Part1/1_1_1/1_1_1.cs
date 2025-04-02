using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFromInstance
{
    class MyClass
    {
        // Метод, що виконується як задача
        public void MyTask()
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

            // Створюємо об'єкт класу
            MyClass mc = new MyClass();

            // Створюємо та запускаємо задачу на основі методу екземпляра
            Task tsk = new Task(mc.MyTask);
            tsk.Start();

            // Головний потік виконує свою частину
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
