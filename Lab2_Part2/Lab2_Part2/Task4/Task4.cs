using System;
using System.Threading.Tasks;

namespace Lab2Part2Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            double[] data = new double[100000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            // Вставимо негативне значення
            data[1000] = -10;

            // Розпаралелювання з лямбда-виразом
            var result = Parallel.ForEach(data, (value, state) =>
            {
                if (value < 0)
                {
                    Console.WriteLine($"[BREAK] Found negative value: {value}");
                    state.Break();
                }

                Console.WriteLine($"Value: {value}");
            });

            if (!result.IsCompleted)
            {
                Console.WriteLine($"Loop was broken. LowestBreakIteration: {result.LowestBreakIteration}");
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
