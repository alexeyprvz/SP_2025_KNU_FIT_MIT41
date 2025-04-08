using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== DOUBLE EXPERIMENTS (з Break) ====");
            RunDoubleExperiment("x / 10", x => x / 10);
            RunDoubleExperiment("x / PI", x => x / Math.PI);
            RunDoubleExperiment("e^x / x^π", x => Math.Exp(x) / Math.Pow(x, Math.PI));
            RunDoubleExperiment("e^(πx) / x^π", x => Math.Exp(x * Math.PI) / Math.Pow(x, Math.PI));

            Console.WriteLine("\n==== INT EXPERIMENTS (з Break)====");
            RunIntExperiment("x / 10", x => (int)(x / 10.0));
            RunIntExperiment("x / PI", x => (int)(x / Math.PI));
            RunIntExperiment("e^x / x^PI", x => (int)(Math.Exp(x) / Math.Pow(x, Math.PI)));
            RunIntExperiment("e^(PIx) / x^PI", x => (int)(Math.Exp(x * Math.PI) / Math.Pow(x, Math.PI)));
        }

        static void RunDoubleExperiment(string label, Func<double, double> operation)
        {
            int[] sizes = { 10_000, 100_000, 1_000_000 };
            Console.WriteLine($"\n-- {label} --");

            const double TARGET = 12345.0;
            const double DELTA = 0.01;

            foreach (var size in sizes)
            {
                double[] data = new double[size];
                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                // Вставляємо значення в околі TARGET
                int insertIndex = size / 2;
                data[insertIndex] = TARGET + 0.005;

                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    data[i] = operation(data[i]);
                sw.Stop();
                double serialTime = sw.Elapsed.TotalMilliseconds;

                for (int i = 0; i < size; i++)
                    data[i] = i + 1;
                data[insertIndex] = TARGET + 0.005;

                sw.Restart();
                ParallelLoopResult result = Parallel.For(0, size, (i, state) =>
                {
                    if (Math.Abs(data[i] - TARGET) <= DELTA)
                    {
                        Console.WriteLine($"[BREAK] Found value near target at index {i} => {data[i]}");
                        state.Break();
                    }

                    data[i] = operation(data[i]);
                });
                sw.Stop();
                double parallelTime = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Size: {size,10} | Serial: {serialTime,8:F2} ms | Parallel: {parallelTime,8:F2} ms | Break: {!result.IsCompleted}, Iter: {result.LowestBreakIteration}");
            }
        }

        // Int експерименти без змін
        static void RunIntExperiment(string label, Func<int, int> operation)
        {
            int[] sizes = { 10_000, 100_000, 1_000_000 };
            Console.WriteLine($"\n-- {label} --");

            const int TARGET_INT = 12345;
            const int DELTA_INT = 1;

            foreach (var size in sizes)
            {
                int[] data = new int[size];
                for (int i = 0; i < size; i++)
                    data[i] = i + 1;

                // Спеціально вставимо значення в околі TARGET_INT
                int insertIndex = size / 3;
                data[insertIndex] = TARGET_INT + 1;

                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < size; i++)
                    data[i] = operation(data[i]);
                sw.Stop();
                double serialTime = sw.Elapsed.TotalMilliseconds;

                for (int i = 0; i < size; i++)
                    data[i] = i + 1;
                data[insertIndex] = TARGET_INT + 1;

                sw.Restart();
                ParallelLoopResult result = Parallel.For(0, size, (i, state) =>
                {
                    if (Math.Abs(data[i] - TARGET_INT) <= DELTA_INT)
                    {
                        Console.WriteLine($"[BREAK] Found int value near target at index {i} => {data[i]}");
                        state.Break();
                    }

                    data[i] = operation(data[i]);
                });
                sw.Stop();
                double parallelTime = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine($"Size: {size,10} | Serial: {serialTime,8:F2} ms | Parallel: {parallelTime,8:F2} ms | Break: {!result.IsCompleted}, Iter: {result.LowestBreakIteration}");
            }
        }

    }
}
