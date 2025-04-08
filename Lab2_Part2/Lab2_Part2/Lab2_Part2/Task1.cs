using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== DOUBLE EXPERIMENTS ====");
            RunDoubleExperiment("x / 10", x => x / 10);
            RunDoubleExperiment("x / PI", x => x / Math.PI);
            RunDoubleExperiment("e^x / x^PI", x => Math.Exp(x) / Math.Pow(x, Math.PI));
            RunDoubleExperiment("e^(PIx) / x^PI", x => Math.Exp(x * Math.PI) / Math.Pow(x, Math.PI));

            Console.WriteLine("\n==== INT EXPERIMENTS ====");
            RunIntExperiment("x / 10", x => (int)(x / 10.0));
            RunIntExperiment("x / PI", x => (int)(x / Math.PI));
            RunIntExperiment("e^x / x^PI", x => (int)(Math.Exp(x) / Math.Pow(x, Math.PI)));
            RunIntExperiment("e^(PIx) / x^PI", x => (int)(Math.Exp(x * Math.PI) / Math.Pow(x, Math.PI)));
        }

        static void RunDoubleExperiment(string label, Func<double, double> operation)
        {
            int[] sizes = { 10_000, 100_000, 1_000_000 };
            Console.WriteLine($"\n-- {label} --");

            foreach (var size in sizes)
            {
                double[] data = new double[size];
                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    data[i] = operation(data[i]);
                sw.Stop();
                double serialTime = sw.Elapsed.TotalMilliseconds;

                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                sw.Restart();
                Parallel.For(0, size, i =>
                {
                    data[i] = operation(data[i]);
                });
                sw.Stop();
                double parallelTime = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Size: {size,10} | Serial: {serialTime,8:F2} ms | Parallel: {parallelTime,8:F2} ms");
            }
        }

        static void RunIntExperiment(string label, Func<int, int> operation)
        {
            int[] sizes = { 10_000, 100_000, 1_000_000 };
            Console.WriteLine($"\n-- {label} --");

            foreach (var size in sizes)
            {
                int[] data = new int[size];
                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    data[i] = operation(data[i]);
                sw.Stop();
                double serialTime = sw.Elapsed.TotalMilliseconds;

                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                sw.Restart();
                Parallel.For(0, size, i =>
                {
                    data[i] = operation(data[i]);
                });
                sw.Stop();
                double parallelTime = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Size: {size,10} | Serial: {serialTime,8:F2} ms | Parallel: {parallelTime,8:F2} ms");
            }
        }
    }
}
