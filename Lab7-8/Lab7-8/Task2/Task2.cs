using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть шлях до кореневої директорії для пошуку: ");
        string rootPath = Console.ReadLine();

        Console.Write("Введіть ім'я файлу для пошуку (наприклад, file.txt): ");
        string fileName = Console.ReadLine();

        if (Directory.Exists(rootPath))
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            try
            {
                FileInfo[] foundFiles = dir.GetFiles(fileName, SearchOption.AllDirectories);

                if (foundFiles.Length == 0)
                {
                    Console.WriteLine("Файли не знайдено.");
                }
                else
                {
                    Console.WriteLine($"\nЗнайдено {foundFiles.Length} файл(ів):\n");
                    foreach (FileInfo file in foundFiles)
                    {
                        Console.WriteLine("Ім'я файлу: " + file.Name);
                        Console.WriteLine("Повний шлях: " + file.FullName);
                        Console.WriteLine("Розмір (байт): " + file.Length);
                        Console.WriteLine("Дата створення: " + file.CreationTime);
                        Console.WriteLine("Атрибути: " + file.Attributes);
                        Console.WriteLine(new string('-', 50));
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Доступ до деяких папок заборонено: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Вказану директорію не знайдено.");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}
