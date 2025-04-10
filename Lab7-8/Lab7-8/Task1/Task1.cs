using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть шлях до директорії: ");
        string path = Console.ReadLine();

        if (Directory.Exists(path))
        {
            DirectoryInfo rootDir = new DirectoryInfo(path);
            PrintDirectoryStructure(rootDir, 0);
        }
        else
        {
            Console.WriteLine("Директорію не знайдено!");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static void PrintDirectoryStructure(DirectoryInfo dir, int indentLevel)
    {
        string indent = new string(' ', indentLevel * 2);
        Console.WriteLine($"{indent}[{dir.Name}]");

        foreach (FileInfo file in dir.GetFiles())
        {
            Console.WriteLine($"{indent}  - {file.Name}");
        }

        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            PrintDirectoryStructure(subDir, indentLevel + 1);
        }
    }
}
