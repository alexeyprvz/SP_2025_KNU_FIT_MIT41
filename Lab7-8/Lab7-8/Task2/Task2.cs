using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть ім'я файлу для пошуку (наприклад, notes.txt): ");
        string fileNameToSearch = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileNameToSearch))
        {
            Console.WriteLine("Ім’я файлу не може бути порожнім.");
            return;
        }

        string[] drives = Directory.GetLogicalDrives(); 

        Console.WriteLine("\nПошук виконується. Зачекайте...\n");

        int foundCount = 0;

        foreach (string drive in drives)
        {
            try
            {
                SearchFiles(drive, fileNameToSearch, ref foundCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка доступу до {drive}: {ex.Message}");
            }
        }

        if (foundCount == 0)
        {
            Console.WriteLine("Файли не знайдено.");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static void SearchFiles(string directory, string fileName, ref int foundCount)
    {
        try
        {
            foreach (var file in Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly))
            {
                if (string.Equals(Path.GetFileName(file), fileName, StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo info = new FileInfo(file);
                    Console.WriteLine("Знайдено файл:");
                    Console.WriteLine("Ім'я файлу: " + info.Name);
                    Console.WriteLine("Повний шлях: " + info.FullName);
                    Console.WriteLine("Розмір (байт): " + info.Length);
                    Console.WriteLine("Дата створення: " + info.CreationTime);
                    Console.WriteLine("Атрибути: " + info.Attributes);
                    Console.WriteLine(new string('-', 50));
                    foundCount++;
                }
            }

            foreach (var dir in Directory.GetDirectories(directory))
            {
                SearchFiles(dir, fileName, ref foundCount); // рекурсивно шукаємо в підкаталогах
            }
        }
        catch { /* Ігноруємо помилки доступу */ }
    }
}
