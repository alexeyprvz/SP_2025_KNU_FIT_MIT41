using System;
using System.Threading.Tasks;

namespace Lab2Part2Task3
{
    class Program
    {
        static double[] data;

        static void MyTransform(double v, ParallelLoopState pls)
        {
            if (v < 0)
            {
                Console.WriteLine("Found negative value: " + v);
                pls.Break();
            }

            Console.WriteLine("Value is: " + v);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            data = new double[100000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            data[1000] = -10;

            ParallelLoopResult loopResult = Parallel.ForEach(data, MyTransform);

            if (!loopResult.IsCompleted)
            {
                Console.WriteLine("ParallelForEach was aborted with negative value.");
                Console.WriteLine("LowestBreakIteration: " + loopResult.LowestBreakIteration);
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
