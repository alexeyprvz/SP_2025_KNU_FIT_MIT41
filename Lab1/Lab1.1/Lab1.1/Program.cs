using System;
using System.Threading;
using Lab1._2;

class Program
{
    static void Main()
    {
        MyThread mt1 = new MyThread("Thread 1 (Normal/Середній)");
        MyThread mt2 = new MyThread("Thread 2 (AboveNormal/Вище середнього)");
        MyThread mt3 = new MyThread("Thread 3 (Highest/Найвищий)");

        mt1.Thrd.Priority = ThreadPriority.Normal;
        mt2.Thrd.Priority = ThreadPriority.AboveNormal;
        mt3.Thrd.Priority = ThreadPriority.Highest;

        mt1.Thrd.Start();
        mt2.Thrd.Start();
        mt3.Thrd.Start();

        mt1.Thrd.Join();
        mt2.Thrd.Join();
        mt3.Thrd.Join();

        long total = mt1.Count + mt2.Count + mt3.Count; // Загальна к-ть Count

        double p1 = (double)mt1.Count / total * 100; // Обчислення для кожного у відсотках
        double p2 = (double)mt2.Count / total * 100;
        double p3 = (double)mt3.Count / total * 100;

        Console.WriteLine("\n=== Результати ===");
        Console.WriteLine($"Thread {mt1.Thrd.Name}: {mt1.Count} iterations (~{p1:F2}%)");
        Console.WriteLine($"Thread {mt2.Thrd.Name}: {mt2.Count} iterations (~{p2:F2}%)");
        Console.WriteLine($"Thread {mt3.Thrd.Name}: {mt3.Count} iterations (~{p3:F2}%)");

        Console.ReadLine();
    }
}